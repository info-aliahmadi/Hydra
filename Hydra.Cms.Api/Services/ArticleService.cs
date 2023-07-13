using Hydra.Auth.Core.Models;
using Hydra.Cms.Core.Domain;
using Hydra.Cms.Core.Interfaces;
using Hydra.Cms.Core.Models;
using Hydra.Infrastructure;
using Hydra.Infrastructure.Data.Extension;
using Hydra.Infrastructure.Security.Domain;
using Hydra.Kernel.Extensions;
using Hydra.Kernel.Interfaces.Data;
using Hydra.Kernel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Hydra.Cms.Api.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly ICommandRepository _commandRepository;

        public ArticleService(IQueryRepository queryRepository, ICommandRepository commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public async Task<Result<PaginatedList<ArticleModel>>> GetList(GridDataBound dataGrid)
        {
            var result = new Result<PaginatedList<ArticleModel>>();

            var list = await (from article in _queryRepository.Table<Article>().Include(x => x.Writer).Include(x => x.Editor)
                              select new ArticleModel()
                              {
                                  Id = article.Id,
                                  Subject = article.Subject,
                                  Body = article.Body,
                                  SmallThumbnail = article.SmallThumbnail,
                                  LargeThumbnail = article.LargeThumbnail,
                                  PublishDate = article.PublishDate,
                                  RegisterDate = article.RegisterDate,
                                  WriterId = article.WriterId,
                                  EditorId = article.EditorId,
                                  Writer = new AuthorModel()
                                  {
                                      Id = article.Writer.Id,
                                      Name = article.Writer.Name,
                                      UserName = article.Writer.UserName,
                                      Avatar = article.Writer.Avatar
                                  },
                                  Editor = new AuthorModel()
                                  {
                                      Id = article.Editor.Id,
                                      Name = article.Editor.Name ?? "",
                                      UserName = article.Editor.UserName,
                                      Avatar = article.Editor.Avatar
                                  },
                                  IsDraft = article.IsDraft,
                                  Tags = article.Tags,
                                  TopicsIds = article.Topics.Select(x => x.Id).ToList()

                              }).ToPaginatedListAsync(dataGrid);

            //var userIds = list.Items.Select(x => x.Id);

            //var userRoleTable = from userRole in _queryRepository.Table<UserRole>()
            //                    join role in _queryRepository.Table<Role>() on userRole.RoleId equals role.Id
            //                    where userIds.Contains(userRole.UserId)
            //                    select new
            //                    {
            //                        role.Id,
            //                        userRole.UserId,
            //                    };
            //foreach (var item in list.Items)
            //{
            //    item.RoleIds = userRoleTable.Where(x => x.UserId == item.Id).Select(x => x.Id).ToList();
            //}

            result.Data = list;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<ArticleModel>> GetById(int id)
        {
            var result = new Result<ArticleModel>();
            var article = await _queryRepository.Table<Article>().Include(x => x.Writer).Include(x => x.Editor).Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            var articleModel = new ArticleModel()
            {
                Id = article.Id,
                Subject = article.Subject,
                Body = article.Body,
                SmallThumbnail = article.SmallThumbnail,
                LargeThumbnail = article.LargeThumbnail,
                PublishDate = article.PublishDate,
                RegisterDate = article.RegisterDate,
                WriterId = article.WriterId,
                EditorId = article.EditorId,
                Writer = new AuthorModel()
                {
                    Id = article.Writer.Id,
                    Name = article.Writer.Name,
                    UserName = article.Writer.UserName,
                    Avatar = article.Writer.Avatar
                },
                Editor = new AuthorModel()
                {
                    Id = article.Editor?.Id ?? 0,
                    Name = article.Editor?.Name,
                    UserName = article.Editor?.UserName,
                    Avatar = article.Editor?.Avatar
                },
                IsDraft = article.IsDraft,
                Tags = article.Tags,
                TopicsIds = article.Topics.Select(x => x.Id).ToList()
            };
            result.Data = articleModel;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="articleModel"></param>
        /// <returns></returns>
        public async Task<Result<ArticleModel>> Add(ArticleModel articleModel)
        {
            var result = new Result<ArticleModel>();

            bool isExist = await _queryRepository.Table<Article>().AnyAsync(x => x.Subject == articleModel.Subject);
            if (isExist)
            {
                result.Status = ResultStatusEnum.ItsDuplicate;
                result.Message = "The Subject already exist";
                result.Errors.Add(new Error(nameof(articleModel.Subject), "The Subject already exist"));
                return result;
            }

            var article = new Article()
            {
                Subject = articleModel.Subject,
                Body = articleModel.Body,
                PublishDate = articleModel.PublishDate,
                RegisterDate = DateTime.UtcNow,
                WriterId = articleModel.WriterId,
                IsDraft = articleModel.IsDraft,
                Tags = articleModel.Tags,
                SmallThumbnail = articleModel.SmallThumbnail,
                LargeThumbnail = articleModel.LargeThumbnail,
                Topics = _queryRepository.Table<Topic>().Where(x => articleModel.TopicsIds.Contains(x.Id)).ToList()
            };

            await _commandRepository.InsertAsync(article);

            await _commandRepository.SaveChangesAsync();

            //if (!string.IsNullOrEmpty(articleModel.SmallThumbnailFile))
            //{
            //    var saveFileResult = SaveThumbnailFile(articleModel.SmallThumbnailFile, article.Id, "small");
            //    if (saveFileResult.Succeeded)
            //    {
            //        article.SmallThumbnail = saveFileResult.Data;
            //    }
            //}

            //if (!string.IsNullOrEmpty(articleModel.LargeThumbnailFile))
            //{
            //    var saveFileResult = SaveThumbnailFile(articleModel.LargeThumbnailFile, article.Id, "large");
            //    if (saveFileResult.Succeeded)
            //    {
            //        article.LargeThumbnail = saveFileResult.Data;
            //    }
            //}
            _commandRepository.UpdateAsync(article);

            await _commandRepository.SaveChangesAsync();

            articleModel.Id = article.Id;

            result.Data = articleModel;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="articleModel"></param>
        /// <returns></returns>
        public async Task<Result<ArticleModel>> Update(ArticleModel articleModel)
        {
            var result = new Result<ArticleModel>();

            var article = await _queryRepository.Table<Article>().FirstOrDefaultAsync(x => x.Id == articleModel.Id);
            if (article is null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The Article not found";
                return result;
            }

            bool isExist = await _queryRepository.Table<Article>().AnyAsync(x => x.Id != articleModel.Id && x.Subject == articleModel.Subject);
            if (isExist)
            {
                result.Status = ResultStatusEnum.ItsDuplicate;
                result.Message = "The Subject already exist";
                result.Errors.Add(new Error(nameof(articleModel.Subject), "The Subject already exist"));
                return result;
            }

            article.Subject = articleModel.Subject;
            article.Body = articleModel.Body;
            article.EditorId = articleModel.EditorId;
            article.EditDate = DateTime.UtcNow;
            article.IsDraft = articleModel.IsDraft;
            article.Tags = articleModel.Tags;
            article.SmallThumbnail = articleModel.SmallThumbnail;
            article.LargeThumbnail = articleModel.LargeThumbnail;
            article.Topics = _queryRepository.Table<Topic>().Where(x => articleModel.TopicsIds.Contains(x.Id)).ToList();

        

            _commandRepository.UpdateAsync(article);

            await _commandRepository.SaveChangesAsync();

            result.Data = articleModel;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result> Delete(int id)
        {
            var result = new Result();
            var article = await _queryRepository.Table<Article>().FirstOrDefaultAsync(x => x.Id == id);
            if (article is null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The Article not found";
                return result;
            }

            _commandRepository.DeleteAsync(article);

            await _commandRepository.SaveChangesAsync();

            return result;
        }

    }
}