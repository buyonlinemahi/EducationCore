using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using BLModel = HCRGUniversity.Core.BL.Model;
using System.Collections.Generic;

namespace HCRGUniversity.Core.Data
{
    public interface IOrganizationContactRepository : IBaseRepository<OrganizationContact>
    {
        IEnumerable<BLModel.OrganizationContact> GetOrganizationContactByOrganizationID(int _organizationID, int ClientID);
        BLModel.OrganizationContact GetSingleOrganizationContactByOrganizationID(int organizationID);
    }
}
