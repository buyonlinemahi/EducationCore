using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace HCRGUniversity.Core.Data.SqlServer.Repository
{
    public class DeliveryTermRepository : BaseRepository<DeliveryTerm, HCRGUniversityDBContext>, IDeliveryTermRepository
    {
        public DeliveryTermRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }
        public IEnumerable<DeliveryTerm> GetAllDeliveryTermsAccordingToClientID(int ClientID)
        {
            SqlParameter _ClientID = new SqlParameter("@ClientID", ClientID);
            return Context.Database.SqlQuery<DeliveryTerm>(Constant.StoredProcedureConst.DeliveryTermRepositoryProcedure.GetAllDeliveryTermsAccordingToClientID, _ClientID);
        }
    }
}
