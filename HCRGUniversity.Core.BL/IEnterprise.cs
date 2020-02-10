using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL
{
    public interface IEnterprise
    {
        int addEnterprise(DLModel.Enterprise enterprise);
        int updateEnterprise(DLModel.Enterprise enterprise);
        DLModel.Enterprise getEnterpriseByID(int id);
        void deleteEnterpriseByID(int id);
        BLModel.Paged.EnterpriseDetail getEnterpriseByEnterpriseClientName(string _searchtext, int _skip, int _take, int _organizationID);
        IEnumerable<DLModel.Enterprise> getEnterpriseAll(int _organizationID);
    }
}
