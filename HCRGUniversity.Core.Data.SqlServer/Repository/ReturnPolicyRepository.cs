using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HCRGUniversity.Core.Data.SqlServer.Repository
{
    public class ReturnPolicyRepository : BaseRepository<ReturnPolicy, HCRGUniversityDBContext>, IReturnPolicyRepository
    {
        public ReturnPolicyRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }
        public IEnumerable<ReturnPolicy> GetAllReturnPolicysAccordingToClientID(int ClientID)
        {
            SqlParameter _ClientID = new SqlParameter("@ClientID", ClientID);
            return Context.Database.SqlQuery<ReturnPolicy>(Constant.StoredProcedureConst.ReturnPolicyRepositoryProcedure.GetAllReturnPolicysAccordingToClientID, _ClientID);
        }
    }
}
