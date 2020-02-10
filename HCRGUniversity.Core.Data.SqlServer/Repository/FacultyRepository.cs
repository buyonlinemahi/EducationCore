using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace HCRGUniversity.Core.Data.SqlServer.Repository
{
    public class FacultyRepository : BaseRepository<Faculty, HCRGUniversityDBContext>, IFacultyRepository
    {
        public FacultyRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }


        public IEnumerable<Faculty> GetFacultyAll(int skip, int take, int organizationID)
        {
            SqlParameter _skip = new SqlParameter("@Skip", skip);
            SqlParameter _take = new SqlParameter("@Take", take);
            SqlParameter _organizationID = new SqlParameter("@OrganizationID", organizationID);
            return Context.Database.SqlQuery<Faculty>(Constant.StoredProcedureConst.FacultyRepositoryProcedure.GetPagedFaculty, _skip, _take, _organizationID);
        }

        public IEnumerable<HCRGUniversity.Core.BL.Model.Faculty> GetAllFacultiesByOrganizationID(int skip, int take, int organizationID, int ClientID)
        {
            SqlParameter _skip = new SqlParameter("@Skip", skip);
            SqlParameter _take = new SqlParameter("@Take", take);
            SqlParameter _organizationID = new SqlParameter("@OrgID", organizationID);
            SqlParameter _ClientID = new SqlParameter("@ClientID", ClientID);
            return Context.Database.SqlQuery<HCRGUniversity.Core.BL.Model.Faculty>(Constant.StoredProcedureConst.FacultyRepositoryProcedure.GetAllFacultiesByOrganizationID, _skip, _take, _organizationID, _ClientID).ToList();
        }

        public int GetAllFacultiesByOrganizationIDCount(int organizationID, int ClientID)
        {
            SqlParameter _organizationID = new SqlParameter("@OrgID", organizationID);
            SqlParameter _ClientID = new SqlParameter("@ClientID", ClientID);
            return Context.Database.SqlQuery<int>(Constant.StoredProcedureConst.FacultyRepositoryProcedure.GetAllFacultiesByOrganizationIDCount, _organizationID, _ClientID).First();
        }        
    }
}
