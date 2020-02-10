using HCRGUniversity.Core.Data;
using Omu.ValueInjecter;
using System.Collections.Generic;
using System.Linq;
using BLModel = HCRGUniversity.Core.BL.Model;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL.Implementation
{
    public class CertificationTitleOptionImpl : ICertificationTitleOption
    {
        private readonly ICertificationTitleOptionRepository _certificationTitelOptionRepository;
        private readonly IEducationRepository _eduRepository;

        public CertificationTitleOptionImpl(ICertificationTitleOptionRepository certificationTitelOptionRepository,IEducationRepository eduRepository)
        {
            _certificationTitelOptionRepository = certificationTitelOptionRepository;
             _eduRepository = eduRepository;
        }

        public int AddCertificationTitleOption(DLModel.CertificationTitleOption _certificationTitleOption)
        {
            return _certificationTitelOptionRepository.Add((DLModel.CertificationTitleOption)new DLModel.CertificationTitleOption().InjectFrom(_certificationTitleOption)).CertificationTitleOptionID;
        }

        public int UpdateCertificationTitleOption(DLModel.CertificationTitleOption _certificationTitleOption)
        {
            return _certificationTitelOptionRepository.Update((DLModel.CertificationTitleOption)new DLModel.CertificationTitleOption().InjectFrom(_certificationTitleOption));
        }

        public DLModel.CertificationTitleOption GetCertificationTitleOptionsByID(int CertificationTitleOptionID)
        {
            return (_certificationTitelOptionRepository.GetById(CertificationTitleOptionID));
        }

        public DLModel.CertificationTitleOption GetCertificationTitleOptionsByEducationID(int _educationID)
        {
            return (_certificationTitelOptionRepository.GetAll(rk => rk.EducationId == _educationID)).SingleOrDefault();
        }

        public void DeleteCertificationTitleOption(int id)
        {
            _certificationTitelOptionRepository.Delete(GetCertificationTitleOptionsByID(id));
        }

        public IEnumerable<DLModel.CertificationTitleOption> GetCertificationTitleOptionsByALL()
        {
            return (_certificationTitelOptionRepository.GetAll());
        }

        public IEnumerable<DLModel.CourseNameDropDownList> GetCourseDropDownList(int organizationID)
        {
            return _certificationTitelOptionRepository.GetCourseNameDropDownList(organizationID);
        }

        public BLModel.Paged.CertificationTitleOption GetPagedCertificationTitleOption(int skip, int take)
        {
            var _certificationList = (from _cer in _certificationTitelOptionRepository.GetDbSet().ToList()
                                      join _edu in _eduRepository.GetDbSet().ToList()
                                      on _cer.EducationId equals _edu.EducationID
                                      select new
                                      {
                                          CertificationTitleOptionID = _cer.CertificationTitleOptionID,
                                          CertificationTitle = _cer.CertificationTitle,
                                          CertificationContent = _cer.CertificationContent,
                                          EducationId = _cer.EducationId,
                                          CourseName = _edu.CourseName
                                      }).OrderByDescending(cer => cer.CertificationTitleOptionID).ToList();


            return new BLModel.Paged.CertificationTitleOption
            {
                TotalCount = _certificationList.Count(),
                CertificationTitleOptionDetails = _certificationList.Select(certificationTitle => (BLModel.CertificationTitleOption)new BLModel.CertificationTitleOption().InjectFrom(certificationTitle)).Skip(skip).Take(take).ToList()
            };
        }
       
    }
}
