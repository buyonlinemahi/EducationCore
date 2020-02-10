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
    public class EnterprisePackageRegisterRepository : BaseRepository<EnterprisePackageRegister, HCRGUniversityDBContext>, IEnterprisePackageRegisterRepository
    {
        public EnterprisePackageRegisterRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }

        public IEnumerable<EnterprisePackageRegister> GetEnterprisePackageRegisterAll(int skip, int take, int organizationID)
        {
            SqlParameter _skip = new SqlParameter("@Skip", skip);
            SqlParameter _take = new SqlParameter("@Take", take);
            SqlParameter _organizationID = new SqlParameter("@OrganizationID", organizationID);
            return Context.Database.SqlQuery<EnterprisePackageRegister>(Constant.StoredProcedureConst.EnterprisePackageRegisterRepositoryProcedur.GetPagedEnterprisePackageRegisters, _skip, _take, _organizationID);
        }
        public IEnumerable<BLModel.EnterprisePackageRegister> GetAllEnterprisePackageRegistersByOrganizationID(int OrganizationID)
        {
            SqlParameter _OrganizationID = new SqlParameter("@OrganizationID", OrganizationID);
            return Context.Database.SqlQuery<BLModel.EnterprisePackageRegister>(Constant.StoredProcedureConst.EnterprisePackageRegisterRepositoryProcedur.GetAllEnterprisePackageRegistersByOrganizationID, _OrganizationID).ToList();
        }
    }
}
