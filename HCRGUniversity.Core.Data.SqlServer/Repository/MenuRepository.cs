using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace HCRGUniversity.Core.Data.SqlServer.Repository
{
    public class MenuRepository : BaseRepository<Menu, HCRGUniversityDBContext>, IMenuRepository
    {
        public MenuRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }

        public IEnumerable<Menu> GetUserMenuByGroupID(int id)
        {
            SqlParameter _userMenuGroupID = new SqlParameter("@UserMenuGroupID", id);
            return Context.Database.SqlQuery<Menu>(Constant.StoredProcedureConst.MenuRepository.GetUserMenuByGroupID, _userMenuGroupID).ToList();
        }

        public IEnumerable<Menu> GetUserMenuBySpecialMenuID(string SpecialMenuIDs)
        {
            SqlParameter _specialMenuIDs = new SqlParameter("@SpecialMenuIDs", SpecialMenuIDs);
            return Context.Database.SqlQuery<Menu>(Constant.StoredProcedureConst.MenuRepository.GetUserMenuBySpecialMenuID, _specialMenuIDs).ToList();
        }
    }
}