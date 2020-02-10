using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;
using DLModel = HCRGUniversity.Core.Data.Model;
namespace HCRGUniversity.Core.BL
{
    public interface IEnterprisePackageRegister
    {
        int addEnterprisePackageRegister(DLModel.EnterprisePackageRegister _EnterprisePackageRegister);
        int updateEnterprisePackageRegister(DLModel.EnterprisePackageRegister _EnterprisePackageRegister);
        void deleteEnterprisePackageRegister(int id);
        DLModel.EnterprisePackageRegister getEnterprisePackageRegisterByID(int id);
        BLModel.Paged.EnterprisePackageRegisters GetAllEnterprisePackageRegisters(int skip, int take,int organizationID);
        //EnterprisePackageRegister getEnterprisePackageRegisterByUserID(int userID);
        IEnumerable<BLModel.EnterprisePackageRegister> GetAllEnterprisePackageRegistersByOrganizationID(int OrganizationID); 
    }
}
