using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.Model;
using Omu.ValueInjecter;
using System.Collections.Generic;
using System.Linq;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL.Implementation
{
   public class OrganizationImpl:IOrganization
    {
       private readonly IOrganizationRepository _organizationRepository;

       public OrganizationImpl(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

       public int AddOrganization(DLModel.Organization organization)
       {
           if (_organizationRepository.GetAll().Count() == 0)
               organization.IsOrganizationAdmin = true;
           else
               organization.IsOrganizationAdmin = false;

           return _organizationRepository.Add(organization).OrganizationID;
       }

       public int UpdateOrganization(DLModel.Organization organization)
       {
           return _organizationRepository.Update(organization);
       }

       public void DeleteOrganization(int organizationID)
       {
           _organizationRepository.Delete(_organizationRepository.GetById(organizationID));
       }
       public IEnumerable<DLModel.Organization> getAllOrganization()
       {
           IEnumerable<DLModel.Organization> _organization = _organizationRepository.GetAll().Select(org => new DLModel.Organization().InjectFrom(org)).Cast<DLModel.Organization>().OrderBy(org => org.OrganizationName).ToList();
           return _organization;
       }

       public IEnumerable<DLModel.Organization> getAllOrganizationByOrganizationID(int organizationID)
       {
           IEnumerable<DLModel.Organization> _organization = _organizationRepository.GetAll(rk => rk.OrganizationID == organizationID).Select(org => new DLModel.Organization().InjectFrom(org)).Cast<DLModel.Organization>().OrderBy(org => org.OrganizationName).ToList();
           return _organization;
       }

       public Organization GetOrganizationByID(int organizationID)
       {
           return _organizationRepository.GetById(organizationID);
       }

       public IEnumerable<Menu> GetOrganizationMenuByOrganizationID(int organizationID)
       {
           return _organizationRepository.GetOrganizationMenuByOrganizationID(organizationID);
       }       

    }
}
