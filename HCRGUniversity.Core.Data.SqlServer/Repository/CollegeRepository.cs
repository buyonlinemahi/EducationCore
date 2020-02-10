using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
namespace HCRGUniversity.Core.Data.SqlServer.Repository
{
    public class CollegeRepository : BaseRepository<College, HCRGUniversityDBContext>, ICollegeRepository
    {
        public CollegeRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }

        public IEnumerable<College> GetAllPagedCollege(int skip, int take)
        {
            return dbset.ToArray().OrderByDescending(o => o.CollegeID).Skip(skip).Take(take);    
        }

        public int GetCollegeCount()
        {
            return dbset.Count();
        }

        public IEnumerable<BL.Model.College> GetAllCollegeByClientID(int ClientID)
        {
            SqlParameter _clientID = new SqlParameter("@ClientID", ClientID);
            return Context.Database.SqlQuery<BL.Model.College>(Constant.StoredProcedureConst.CollegeRepositoryProcedure.GetAllCollegeByClientID, _clientID);
        }

        public IEnumerable<BL.Model.College> GetAllCollegeWeb(int OrganizationID)
        {
            SqlParameter _organizationID = new SqlParameter("@OrganizationID", OrganizationID);
            return Context.Database.SqlQuery<BL.Model.College>(Constant.StoredProcedureConst.CollegeRepositoryProcedure.GetAllCollegeByOrganizationID, _organizationID);
        }
        public IEnumerable<BL.Model.College> GetAllCollegeByOrganizationID(int _organizationID)
        {
            SqlParameter organizationID = new SqlParameter("@OrganizationID", _organizationID);
            return Context.Database.SqlQuery<BL.Model.College>(Constant.StoredProcedureConst.CollegeRepositoryProcedure.GetAllCollegeByOrganizationID, organizationID);
        }

    }
}
