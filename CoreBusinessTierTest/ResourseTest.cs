using HCRGUniversity.Core.BL;
using HCRGUniversity.Core.BL.Implementation;
using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace CoreBusinessTierTest
{
    [TestClass]
    public class ResourseTest
    {
        private IResourceRepository _resourseRepository;
        private IResource _resourseBL;
        private HCRGUniversity.Core.Data.Model.Resource BLModel = new HCRGUniversity.Core.Data.Model.Resource();

        private HCRGUniversity.Core.Data.Model.TrainingAndSeminar BLModel_TAS = new HCRGUniversity.Core.Data.Model.TrainingAndSeminar();
        private ITrainingAndSeminarRepository _trainingAndSeminarRepository;

        private HCRGUniversity.Core.Data.Model.Accreditation BLModel_Acc = new HCRGUniversity.Core.Data.Model.Accreditation();
        private IAccreditationRepository _accreditationRepository;

        private HCRGUniversity.Core.Data.Model.Certification BLModel_Certification = new HCRGUniversity.Core.Data.Model.Certification();
        private ICertificationRepository _CertificationRepository;


        private HCRGUniversity.Core.Data.Model.PrivacyPolicy BLModel_Pol = new HCRGUniversity.Core.Data.Model.PrivacyPolicy();
        private IPrivacyPolicyRepository _privacyPolicyRepository;

        private HCRGUniversity.Core.Data.Model.TermsCondition BLModel_Pri = new HCRGUniversity.Core.Data.Model.TermsCondition();
        private ITermsConditionRepository _termsConditionRepository;
      

        private HCRGUniversity.Core.Data.Model.NewsLetter DLModel_NewsLetter = new HCRGUniversity.Core.Data.Model.NewsLetter();
        private HCRGUniversity.Core.BL.Model.NewsLetter BLModel_NewsLetter = new HCRGUniversity.Core.BL.Model.NewsLetter();
        private INewsLetterRepository _newsLetterRepository;


        private HCRGUniversity.Core.Data.Model.DeliveryTerm BLModel_DeliveryTerm = new HCRGUniversity.Core.Data.Model.DeliveryTerm();
        private IDeliveryTermRepository _deliveryTermRepository;

        private HCRGUniversity.Core.Data.Model.ReturnPolicy BLModel_ReturnPolicy = new HCRGUniversity.Core.Data.Model.ReturnPolicy();
        private IReturnPolicyRepository _returnPolicyRepository;

        private IOrganizationRepository _organizationRepository;


        [TestInitialize]
        public void ResourseInitialize()
        {
            _resourseRepository = new ResourseRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _trainingAndSeminarRepository = new TrainingAndSeminarRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _accreditationRepository = new AccreditationRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _CertificationRepository = new CertificationRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _termsConditionRepository = new TermsConditionRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _privacyPolicyRepository = new PrivacyPolicyRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _newsLetterRepository = new NewsLetterRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _returnPolicyRepository = new ReturnPolicyRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _deliveryTermRepository = new DeliveryTermRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _organizationRepository = new OrganizationRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _resourseBL = new ResourceImpl(_resourseRepository, _trainingAndSeminarRepository, _accreditationRepository, _privacyPolicyRepository, _termsConditionRepository, _newsLetterRepository, _returnPolicyRepository, _deliveryTermRepository, _CertificationRepository, _organizationRepository);
        }
        [TestMethod]
        public void getAllResource()
        {
            IEnumerable<HCRGUniversity.Core.Data.Model.Resource> resource = _resourseBL.getAllResource(1);
            Assert.IsTrue(resource != null, "Unable to get");
        }

        [TestMethod]
        public void AddTrainingAndSeminar()
        {

            BLModel_TAS.TrainingAndSeminarDesc = "TrainingAndSeminarDesc";
            int result = _resourseBL.AddTrainingAndSeminar(BLModel_TAS);
            Assert.IsTrue(result > 0, "Unable to Add");
        }

        [TestMethod]
        public void UpdateTrainingAndSeminar()
        {

            BLModel_TAS.TrainingAndSeminarDesc = "TrainingAndSeminarDesc2";
            BLModel_TAS.TrainingAndSeminarID = 1;
            int result = _resourseBL.UpdateTrainingAndSeminar(BLModel_TAS);
            Assert.IsTrue(result > 0, "Unable to Add");
        }
        [TestMethod]
        public void GetTrainingAndSeminar()
        {
            DLModel.TrainingAndSeminar _gettrainingAndSeminar = _resourseBL.GetTrainingAndSeminarAll(1);
            Assert.IsTrue(_gettrainingAndSeminar != null, "Unable to get");
        }
        [TestMethod]
        public void GetAllTrainingAndSeminarByOrganizationID()
        {
            IEnumerable<BLModel.TrainingAndSeminar> trainingAndSeminar = _resourseBL.GetAllTrainingAndSeminarByOrganizationID(1, 14);
            Assert.IsTrue(trainingAndSeminar != null, "Unable to get");
        }

        [TestMethod]
        public void GetAllCertificationsByOrganizationID()
        {
            IEnumerable<BLModel.Certification> certification = _resourseBL.GetAllCertificationsByOrganizationID(1, 14);
            Assert.IsTrue(certification != null, "Unable to get");
        }
        //Accreditation
        [TestMethod]
        public void AddAccreditation()
        {
            BLModel_Acc.AccreditationContent = "AccreditationDesc";
            int result = _resourseBL.AddAccreditation(BLModel_Acc);
            Assert.IsTrue(result > 0, "Unable to Add");
        }

        [TestMethod]
        public void UpdateAccreditation()
        {
            BLModel_Acc.AccreditationContent = "AccreditationDesc2";
            BLModel_Acc.AccreditationID = 1;
            int result = _resourseBL.UpdateAccreditation(BLModel_Acc);
            Assert.IsTrue(result > 0, "Unable to Add");
        }
        [TestMethod]
        public void GetAccreditation()
        {
            DLModel.Accreditation _gettrainingAndSeminar = _resourseBL.GetAccreditationAll(1);
            Assert.IsTrue(_gettrainingAndSeminar != null, "Unable to get");
        }

        [TestMethod]
        public void GetAllAccreditationsByOrganizationID()
        {
            IEnumerable<BLModel.Accreditation> accreditation = _resourseBL.GetAllAccreditationsByOrganizationID(0,14);
            Assert.IsTrue(accreditation != null, "Unable to get");
        }
        //Privacy
        [TestMethod]
        public void AddTermsCondition()
        {
            BLModel_Pri.TermsConditionContent = "PrivacyDesc";
            int result = _resourseBL.AddTermsCondition(BLModel_Pri);
            Assert.IsTrue(result > 0, "Unable to Add");
        }

        [TestMethod]
        public void UpdatepUpdatePrivacy()
        {
            BLModel_Pri.TermsConditionContent = "PrivacyDesc_Update";
            BLModel_Pri.TermsConditionID = 1;
            int result = _resourseBL.UpdateTermsCondition(BLModel_Pri);
            Assert.IsTrue(result > 0, "Unable to Update");
        }
        [TestMethod]
        public void GetPrivacyAll()
        {
            DLModel.TermsCondition _getPrivacy = _resourseBL.GetTermsConditionAll(1);
            Assert.IsTrue(_getPrivacy != null, "Unable to get");
        }

        //Policy
        [TestMethod]
        public void AddPrivacyPolicy()
        {
            BLModel_Pol.PrivacyPolicyContent = "PolicyDesc";
            int result = _resourseBL.AddPrivacyPolicy(BLModel_Pol);
            Assert.IsTrue(result > 0, "Unable to Add");
        }

        [TestMethod]
        public void UpdatePolicy()
        {
            BLModel_Pol.PrivacyPolicyContent = "PolicyDesc_Update";
            BLModel_Pol.PrivacyPolicyID = 1;
            int result = _resourseBL.UpdatePrivacyPolicy(BLModel_Pol);
            Assert.IsTrue(result > 0, "Unable to Update");
        }
        [TestMethod]
        public void GetPrivacyPolicyAll()
        {
            DLModel.PrivacyPolicy _getPolicy = _resourseBL.GetPrivacyPolicyAll(1);
            Assert.IsTrue(_getPolicy != null, "Unable to get");
        }
        [TestMethod]
        public void GetAllPrivacyPolicyAccordingToOrganizationID()
        {
            var policy = _resourseBL.GetAllPrivacyPolicyAccordingToOrganizationID(1, 14);
            Assert.IsTrue(policy != null, "Unable to get");
        }
        //[TestMethod]
        //public void GetAllNewsByOrganizationID()
        //{
        //    IEnumerable<BLModel.News> news = _newsBL.GetAllNewsByOrganizationID(100);
        //    Assert.IsTrue(news != null, "Unable to get");
        //}
      

        //NewsLetter
        [TestMethod]
        public void AddNewsLetter()
        {
            BLModel_NewsLetter.NewsLetterContent = "NewsLetterDesc";
            int result = _resourseBL.AddNewsLetter(DLModel_NewsLetter);
            Assert.IsTrue(result > 0, "Unable to Add");
        }
        [TestMethod]
        public void GetNewsLetterByClientID()
        {
            IEnumerable<BLModel.NewsLetter> news = _resourseBL.GetNewsLetterByClientID(14,100);
            Assert.IsTrue(news != null, "Unable to get");
        }

        [TestMethod]
        public void UpdateNewsLetter()
        {
            BLModel_NewsLetter.NewsLetterContent = "NewsLetterDesc_Update";
            BLModel_NewsLetter.NewsLetterID = 1;
            int result = _resourseBL.UpdateNewsLetter(DLModel_NewsLetter);
            Assert.IsTrue(result > 0, "Unable to Update");
        }
        [TestMethod]
        public void GetNewsLetterAll()
        {
            DLModel.NewsLetter _getNewsLetter = _resourseBL.GetNewsLetterAll(1);
            Assert.IsTrue(_getNewsLetter != null, "Unable to get");
        }

        #region Return Policy
        [TestMethod]
        public void AddReturnPolicy()
        {
            BLModel_ReturnPolicy.ReturnPolicyContent = "ReturnPolicyDesc";
            int result = _resourseBL.AddReturnPolicy(BLModel_ReturnPolicy);
            Assert.IsTrue(result > 0, "Unable to Add");
        }

        [TestMethod]
        public void UpdateReturnPolicy()
        {
            BLModel_ReturnPolicy.ReturnPolicyContent = "PolicyDesc_Update";
            BLModel_ReturnPolicy.ReturnPolicyID = 1;
            int result = _resourseBL.UpdateReturnPolicy(BLModel_ReturnPolicy);
            Assert.IsTrue(result > 0, "Unable to Update");
        }
        [TestMethod]
        public void GetReturnPolicyAll()
        {
            DLModel.ReturnPolicy _returnPolicy = _resourseBL.GetReturnPolicyAll(1);
            Assert.IsTrue(_returnPolicy != null, "Unable to get");
        }
        #endregion

        #region Delivery Term
        [TestMethod]
        public void AddDeliveryTermPolicy()
        {
            BLModel_DeliveryTerm.DeliveryTermContents = "DeliveryTermContents";
            int result = _resourseBL.AddDeliveryTerm(BLModel_DeliveryTerm);
            Assert.IsTrue(result > 0, "Unable to Add");
        }

        [TestMethod]
        public void UpdateDeliveryTermPolicy()
        {
            BLModel_DeliveryTerm.DeliveryTermContents = "PolicyDesc_Update";
            BLModel_DeliveryTerm.DeliveryTermID = 1;
            int result = _resourseBL.UpdateDeliveryTerm(BLModel_DeliveryTerm);
            Assert.IsTrue(result > 0, "Unable to Update");
        }
        [TestMethod]
        public void GetDeliveryTermPolicyAll()
        {
            DLModel.DeliveryTerm _getDeliveryTerm = _resourseBL.GetDeliveryTermAll(1);
            Assert.IsTrue(_getDeliveryTerm != null, "Unable to get");
        }
        #endregion
    }
}