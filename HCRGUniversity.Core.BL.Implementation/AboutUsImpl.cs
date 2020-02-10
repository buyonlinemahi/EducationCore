using HCRGUniversity.Core.Data;
using Omu.ValueInjecter;
using System.Collections.Generic;
using System.Linq;
using BLModel = HCRGUniversity.Core.BL.Model;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL.Implementation
{
    public class AboutUsImpl : IAboutUs
    {
        private readonly IAboutUsRepository _aboutUsRepository;
        public AboutUsImpl(IAboutUsRepository aboutUsRepository)
        {
            _aboutUsRepository = aboutUsRepository;
        }
        public int AddAboutUs(BLModel.About aboutUs)
        {
            return _aboutUsRepository.Add((DLModel.About)new DLModel.About().InjectFrom(aboutUs)).AboutUsID;
        }

        public int UpdateAboutUs(BLModel.About aboutUs)
        {
            return _aboutUsRepository.Update((DLModel.About)new DLModel.About().InjectFrom(aboutUs));
        }
        public void DeleteAboutUs(int aboutUsID)
        {
            _aboutUsRepository.Delete(_aboutUsRepository.GetById(aboutUsID));
        }
        public IEnumerable<BLModel.About> getAll(int _organizationID)
        {
            IEnumerable<BLModel.About> _aboutUs = _aboutUsRepository.GetAll(rk => rk.OrganizationID == _organizationID).Select(aboutus => new BLModel.About().InjectFrom(aboutus)).Cast<BLModel.About>().OrderBy(about => about.AboutUsID).ToList();
            return _aboutUs;
        }
        //*******************Lazy binding
        public BLModel.Paged.AboutUs GetAllPagedAboutus(int skip, int take, int _organizationID)
        {
            return new BLModel.Paged.AboutUs
            {
                TotalCount = _aboutUsRepository.GetAll(rk=>rk.OrganizationID==_organizationID).Count(),
                AboutUsRecords = _aboutUsRepository.GetAll(rk=>rk.OrganizationID==_organizationID).Skip(skip).Take(take).Select(aboutUs => (BLModel.About)new BLModel.About().InjectFrom(aboutUs)).ToList()
                
                //TotalCount = _aboutUsRepository.GetAboutUsCount(_organizationID),
                //AboutUsRecords = _aboutUsRepository.GetAllPagedAboutUs(skip, take, _organizationID).Select(aboutUs => (BLModel.Abouti)new BLModel.Abouti().InjectFrom(aboutUs)).ToList()
            };
        }


        public IEnumerable<BLModel.About> GetAllAboutUsByOrganizationID(int OrganizationID, int ClientID)
        {
            return _aboutUsRepository.GetAllAboutUsByOrganizationID(OrganizationID, ClientID);
        }
    }
}