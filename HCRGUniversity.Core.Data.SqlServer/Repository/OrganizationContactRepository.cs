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
    public class OrganizationContactRepository : BaseRepository<OrganizationContact, HCRGUniversityDBContext>, IOrganizationContactRepository
    {

        public OrganizationContactRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }
        public BLModel.OrganizationContact GetSingleOrganizationContactByOrganizationID(int organizationID)
        {
            SqlParameter _organizationID = new SqlParameter("@OrganizationID", organizationID);
            return Context.Database.SqlQuery<BLModel.OrganizationContact>(Constant.StoredProcedureConst.ClientRepositoryProcedure.GetOrgSingleContactByOrgID, _organizationID).FirstOrDefault();
        }
        public IEnumerable<BLModel.OrganizationContact> GetOrganizationContactByOrganizationID(int organizationID, int ClientID)
        {
            SqlParameter _organizationID = new SqlParameter("@OrgID", organizationID);
            SqlParameter _ClientID = new SqlParameter("@ClientID", ClientID);
            return Context.Database.SqlQuery<BLModel.OrganizationContact>(Constant.StoredProcedureConst.ClientRepositoryProcedure.GetOrganizationContactByOrganizationID, _organizationID, _ClientID).ToList();
        }
    }
}
    