using HCRGUniversity.Core.BL;
using HCRGUniversity.Core.BL.Implementation;
using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CoreBusinessTierTest
{
    [TestClass]
   public class EducationCredentialTest
    {
        private IEducationCredentialRepository _educationCredentialRepository;
        private IAccreditorRepository _accreditorRepository;
        private IEducationCredential _educationCredentialBL;
        private HCRGUniversity.Core.Data.Model.EducationCredential DLModel = new HCRGUniversity.Core.Data.Model.EducationCredential();
        private HCRGUniversity.Core.Data.Model.Accreditor DLModelAccreditor = new HCRGUniversity.Core.Data.Model.Accreditor();
        [TestInitialize]
        public void EducationFormatInitialize()
        {
            _educationCredentialRepository = new EducationCredentialRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _accreditorRepository = new AccreditorRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _educationCredentialBL = new EducationCredentialImpl(_educationCredentialRepository, _accreditorRepository);
        }

       // ----

        [TestMethod]
        public void AddEducationCredential()
        {
            DLModel.CertificateMessage = "testing dfg";
            DLModel.AccreditorID = 6;
            DLModel.CredentialProgram = "test";
            DLModel.CredentialUnit = 1;
            int result = _educationCredentialBL.AddEducationCredential(DLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }
        [TestMethod]
        public void UpdateEducationCredential()
        {
            DLModel.CertificateMessage = "testing";
            DLModel.AccreditorID = 6;
            DLModel.CredentialProgram = "test";
            DLModel.CredentialUnit = 1;
            DLModel.CredentialID = 2;
            int result = _educationCredentialBL.UpdateEducationCredential(DLModel);
            Assert.IsTrue(result > 0, "Unable to update");
        }
        [TestMethod]
        public void DeleteEducationCredential()
        {
            _educationCredentialBL.DeleteEducationCredential(10, true);
        }

        [TestMethod]
        public void GetEducationCredentialDetailByEducationID()
        {
            IEnumerable<HCRGUniversity.Core.BL.Model.EducationCredential> educationCredential = _educationCredentialBL.GetEducationCredentialDetailByEducationID(493);
            Assert.IsTrue(educationCredential != null, "Unable to get");
        }

     
      //  --
           [TestMethod]
        public void AddAccreditor()
        {
            DLModelAccreditor.AccreditorName = "testing";
            int result = _educationCredentialBL.AddAccreditor(DLModelAccreditor);
            Assert.IsTrue(result > 0, "Unable to Add");
        }
        [TestMethod]
        public void UpdateAccreditor()
        {
            DLModelAccreditor.AccreditorName = "testing dfg";
            DLModelAccreditor.AccreditorID = 1;
            int result = _educationCredentialBL.UpdateAccreditor(DLModelAccreditor);
            Assert.IsTrue(result > 0, "Unable to update");
        }

        [TestMethod]
        public void DeleteAccreditor()
        {
            _educationCredentialBL.DeleteAccreditor(137, false);
        }

        [TestMethod]
        public void getAll()
        {
            IEnumerable<HCRGUniversity.Core.Data.Model.Accreditor> accreditor = _educationCredentialBL.getAll();
            Assert.IsTrue(accreditor != null, "Unable to get");
        }

        [TestMethod]
        public void GetAllAccreditorsByOrganizationID()
        {
            IEnumerable<HCRGUniversity.Core.BL.Model.Accreditor> accreditor = _educationCredentialBL.GetAllAccreditorsByOrganizationID(14,1);
            Assert.IsTrue(accreditor != null, "Unable to get");
        }
        
        [TestMethod]
        public void getAllPagedAccreditor()
        {
            HCRGUniversity.Core.BL.Model.Paged.Accreditor accreditor = _educationCredentialBL.GetAllPagedAccreditor(10, 10);
            Assert.IsTrue(accreditor != null, "Unable to get");
        }
    }
}
