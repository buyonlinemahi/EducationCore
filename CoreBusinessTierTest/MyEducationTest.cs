using HCRGUniversity.Core.BL;
using HCRGUniversity.Core.BL.Implementation;
using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CoreBusinessTierTest
{
    [TestClass]
    public class MyEducationTest
    {
        private IMyEducationRepository _myEducationRepository;
        private IMyEducationModuleRepository _myEducationModuleRepository;
        private IEducationModuleFileRepository _educationModuleFileRepository;
        private IMyEducation _myEducationBL;
        private HCRGUniversity.Core.Data.Model.MyEducationModule DLModel = new HCRGUniversity.Core.Data.Model.MyEducationModule();

        [TestInitialize]
        public void MyEducationInitialize()
        {
            _myEducationRepository = new MyEducationRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _myEducationModuleRepository = new MyEducationModuleRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _educationModuleFileRepository = new EducationModuleFileRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _myEducationBL = new MyEducationImpl(_myEducationRepository, _myEducationModuleRepository, _educationModuleFileRepository);
        }

        [TestMethod]
        public void GetMyEducationCompletedByUserID()
        {
            var result = _myEducationBL.GetMyEducationCompletedByUserIDPaged(128,0,50);
            Assert.IsTrue(result != null, "Unable to get");
        }
        [TestMethod]
        public void GetMyEducationInProgressByUserIDPaged()
        {
            var result = _myEducationBL.GetMyEducationInProgressByUserIDPaged(150, 0, 100);
            Assert.IsTrue(result != null, "Unable to get");
        }


        [TestMethod]
        public void GetMyEducationDetailByUserIDPaged()
        {
            var result = _myEducationBL.GetMyEducationDetailByUserIDPaged(229, 0, 100);
            Assert.IsTrue(result != null, "Unable to get");
        }


        [TestMethod]
        public void GetMyEducationModulesDetailsByMEID()
        {
            var result = _myEducationBL.GetMyEducationModulesDetailsByMEID(541, 176);
            Assert.IsTrue(result != null, "Unable to get");
        }
        [TestMethod]
        public void GetMyEducationModulesDetailByMEMID()
        {
            var result = _myEducationBL.GetMyEducationModulesDetailByMEMID(936);
            Assert.IsTrue(result != null, "Unable to get");
        }
        [TestMethod]
        public void UpdateMyEducationModuleTimeLeft()
        {
            _myEducationBL.UpdateMyEducationModuleTimeLeft(35,"2.5");
        }

        [TestMethod]
        public void UpdateMyEducationForCertificateByMEID()
        {
            _myEducationBL.UpdateMyEducationForCertificateByMEID(213, true, "sdfsdf.jpg");
        }

        [TestMethod]
        public void GetCertificateDetailByMEID()
        {
            var result = _myEducationBL.GetCertificateDetailByMEID(214);
            Assert.IsTrue(result != null, "Unable to get");
        }
        [TestMethod]
        public void UpdateMyEducationModule()
        {
            DLModel.Completed = true;

            DLModel.CompletedDate = DateTime.Now;
            DLModel.EducationModuleID = 803;
            DLModel.MEID = 242;
            DLModel.MEMID = 580;
            DLModel.TimeLeft = "00:00:00";

            int result = _myEducationBL.UpdateMyEducationModule(DLModel);
            Assert.IsTrue(result != null, "Unable to get");
        }
        [TestMethod]
        public void GetMyEducationByID()
        {
            var result = _myEducationBL.GetMyEducationByID(4);
            Assert.IsTrue(result != null, "Unable to get");
        }

    }
}