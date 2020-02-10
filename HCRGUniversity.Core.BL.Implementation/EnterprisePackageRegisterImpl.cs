using HCRGUniversity.Core.Data;
using Omu.ValueInjecter;
using System.Collections.Generic;
using System.Linq;
using BLModel = HCRGUniversity.Core.BL.Model;
using DLModel = HCRGUniversity.Core.Data.Model;
namespace HCRGUniversity.Core.BL.Implementation
{
    public class EnterprisePackageRegisterImpl : IEnterprisePackageRegister
    {
        private readonly IEnterprisePackageRegisterRepository _EnterprisePackageRegisterRepository;
        public EnterprisePackageRegisterImpl(IEnterprisePackageRegisterRepository EnterprisePackageRegisterRepository)
        {
            _EnterprisePackageRegisterRepository = EnterprisePackageRegisterRepository;
        }

        public int addEnterprisePackageRegister(DLModel.EnterprisePackageRegister _EnterprisePackageRegister)
        {
            _EnterprisePackageRegister.EPRCreatedDate = System.DateTime.Now;
            return _EnterprisePackageRegisterRepository.Add((DLModel.EnterprisePackageRegister)new DLModel.EnterprisePackageRegister().InjectFrom(_EnterprisePackageRegister)).EPRID;
        }

        public int updateEnterprisePackageRegister(DLModel.EnterprisePackageRegister _EnterprisePackageRegister)
        {
            return _EnterprisePackageRegisterRepository.Update((DLModel.EnterprisePackageRegister)new DLModel.EnterprisePackageRegister().InjectFrom(_EnterprisePackageRegister));
        }
        public void deleteEnterprisePackageRegister(int id)
        {
            _EnterprisePackageRegisterRepository.Delete(getEnterprisePackageRegisterByID(id));
        }

        public DLModel.EnterprisePackageRegister getEnterprisePackageRegisterByID(int id)
        {
            return (DLModel.EnterprisePackageRegister)new DLModel.EnterprisePackageRegister().InjectFrom(_EnterprisePackageRegisterRepository.GetById(id));
        }

        public BLModel.Paged.EnterprisePackageRegisters GetAllEnterprisePackageRegisters(int skip, int take, int organizationID)
        {
            return new BLModel.Paged.EnterprisePackageRegisters
            {
                EnterprisePackageRegisterDetails = _EnterprisePackageRegisterRepository.GetEnterprisePackageRegisterAll(skip, take, organizationID).Select(enterprisePackageRegisterSearchResult => new DLModel.EnterprisePackageRegister().InjectFrom(enterprisePackageRegisterSearchResult)).Cast<DLModel.EnterprisePackageRegister>().ToList(),
                TotalCount = _EnterprisePackageRegisterRepository.GetAll().Count()
            };
        }

        //public DLModel.EnterprisePackageRegister getEnterprisePackageRegisterByUserID(int userID)
        //{
        //    return _EnterprisePackageRegisterRepository.GetAll(rk => rk.UserID == userID).SingleOrDefault();
        //}
        public IEnumerable<BLModel.EnterprisePackageRegister> GetAllEnterprisePackageRegistersByOrganizationID(int OrganizationID)
        {
            return _EnterprisePackageRegisterRepository.GetAllEnterprisePackageRegistersByOrganizationID(OrganizationID);
        }
    }
}
