using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HCRGUniversity.Core.Data.SqlServer.Repository
{
    public class OrganizationRepository : BaseRepository<Organization, HCRGUniversityDBContext>, IOrganizationRepository
    {
        public OrganizationRepository(IContextFactory<HCRGUniversityDBContext> contextFactory)
            : base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }
        public IEnumerable<Menu> GetOrganizationMenuByOrganizationID(int organizationID)
        {
            SqlParameter _organizationID = new SqlParameter("@OrganizationID", organizationID);
            return Context.Database.SqlQuery<Menu>(Constant.StoredProcedureConst.OrganizationRepository.GetOrganizationMenuByOrganizationID, _organizationID);
        }
    }
}
