using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.Data
{
    public interface IEnterprisePackageRegisterRepository : IBaseRepository<EnterprisePackageRegister>
    {
        IEnumerable<EnterprisePackageRegister> GetEnterprisePackageRegisterAll(int skip, int take, int organizationID);
        IEnumerable<BLModel.EnterprisePackageRegister> GetAllEnterprisePackageRegistersByOrganizationID(int OrganizationID);
    }
}
