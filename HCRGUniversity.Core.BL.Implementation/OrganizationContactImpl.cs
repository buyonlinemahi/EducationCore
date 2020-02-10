using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL.Implementation
{
    public class OrganizationContactImpl : IOrganizationContact
    {
        private readonly IOrganizationContactRepository _organizationContactRepository;
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationContactImpl(IOrganizationContactRepository organizationContactRepository, IOrganizationRepository organizationRepository)
        {
            _organizationContactRepository = organizationContactRepository;
            _organizationRepository = organizationRepository;
        }

        public int AddOrganizationContact(DLModel.OrganizationContact OrganizationContact)
        {
            return _organizationContactRepository.Add(OrganizationContact).OrganizationContactID;

        }

        public int UpdateOrganizationContact(DLModel.OrganizationContact OrganizationContact)
        {
            return _organizationContactRepository.Update(OrganizationContact);
        }

        public void DeleteOrganizationContact(int OrganizationContactID)
        {
            _organizationContactRepository.Delete(_organizationContactRepository.GetById(OrganizationContactID));
        }

        public IEnumerable<BLModel.OrganizationContact> GetOrganizationContactByOrganizationID(int _organizationID, int ClientID)
        {
            return _organizationContactRepository.GetOrganizationContactByOrganizationID(_organizationID, ClientID);
        }

        public BLModel.OrganizationContact GetSingleOrgContactByOrgID(int organizationID)
        {
            return _organizationContactRepository.GetSingleOrganizationContactByOrganizationID(organizationID);
        }
        public  OrganizationContact GetOrganizationContactByID(int orgContactID)
        {
            return _organizationContactRepository.GetById(orgContactID);
        }
    }   
}
