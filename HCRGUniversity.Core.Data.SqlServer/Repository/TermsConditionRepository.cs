using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HCRGUniversity.Core.Data.SqlServer.Repository
{
    public class TermsConditionRepository : BaseRepository<TermsCondition, HCRGUniversityDBContext>, ITermsConditionRepository
    {
        public TermsConditionRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }
        public IEnumerable<TermsCondition> GetAllTermAndConditionsAccordingToClientID(int ClientID)
        {
            SqlParameter _ClientID = new SqlParameter("@ClientID", ClientID);
            return Context.Database.SqlQuery<TermsCondition>(Constant.StoredProcedureConst.TermsAndConditionsRepositoryProcedure.GetAllTermAndConditionsAccordingToClientID, _ClientID);
        }
    }
}
