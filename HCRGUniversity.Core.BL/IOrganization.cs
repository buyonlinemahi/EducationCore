using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;

namespace HCRGUniversity.Core.BL
{
    public interface IOrganization
    {
        int AddOrganization(Organization organization);
        int UpdateOrganization(Organization organization);
        void DeleteOrganization(int organizationID);
        IEnumerable<Organization> getAllOrganization();
        IEnumerable<Organization> getAllOrganizationByOrganizationID(int organizationID);
        Organization GetOrganizationByID(int organizationID);
        IEnumerable<Menu> GetOrganizationMenuByOrganizationID(int organizationID);
    }
}
