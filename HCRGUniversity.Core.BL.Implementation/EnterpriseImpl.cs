using HCRGUniversity.Core.Data;
using System.Collections.Generic;
using System.Linq;
using BLModel = HCRGUniversity.Core.BL.Model;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL.Implementation
{
    public class EnterpriseImpl : IEnterprise
    {
        private readonly IEnterpriseRepository _enterpriseRepository;

        public EnterpriseImpl(IEnterpriseRepository enterpriseRepository)
        {
            _enterpriseRepository = enterpriseRepository;
        }

        public int addEnterprise(DLModel.Enterprise enterprise)
        {
            return _enterpriseRepository.Add(enterprise).EnterpriseID;
        }
        public int updateEnterprise(DLModel.Enterprise enterprise)
        {
            return _enterpriseRepository.Update(enterprise);
        }
        public DLModel.Enterprise getEnterpriseByID(int _id)
        {
            return _enterpriseRepository.GetById(_id);
        }

        public void deleteEnterpriseByID(int _id)
        {
            _enterpriseRepository.Delete(getEnterpriseByID(_id));
        }

        public IEnumerable<DLModel.Enterprise> getEnterpriseAll(int _organizationID)
        {
            return _enterpriseRepository.GetAll(rk => rk.OrganizationID == _organizationID);
        }

        public BLModel.Paged.EnterpriseDetail getEnterpriseByEnterpriseClientName(string _searchtext, int _skip, int _take, int _organizationID)
        {
            return new BLModel.Paged.EnterpriseDetail
            {
                EnterpriseDetails = _enterpriseRepository.GetAll(rk => (rk.OrganizationID==_organizationID) && rk.EnterpriseClientName.Contains(_searchtext)).OrderBy(rk => rk.EnterpriseClientName).Skip(_skip).Take(_take).ToList(),
                TotalCount = _enterpriseRepository.GetAll(rk => (rk.OrganizationID == _organizationID) && rk.EnterpriseClientName.StartsWith(_searchtext)).Count()
            };
        }

    }

}
