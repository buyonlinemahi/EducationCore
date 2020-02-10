using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.Model;
using Omu.ValueInjecter;
using System.Collections.Generic;
using System.Linq;
using BLModel = HCRGUniversity.Core.BL.Model;
using DlModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL.Implementation
{
    public class EducationCredentialImpl : IEducationCredential
    {
        private readonly IEducationCredentialRepository _educationCredentialRepository;
        private readonly IAccreditorRepository _accreditorRepository;
        public EducationCredentialImpl(IEducationCredentialRepository educationCredentialRepository, IAccreditorRepository accreditorRepository)
        {
            _educationCredentialRepository = educationCredentialRepository;
            _accreditorRepository = accreditorRepository;
        }

        //----------Accreditor
        public int AddAccreditor(DlModel.Accreditor accreditor)
        {
            return _accreditorRepository.Add(accreditor).AccreditorID;
        }
        public int UpdateAccreditor(DlModel.Accreditor accreditor)
        {
            return _accreditorRepository.Update(accreditor);
        }
        public void DeleteAccreditor(int _accreditorID, bool isActive)
        {
            DlModel.Accreditor _acc = new Accreditor
            {
                AccreditorID = _accreditorID,
                IsActive = isActive
            };
            _accreditorRepository.Update(_acc, acc => acc.IsActive);
        }
        public IEnumerable<DlModel.Accreditor> getAll()
        {
            IEnumerable<DlModel.Accreditor> _Accreditor = _accreditorRepository.GetAll(accreditor => (accreditor.IsActive != false)).OrderBy(accreditor => accreditor.AccreditorID).ToList();
            return _Accreditor;
        }
        public BLModel.Paged.Accreditor GetAllPagedAccreditor(int skip, int take)
        {
            return new BLModel.Paged.Accreditor
            {
                AccreditorRecords = _accreditorRepository.GetAll().OrderByDescending(accreditor => accreditor.AccreditorID).Skip(skip).Take(take).ToList(),
                TotalCount = (_accreditorRepository.GetAll()).Count()
            };
        }

        public IEnumerable<BLModel.Accreditor> GetAllAccreditorsByOrganizationID(int clientID, int orgID)
        {
            return _accreditorRepository.GetAllAccreditorsByOrganizationID(clientID, orgID);
        }
        //---EducationCredential
        public int AddEducationCredential(DlModel.EducationCredential educationCredential)
        {
            return _educationCredentialRepository.Add(educationCredential).CredentialID;
        }
        public int UpdateEducationCredential(DlModel.EducationCredential educationCredential)
        {
            return _educationCredentialRepository.Update(educationCredential);
        }
        public void DeleteEducationCredential(int _credentialID, bool isActive)
        {
            DlModel.EducationCredential _edu = new EducationCredential
            {
                CredentialID = _credentialID,
                IsActive = isActive
            };
            _educationCredentialRepository.Update(_edu, hp => hp.IsActive);
        }

        public EducationCredential GetEducationCredentialByID(int _credentialID)
        {
            return _educationCredentialRepository.GetById(_credentialID);
        }

        public IEnumerable<EducationCredential> GetEducationCredentialByEducationID(int _educationID)
        {
            return _educationCredentialRepository.GetAll(educationCredential => (educationCredential.EducationID == _educationID) && (educationCredential.IsActive != false)).OrderBy(educationCredential => educationCredential.CredentialID).ToList();
        }

        public IEnumerable<BLModel.EducationCredential> GetEducationCredentialDetailByEducationID(int _educationID)
        {
            return (from _edu in _educationCredentialRepository.GetDbSet().ToList()
                       join _accre in _accreditorRepository.GetDbSet().ToList()
                       on _edu.AccreditorID equals _accre.AccreditorID
                       where _edu.EducationID == _educationID
                       select new {_edu.AccreditorID,
                           _edu.CertificateMessage,
                           _edu.CredentialType,
                           _edu.CredentialID,
                           _edu.CredentialProgram,
                           _edu.CredentialUnit,
                           _edu.EducationID,
                           _edu.IsActive,
                           _accre.AccreditorName }).Select(hp=>new BLModel.EducationCredential().InjectFrom(hp)).Cast<BLModel.EducationCredential>().ToList();

        }
    }
}
