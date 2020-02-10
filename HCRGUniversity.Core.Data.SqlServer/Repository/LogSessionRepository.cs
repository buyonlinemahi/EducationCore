
using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
namespace HCRGUniversity.Core.Data.SqlServer.Repository
{
    public class LogSessionRepository : BaseRepository<LogSession, HCRGUniversityDBContext>, ILogSessionRepository
    {
        public LogSessionRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }
        public IEnumerable<LogSessionDetail> GetLogSessionByUserName(string username, int skip, int take,int organizationId)
        {
            SqlParameter _username = new SqlParameter("@username", username);
            SqlParameter _skip = new SqlParameter("@skip", skip);
            SqlParameter _take = new SqlParameter("@take", take);
            SqlParameter _orgID = new SqlParameter("@OrganizationID",organizationId);
            return Context.Database.SqlQuery<LogSessionDetail>(Constant.StoredProcedureConst.LogSessionRepositoryProcedure.GetLogSessionByUserName, _username, _skip, _take, _orgID);
        }

        public int GetLogSessionByUserNameCount(string username,int organizationId)
        {
            SqlParameter _username = new SqlParameter("@username", username);
            SqlParameter _orgID = new SqlParameter("@OrganizationID", organizationId);
            return Context.Database.SqlQuery<int>(Constant.StoredProcedureConst.LogSessionRepositoryProcedure.GetLogSessionByUserNameCount, _username, _orgID).First();
        }
      
    }
}
