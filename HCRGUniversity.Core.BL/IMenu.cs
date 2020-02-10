using System;
using System.Collections.Generic;
using HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL
{
    public interface IMenu
    {
        IEnumerable<Menu> getAllMenu();
        IEnumerable<Menu> GetUserMenuByGroupID(int id);
        IEnumerable<Menu> GetUserMenuBySpecialMenuID(string SpecialMenuIDs);
    }
}
