using Hydra.Auth.Core.Models;
using Hydra.Cms.Core.Domain;
using Hydra.Cms.Core.Interfaces;
using Hydra.Cms.Core.Models;
using Hydra.Infrastructure;
using Hydra.Infrastructure.Data;
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
        private readonly ITagService _tagService;

        public ArticleService(IQueryRepository queryRepository, ICommandRepository commandRepository, ITagService tagService)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
            _tagService = tagService;
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
                                  PreviewImageId = article.PreviewImageId,
                                  PreviewImageUrl = article.PreviewImageUrl,
                                  PublishDate = article.PublishDate,
                                  EditDate = article.EditDate,
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
                                      Id = article.Editor!.Id,
                                      Name = article.Editor!.Name ?? "",
                                      UserName = article.Editor!.UserName ?? "",
                                      Avatar = article.Editor!.Avatar ?? ""
                                  },
                                  IsDraft = article.IsDraft,
                                  Tags = article.Tags.Select(x => x.Title).ToList(),
                                  TopicsIds = article.Topics.Select(x => x.Id).ToList()

                              }).ToPaginatedListAsync(dataGrid);


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
            var article = await _queryRepository.Table<Article>().Include(x => x.Writer).Include(x => x.Editor).Include(x => x.Tags).Include(x => x.Topics).Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            var articleModel = new ArticleModel()
            {
                Id = article.Id,
                Subject = article.Subject,
                Body = article.Body,
                PreviewImageId = article.PreviewImageId,
                PreviewImageUrl = article.PreviewImageUrl,
                PublishDate = article.PublishDate,
                RegisterDate = article.RegisterDate,
                EditDate = article.EditDate,
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
                Tags = article.Tags.Select(x => x.Title).ToList(),
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
            try
            {
                bool isExist = await _queryRepository.Table<Article>().AnyAsync(x => x.Subject == articleModel.Subject);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Subject already exist";
                    result.Errors.Add(new Error(nameof(articleModel.Subject), "The Subject already exist"));
                    return result;
                }
                var tags = articleModel.Tags.ToArray();
                await _tagService.Add(tags);

                var article = new Article()
                {
                    Subject = articleModel.Subject,
                    Body = articleModel.Body,
                    PublishDate = articleModel.PublishDate,
                    RegisterDate = DateTime.UtcNow,
                    WriterId = articleModel.WriterId,
                    IsDraft = articleModel.IsDraft,
                    PreviewImageId = articleModel.PreviewImageId,
                    PreviewImageUrl = articleModel.PreviewImageUrl,
                };

                await _commandRepository.InsertAsync(article);

                await _commandRepository.SaveChangesAsync();

                article.Tags = _queryRepository.Table<Tag>().Where(x => articleModel.Tags.Contains(x.Title)).ToList();
                article.Topics = _queryRepository.Table<Topic>().Where(x => articleModel.TopicsIds.Contains(x.Id)).ToList();


                await _commandRepository.SaveChangesAsync();

                articleModel.Id = article.Id;

                result.Data = articleModel;

                return result;
            }
            catch (Exception e)
            {
                result.Message = e.Message;
                result.Status = ResultStatusEnum.ExceptionThrowed;
                return result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="articleModel"></param>
        /// <returns></returns>
        public async Task<Result<ArticleModel>> Update(ArticleModel articleModel)
        {
            var result = new Result<ArticleModel>();
            try
            {
                var article = await _queryRepository.Table<Article>().FirstOrDefaultAsync(x => x.Id == articleModel.Id);
                if (article is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The Article not found";
                    return result;
                }

                await _tagService.Add(articleModel.Tags.ToArray());

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
                article.PreviewImageId = articleModel.PreviewImageId;
                article.PreviewImageUrl = articleModel.PreviewImageUrl;


                article.Tags = _queryRepository.Table<Tag>().Where(x => articleModel.Tags.Contains(x.Title)).ToList();
                ////article.Topics = _queryRepository.Table<Topic>().Where(x => articleModel.TopicsIds.Contains(x.Id)).ToList();

                _commandRepository.DetectChanges();
                _commandRepository.UpdateAsync(article);
                await _commandRepository.SaveChangesAsync();


                result.Data = articleModel;

                return result;
            }
            catch (Exception e)
            {
                result.Message = e.Message;
                result.Status = ResultStatusEnum.ExceptionThrowed;
                return result;
            }
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