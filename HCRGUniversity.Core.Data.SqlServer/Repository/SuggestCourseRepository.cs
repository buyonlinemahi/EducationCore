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
    public class SuggestCourseRepository : BaseRepository<SuggestCourse, HCRGUniversityDBContext>, ISuggestCourseRepository
    {
        public SuggestCourseRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }
        
        public IEnumerable<SuggestCourse> GetSuggestCourseAll(int skip, int take)
        {
            SqlParameter _skip = new SqlParameter("@Skip", skip);
            SqlParameter _take = new SqlParameter("@Take", take);
            return Context.Database.SqlQuery<SuggestCourse>(Constant.StoredProcedureConst.SuggestCourseProcedure.GetPagedSuggestCourse, _skip, _take);
        }
        public IEnumerable<BLModel.SuggestCourse> GetAllSuggestCoursesByOrganizationID(int clientID, int orgID)
        {
            SqlParameter _clientID = new SqlParameter("@ClientID", clientID);
            SqlParameter _orgID = new SqlParameter("@OrgID", orgID);
            return Context.Database.SqlQuery<BLModel.SuggestCourse>(Constant.StoredProcedureConst.SuggestCourseProcedure.GetAllSuggestCoursesByOrganizationID, _clientID,_orgID).ToList();
        }        
    }
}
