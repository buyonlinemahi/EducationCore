using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;

namespace HCRGUniversity.Core.Data
{
    public interface IMenuRepository : IBaseRepository<Menu>
    {
        IEnumerable<Menu> GetUserMenuByGroupID(int id);

        IEnumerable<Menu> GetUserMenuBySpecialMenuID(string SpecialMenuIDs);
    }
}
