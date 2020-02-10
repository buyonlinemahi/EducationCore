using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.Data.SqlServer.Repository
{
    public class AboutUsRepository: BaseRepository<About, HCRGUniversityDBContext>,IAboutUsRepository
    {
        public AboutUsRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }
        public IEnumerable<About> GetAllPagedAboutUs(int skip, int take)
        {
            return dbset.ToArray().OrderByDescending(o => o.AboutUsID).Skip(skip).Take(take);           
        }

        public int GetAboutUsCount()
        {
            return dbset.Count();
        }
        public IEnumerable<BLModel.About> GetAllAboutUsByOrganizationID(int OrganizationID, int ClientID)
        {
            SqlParameter _OrganizationID = new SqlParameter("@OrgID", OrganizationID);
            SqlParameter _ClientID = new SqlParameter("@ClientID", ClientID);
            return Context.Database.SqlQuery<BLModel.About>(Constant.StoredProcedureConst.AboutUsRepositoryProcedure.GetAllAboutUsByOrganizationID, _OrganizationID, _ClientID).ToList();
        }
    }
}