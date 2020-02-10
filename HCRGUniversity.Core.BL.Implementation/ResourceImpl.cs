using HCRGUniversity.Core.Data;
using Omu.ValueInjecter;
using System.Collections.Generic;
using System.Linq;
using BLModel = HCRGUniversity.Core.BL.Model;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL.Implementation
{
    public class ResourceImpl : IResource
    {

        private readonly IResourceRepository _resourseRepository;
        private readonly ITrainingAndSeminarRepository _trainingAndSeminarRepository;
        private readonly IAccreditationRepository _accreditationRepository;
        private readonly IPrivacyPolicyRepository _privacyPolicyRepository;
        private readonly ITermsConditionRepository _termsConditionRepository;
        private readonly INewsLetterRepository _newsLetterRepository;
        private readonly IReturnPolicyRepository _returnPolicyRepository;
        private readonly IDeliveryTermRepository _deliveryTermRepository;
        private readonly ICertificationRepository _certificationRepository;
        
        private readonly IOrganizationRepository _organizationRepository;

         

        public ResourceImpl(IResourceRepository resourseRepository
            , ITrainingAndSeminarRepository trainingAndSeminarRepository
            , IAccreditationRepository accreditationRepository
            , IPrivacyPolicyRepository privacyPolicyRepository
            , ITermsConditionRepository termsConditionRepository
            , INewsLetterRepository newsLetterRepository
            ,IReturnPolicyRepository returnPolicyRepository
            , IDeliveryTermRepository deliveryTermRepository
            , ICertificationRepository certificationRepository
            , IOrganizationRepository organizationRepository)
        {
            _resourseRepository = resourseRepository;
            _trainingAndSeminarRepository = trainingAndSeminarRepository;
            _accreditationRepository = accreditationRepository;
            _privacyPolicyRepository = privacyPolicyRepository;
            _termsConditionRepository = termsConditionRepository;
            _newsLetterRepository = newsLetterRepository;
            _returnPolicyRepository = returnPolicyRepository;
            _deliveryTermRepository = deliveryTermRepository;
            _certificationRepository = certificationRepository;
            _organizationRepository = organizationRepository;
        }
        public IEnumerable<DLModel.Resource> getAllResource(int _organizationID)
        {
            IEnumerable<DLModel.Resource> _resource = _resourseRepository.GetAll(rk => rk.OrganizationID == _organizationID).Select(resource => new DLModel.Resource().InjectFrom(resource)).Cast<DLModel.Resource>().OrderBy(resource => resource.ResourceID).ToList();
            return _resource;
        }

      

        #region raining And Seminar
        public int AddTrainingAndSeminar(DLModel.TrainingAndSeminar _trainingAndSeminar)
        {
            return _trainingAndSeminarRepository.Add((DLModel.TrainingAndSeminar)new DLModel.TrainingAndSeminar().InjectFrom(_trainingAndSeminar)).TrainingAndSeminarID;
        }
        public int UpdateTrainingAndSeminar(DLModel.TrainingAndSeminar _trainingAndSeminar)
        {
            return _trainingAndSeminarRepository.Update((DLModel.TrainingAndSeminar)new DLModel.TrainingAndSeminar().InjectFrom(_trainingAndSeminar));
        }

        public DLModel.TrainingAndSeminar GetTrainingAndSeminarAll(int _organizationID)
        {
            return _trainingAndSeminarRepository.GetAll(rk => rk.OrganizationID == _organizationID).Select(tas => new DLModel.TrainingAndSeminar().InjectFrom(tas)).Cast<DLModel.TrainingAndSeminar>().SingleOrDefault();
        }
        public IEnumerable<BLModel.TrainingAndSeminar> GetAllTrainingAndSeminarByOrganizationID(int OrganizationID, int ClientID)
        {
            return _trainingAndSeminarRepository.GetAllTrainingAndSeminarByOrganizationID(OrganizationID, ClientID);
        }
        #endregion

      
        #region Accreditation
        public int AddAccreditation(DLModel.Accreditation _accreditation)
        {
            return _accreditationRepository.Add((DLModel.Accreditation)new DLModel.Accreditation().InjectFrom(_accreditation)).AccreditationID;
        }
        public int UpdateAccreditation(DLModel.Accreditation _accreditation)
        {
            return _accreditationRepository.Update((DLModel.Accreditation)new DLModel.Accreditation().InjectFrom(_accreditation));
        }

        public DLModel.Accreditation GetAccreditationAll(int _organizationID)
        {
            return _accreditationRepository.GetAll(rk => rk.OrganizationID == _organizationID).Select(acc => new DLModel.Accreditation().InjectFrom(acc)).Cast<DLModel.Accreditation>().SingleOrDefault();
        }

        public IEnumerable<BLModel.Accreditation> GetAllAccreditationsByOrganizationID(int OrganizationID, int ClientID)
        {
            return _accreditationRepository.GetAllAccreditationsByOrganizationID(OrganizationID, ClientID);
        }
        #endregion

       
        #region Privacy Policy
        public int AddPrivacyPolicy(DLModel.PrivacyPolicy _privacy)
        {
            return _privacyPolicyRepository.Add(_privacy).PrivacyPolicyID;
        }
        public int UpdatePrivacyPolicy(DLModel.PrivacyPolicy _privacy)
        {
            return _privacyPolicyRepository.Update(_privacy);
        }

        public DLModel.PrivacyPolicy GetPrivacyPolicyAll(int OrganizationID)
        {
            return _privacyPolicyRepository.GetAll(rk => rk.OrganizationID == OrganizationID).SingleOrDefault();
        }

        public DLModel.PrivacyPolicy GetPrivacyPolicyByID(int PrivacyPolicyID)
        {
            return (DLModel.PrivacyPolicy)new DLModel.PrivacyPolicy().InjectFrom(_privacyPolicyRepository.GetById(PrivacyPolicyID));
        }

        public IEnumerable<BLModel.PrivacyPolicy> GetAllPrivacyPolicyAccordingToOrganizationID(int OrganizationID, int ClientID)
        {
           return _privacyPolicyRepository.GetAllPrivacyPolicyAccordingToOrganizationID(OrganizationID, ClientID);
           
        }
        #endregion

        

        
        #region Terms and Condition
        public int AddTermsCondition(DLModel.TermsCondition _termsCondition)
        {
            return _termsConditionRepository.Add(_termsCondition).TermsConditionID;
        }
        public int UpdateTermsCondition(DLModel.TermsCondition _termsCondition)
        {
            return _termsConditionRepository.Update(_termsCondition);
        }

        public DLModel.TermsCondition GetTermsConditionAll(int ClientID)
        {
            return _termsConditionRepository.GetAll(rk => rk.ClientID == ClientID).SingleOrDefault();
        }

        public DLModel.TermsCondition GetTermsConditionByID(int TermsConditionID)
        {
            return (DLModel.TermsCondition)new DLModel.TermsCondition().InjectFrom(_termsConditionRepository.GetById(TermsConditionID));
        }

        public IEnumerable<DLModel.TermsCondition> GetAllTermAndConditionsAccordingToClientID(int ClientID)
        {
            return _termsConditionRepository.GetAllTermAndConditionsAccordingToClientID(ClientID);
        }
        #endregion

      
        #region NewsLetter
        public int AddNewsLetter(DLModel.NewsLetter _policy)
        {
            return _newsLetterRepository.Add(_policy).NewsLetterID;
        }
        public int UpdateNewsLetter(DLModel.NewsLetter _policy)
        {
            return _newsLetterRepository.Update(_policy);
        }

        public DLModel.NewsLetter GetNewsLetterAll(int _organizationID)
        {
            return _newsLetterRepository.GetAll(rk => rk.OrganizationID == _organizationID).SingleOrDefault();
        }

        public IEnumerable<BLModel.NewsLetter> GetNewsLetterByClientID(int clientID, int orgID)
        {
            return _newsLetterRepository.GetNewsLetterByClientID(clientID, orgID);

        }
        #endregion



        #region Return Policy
        public int AddReturnPolicy(DLModel.ReturnPolicy _returnPolicy)
        {
            return _returnPolicyRepository.Add(_returnPolicy).ReturnPolicyID;
        }
        public int UpdateReturnPolicy(DLModel.ReturnPolicy _returnPolicy)
        {
            return _returnPolicyRepository.Update(_returnPolicy);
        }

        public DLModel.ReturnPolicy GetReturnPolicyAll(int ClientID)
        {
            return _returnPolicyRepository.GetAll(rk => rk.ClientID == ClientID).SingleOrDefault();
        }

        public DLModel.ReturnPolicy GetReturnPolicyByID(int ReturnPolicyID)
        {
            return (DLModel.ReturnPolicy)new DLModel.ReturnPolicy().InjectFrom(_returnPolicyRepository.GetById(ReturnPolicyID));
        }

        public IEnumerable<DLModel.ReturnPolicy> GetAllReturnPolicysAccordingToClientID(int ClientID)
        {
            return _returnPolicyRepository.GetAllReturnPolicysAccordingToClientID(ClientID);
        }
        #endregion

        #region Delivery Term
        public int AddDeliveryTerm(DLModel.DeliveryTerm _deliveryTerm)
        {
            return _deliveryTermRepository.Add(_deliveryTerm).DeliveryTermID;
        }
        public int UpdateDeliveryTerm(DLModel.DeliveryTerm _deliveryTerm)
        {
            return _deliveryTermRepository.Update(_deliveryTerm);
        }

        public DLModel.DeliveryTerm GetDeliveryTermAll(int ClientID)
        {
            return _deliveryTermRepository.GetAll(rk => rk.ClientID == ClientID).SingleOrDefault();
        }

        public DLModel.DeliveryTerm GetDeliveryTermByID(int DeliveryTermID)
        {
            return (DLModel.DeliveryTerm)new DLModel.DeliveryTerm().InjectFrom(_deliveryTermRepository.GetById(DeliveryTermID));
        }

        public IEnumerable<DLModel.DeliveryTerm> GetAllDeliveryTermsAccordingToClientID(int ClientID)
        {
            return _deliveryTermRepository.GetAllDeliveryTermsAccordingToClientID(ClientID);
        }

        #endregion


        #region Certification
        public int AddCertification(DLModel.Certification _certification)
        {
            return _certificationRepository.Add((DLModel.Certification)new DLModel.Certification().InjectFrom(_certification)).CertificationID;
        }
        public int UpdateCertification(DLModel.Certification _certification)
        {
            return _certificationRepository.Update((DLModel.Certification)new DLModel.Certification().InjectFrom(_certification));
        }

        public DLModel.Certification GetCertificationAll(int _organizationID)
        {
            return _certificationRepository.GetAll(rk => rk.OrganizationID == _organizationID).Select(acc => new DLModel.Certification().InjectFrom(acc)).Cast<DLModel.Certification>().SingleOrDefault();
        }
        public IEnumerable<BLModel.Certification> GetAllCertificationsByOrganizationID(int OrganizationID, int ClientID)
        {
            return _certificationRepository.GetAllCertificationsByOrganizationID(OrganizationID, ClientID);
        }
        #endregion
    }
}
