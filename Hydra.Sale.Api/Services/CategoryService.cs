using EFCoreSecondLevelCacheInterceptor;
using Hydra.Kernel.Interfaces.Data;
using Hydra.Kernel.Models;
using Hydra.Sale.Core.Domain;
using Hydra.Sale.Core.Interfaces;
using Hydra.Sale.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Hydra.Sale.Api.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly ICommandRepository _commandRepository;
        public CategoryService(IQueryRepository queryRepository, ICommandRepository commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        private List<CategoryModel> GetCategoriesList()
        {

            var list = (from category in _queryRepository.Table<Category>()
                             select new CategoryModel()
                             {
                                 Id = category.Id,
                                 Name = category.Name,
                                 MetaKeywords = category.MetaKeywords,
                                 MetaTitle = category.MetaTitle,
                                 Description = category.Description,
                                 MetaDescription = category.MetaDescription,
                                 ParentCategoryId = category.ParentCategoryId,
                                 PictureId = category.PictureId,
                                 ShowOnHomepage = category.ShowOnHomepage,
                                 Published = category.Published,
                                 Deleted = category.Deleted,
                                 DisplayOrder = category.DisplayOrder,
                                 CreatedOnUtc = category.CreatedOnUtc,
                                 UpdatedOnUtc = category.UpdatedOnUtc

                             }).OrderByDescending(x => x.Id).Cacheable().ToList();

            return list;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public Result<List<CategoryModel>> GetList()
        {
            var result = new Result<List<CategoryModel>>();

            result.Data = GetCategoriesList();

            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Result<List<CategoryModel>> GetHierarchy()
        {
            var result = new Result<List<CategoryModel>>();

            var list = GetCategoriesList();

            var parents = list.Where(x => x.ParentCategoryId == null).ToList();
            foreach (var topic in parents)
            {
                var childs = GetChild(topic, list);
                if (childs != null)
                {
                    topic.Childs.AddRange(childs);
                }
            }

            result.Data = parents;

            return result;
        }
        private List<CategoryModel> GetChild(CategoryModel topic, List<CategoryModel> topics)
        {

            var result = topics.Where(x => x.ParentCategoryId == topic.Id).ToList();
            if (result.Count == 0) return null;
            foreach (var item in result)
            {
                var childs = GetChild(item, topics);
                if (childs != null)
                    item.Childs.AddRange(childs);
            }
            return result;
        }


        List<CategoryModel> resultList = new List<CategoryModel>();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Result<List<CategoryModel>> GetListForSelect()
        {
            var result = new Result<List<CategoryModel>>();

            var list = GetCategoriesList().Where(x => !x.Deleted).Select(category => new CategoryModel()
            {
                Id = category.Id,
                Name = category.Name
            }).ToList();

            var parents = list.Where(x => x.ParentCategoryId == null).ToList();

            foreach (var category in parents)
            {
                GetChildOfSelect(category, "", list);
            }

            result.Data = resultList;

            return result;
        }

        private List<CategoryModel> GetChildOfSelect(CategoryModel topic, string space, List<CategoryModel> topics)
        {
            topic.Name = space + topic.Name;
            resultList.Add(topic);

            var childs = topics.Where(x => x.ParentCategoryId == topic.Id).ToList();
            if (childs.Count == 0)
            {
                return null;
            }
            foreach (var item in childs)
            {
                GetChildOfSelect(item, space + "    ", topics);
            }
            return childs;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Result<CategoryModel> GetById(int id)
        {
            var result = new Result<CategoryModel>();

            result.Data = GetCategoriesList().FirstOrDefault(x => x.Id == id) ?? new CategoryModel();

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryModel"></param>
        /// <returns></returns>
        public async Task<Result<CategoryModel>> Add(CategoryModel categoryModel)
        {
            var result = new Result<CategoryModel>();
            try
            {
                bool isExist = await _queryRepository.Table<Category>().AnyAsync(x => x.Id == categoryModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(categoryModel.Id), "The Id already exist"));
                    return result;
                }
                var category = new Category()
                {
                    Name = categoryModel.Name,
                    MetaKeywords = categoryModel.MetaKeywords,
                    MetaTitle = categoryModel.MetaTitle,
                    Description = categoryModel.Description,
                    MetaDescription = categoryModel.MetaDescription,
                    ParentCategoryId = categoryModel.ParentCategoryId,
                    PictureId = categoryModel.PictureId,
                    ShowOnHomepage = categoryModel.ShowOnHomepage,
                    Published = categoryModel.Published,
                    Deleted = categoryModel.Deleted,
                    DisplayOrder = categoryModel.DisplayOrder,
                    CreatedOnUtc = categoryModel.CreatedOnUtc,
                    UpdatedOnUtc = categoryModel.UpdatedOnUtc,
                    //ProductCategories = categoryModel.ProductCategories,
                    //Discounts = categoryModel.Discounts,

                };

                await _commandRepository.InsertAsync(category);
                await _commandRepository.SaveChangesAsync();

                categoryModel.Id = category.Id;

                result.Data = categoryModel;

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
        /// <param name="categoryModel"></param>
        /// <returns></returns>
        public async Task<Result<CategoryModel>> Update(CategoryModel categoryModel)
        {
            var result = new Result<CategoryModel>();
            try
            {
                var category = await _queryRepository.Table<Category>().FirstAsync(x => x.Id == categoryModel.Id);
                if (category is null)
                {
                    result.Status = ResultStatusEnum.NotFound;
                    result.Message = "The Category not found";
                    return result;
                }
                bool isExist = await _queryRepository.Table<Category>().AnyAsync(x => x.Id != categoryModel.Id);
                if (isExist)
                {
                    result.Status = ResultStatusEnum.ItsDuplicate;
                    result.Message = "The Id already exist";
                    result.Errors.Add(new Error(nameof(categoryModel.Id), "The Id already exist"));
                    return result;
                }
                category.Name = categoryModel.Name;
                category.MetaKeywords = categoryModel.MetaKeywords;
                category.MetaTitle = categoryModel.MetaTitle;
                category.Description = categoryModel.Description;
                category.MetaDescription = categoryModel.MetaDescription;
                category.ParentCategoryId = categoryModel.ParentCategoryId;
                category.PictureId = categoryModel.PictureId;
                category.ShowOnHomepage = categoryModel.ShowOnHomepage;
                category.Published = categoryModel.Published;
                category.Deleted = categoryModel.Deleted;
                category.DisplayOrder = categoryModel.DisplayOrder;
                category.CreatedOnUtc = categoryModel.CreatedOnUtc;
                category.UpdatedOnUtc = categoryModel.UpdatedOnUtc;
                //category.ProductCategories = categoryModel.ProductCategories;
                //category.Discounts = categoryModel.Discounts;

                _commandRepository.UpdateAsync(category);
                await _commandRepository.SaveChangesAsync();

                result.Data = categoryModel;

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
            var category = await _queryRepository.Table<Category>().FirstOrDefaultAsync(x => x.Id == id);
            if (category is null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The Category not found";
                return result;
            }

            category.Deleted = true;

            _commandRepository.UpdateAsync(category);

            await _commandRepository.SaveChangesAsync();

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result> Remove(int id)
        {
            var result = new Result();
            var category = await _queryRepository.Table<Category>().FirstOrDefaultAsync(x => x.Id == id);
            if (category is null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The Category not found";
                return result;
            }

            _commandRepository.DeleteAsync(category);
            await _commandRepository.SaveChangesAsync();

            return result;
        }

    }
}