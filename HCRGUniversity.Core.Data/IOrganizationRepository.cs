using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;

namespace HCRGUniversity.Core.Data
{
    public interface IOrganizationRepository : IBaseRepository<Organization>
    {
        IEnumerable<Menu> GetOrganizationMenuByOrganizationID(int organizationID);
    }
}
