using Hydra.Cms.Core.Domain;
using Hydra.Cms.Core.Interfaces;
using Hydra.Cms.Core.Models;
using Hydra.Infrastructure.Security.Domain;
using Hydra.Kernel.Extensions;
using Hydra.Kernel.Interfaces.Data;
using Hydra.Kernel.Models;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;

namespace Hydra.Cms.Api.Services
{
    public class MenuService : IMenuService
    {
        private readonly IQueryRepository _queryRepository;
        private readonly ICommandRepository _commandRepository;

        public MenuService(IQueryRepository queryRepository, ICommandRepository commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<Result<List<MenuModel>>> GetHierarchy()
        {
            var result = new Result<List<MenuModel>>();

            var list = await _queryRepository.Table<Menu>().Select(x => new MenuModel()
            {
                Id = x.Id,
                Title = x.Title,
                Url = x.Url,
                PreviewImageId = x.PreviewImageId,
                Order = x.Order,
                ParentId = x.ParentId
            }).OrderBy(x => x.Order).ToListAsync();

            var parents = list.Where(x => x.ParentId == null).ToList();
            foreach (var menu in parents)
            {
                var childs = GetChild(menu, list);
                if (childs != null)
                {
                    menu.Childs.AddRange(childs);
                }
            }

            result.Data = parents;

            return result;
        }
        private List<MenuModel> GetChild(MenuModel menu, List<MenuModel> menus)
        {

            var result = menus.Where(x => x.ParentId == menu.Id).ToList();
            if (result.Count == 0) return null;
            foreach (var item in result)
            {
                var childs = GetChild(item, menus);
                if (childs != null)
                    item.Childs.AddRange(childs);
            }
            return result;
        }

        List<MenuModel> resultList = new List<MenuModel>();
        private List<MenuModel> GetChildOfSelect(MenuModel menu, string space, List<MenuModel> menus)
        {
            menu.Title = space + menu.Title;
            resultList.Add(menu);

            var childs = menus.Where(x => x.ParentId == menu.Id).ToList();
            if (childs.Count == 0)
            {
                return null;
            }
            foreach (var item in childs)
            {
                GetChildOfSelect(item, space + "    ", menus);
            }
            return childs;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<MenuModel>> GetById(int id)
        {
            var result = new Result<MenuModel>();

            var record = await _queryRepository.Table<Menu>().Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            var menu = new MenuModel();
            if (record != null)
            {
                menu.Id = record.Id;
                menu.Title = record.Title;
                menu.Url = record.Url;
                menu.PreviewImageId = record.PreviewImageId;
                menu.Order = record.Order;
                menu.ParentId = record.ParentId;
            }
            result.Data = menu;
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuModel"></param>
        /// <returns></returns>
        public async Task<Result<MenuModel>> Add(MenuModel menuModel)
        {
            var result = new Result<MenuModel>();

            var isExist = await _queryRepository.Table<Menu>().AnyAsync(x => x.Title == menuModel.Title);
            if (isExist)
            {
                result.Status = ResultStatusEnum.ItsDuplicate;
                result.Errors.Add(new Error(nameof(menuModel.Title), "The menu name existed"));
                result.Message = "The menu existed";
                return result;
            }

            var maxOrder = _queryRepository.Table<Menu>().OrderByDescending(x => x.Order).FirstOrDefault()?.Order ?? 0;

            var menu = new Menu()
            {
                Id = menuModel.Id,
                Title = menuModel.Title,
                Url = menuModel.Url,
                PreviewImageId = menuModel.PreviewImageId,
                Order = maxOrder + 1,
                ParentId = menuModel.ParentId,
                UserId = menuModel.UserId
            };
            await _commandRepository.InsertAsync(menu);

            await _commandRepository.SaveChangesAsync();
            var userName = _queryRepository.Table<User>().First(x => x.Id == menuModel.UserId).UserName;
            menuModel.Id = menu.Id;
            menuModel.UserId = menu.UserId;
            menuModel.UserName = userName;
            result.Data = menuModel;
            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuModel"></param>
        /// <returns></returns>
        public async Task<Result<MenuModel>> Update(MenuModel menuModel)
        {
            var result = new Result<MenuModel>();
            var menu = await _queryRepository.Table<Menu>().FirstOrDefaultAsync(x => x.Id == menuModel.Id);
            if (menu is null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The menu not found";
                return result;
            }

            var isExist = await _queryRepository.Table<Menu>().AnyAsync(x => x.Id != menuModel.Id && x.Title == menuModel.Title);
            if (isExist)
            {
                result.Status = ResultStatusEnum.ItsDuplicate;
                result.Errors.Add(new Error(nameof(menuModel.Title), "The menu name existed"));
                result.Message = "The menu existed";
                return result;
            }

            var regsterDate = DateTime.UtcNow;

            menu.Title = menuModel.Title;
            menu.Url = menuModel.Url;
            menu.PreviewImageId = menuModel.PreviewImageId;
            menu.UserId = menu.UserId;

            _commandRepository.UpdateAsync(menu);

            await _commandRepository.SaveChangesAsync();

            var userName = _queryRepository.Table<User>().First(x => x.Id == menuModel.UserId).UserName;

            menuModel.UserName = userName;

            result.Data = menuModel;
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<Result> Delete(int id)
        {
            var result = new Result();
            var menu = await _queryRepository.Table<Menu>().FirstOrDefaultAsync(x => x.Id == id);
            if (menu == null)
            {
                result.Status = ResultStatusEnum.NotFound;
                result.Message = "The menu not found";
                return result;
            }

            if (_queryRepository.Table<Menu>().Any(x => x.ParentId == id))
            {
                result.Status = ResultStatusEnum.IsNotAllowed;
                result.Message = "Is Not Allowed. because this menu parent of another menu";
                return result;
            }

            _commandRepository.DeleteAsync(menu);

            await _commandRepository.SaveChangesAsync();

            return result;
        }
    }
}