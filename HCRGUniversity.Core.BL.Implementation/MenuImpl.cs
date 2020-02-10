using HCRGUniversity.Core.Data;
using Omu.ValueInjecter;
using System.Collections.Generic;
using System.Linq;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL.Implementation
{
    public class MenuImpl : IMenu
    {
        private readonly IMenuRepository _menuRepository;

        public MenuImpl(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public IEnumerable<DLModel.Menu> getAllMenu()
        {
            return _menuRepository.GetAll().Select(ms => new DLModel.Menu().InjectFrom(ms)).Cast<DLModel.Menu>().OrderBy(ms => ms.MenuName).Where(ms => ms.IsActive == true).ToList();
        }

        public IEnumerable<DLModel.Menu> GetUserMenuByGroupID(int id)
        {
            return _menuRepository.GetUserMenuByGroupID(id);
        }

        public IEnumerable<DLModel.Menu> GetUserMenuBySpecialMenuID(string SpecialMenuIDs)
        {
            return _menuRepository.GetUserMenuBySpecialMenuID(SpecialMenuIDs);
        }
     }
}
