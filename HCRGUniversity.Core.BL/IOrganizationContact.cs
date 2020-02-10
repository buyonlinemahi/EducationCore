using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;
namespace HCRGUniversity.Core.BL
{
    public interface IOrganizationContact
    {
        int AddOrganizationContact(OrganizationContact OrganizationContact);
        int UpdateOrganizationContact(OrganizationContact OrganizationContact);
        void DeleteOrganizationContact(int OrganizationContactID);
        IEnumerable<BLModel.OrganizationContact> GetOrganizationContactByOrganizationID(int _organizationID, int ClientID);
        BLModel.OrganizationContact GetSingleOrgContactByOrgID(int organizationID);
        OrganizationContact GetOrganizationContactByID(int orgContactID);
    }
}
