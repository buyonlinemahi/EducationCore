using HCRGUniversity.Core.BL;
using HCRGUniversity.Core.BL.Implementation;
using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CoreBusinessTierTest
{
    [TestClass]
    public class ProfessionTest
    {
        private IProfessionRepository _professionRepository;
        private IOrganizationRepository _organizationRepository;
        private IProfession _professionBL;
        private HCRGUniversity.Core.Data.Model.Profession DLModel = new HCRGUniversity.Core.Data.Model.Profession();

        [TestInitialize]
        public void ProfessionInitialize()
        {
            _professionRepository = new ProfessionRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());

            _organizationRepository = new OrganizationRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _professionBL = new ProfessionImpl(_professionRepository, _organizationRepository);
        }

        [TestMethod]
        public void AddProfession()
        {
            DLModel.ProfessionTitle = "testing tesing";
            DLModel.ClientID = 128;
            int result = _professionBL.AddProfession(DLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }

        [TestMethod]
        public void UpdateProfession()
        {
            DLModel.ProfessionTitle = "testing tesing af asdf";
            DLModel.IsActive = true;
            DLModel.ProfessionID = 1;
            int result = _professionBL.UpdateProfession(DLModel);
            Assert.IsTrue(result > 0, "Unable to update");
        }

        [TestMethod]
        public void getAllProfession()
        {
            IEnumerable<HCRGUniversity.Core.Data.Model.Profession> profession = _professionBL.getAllProfession(1);
            Assert.IsTrue(profession != null, "Unable to get");
        }

        [TestMethod]
        public void getAllProfessionActive()
        {
            IEnumerable<HCRGUniversity.Core.Data.Model.Profession> profession = _professionBL.GetAllProfessionWebActiveWeb(100);
            Assert.IsTrue(profession != null, "Unable to get");
        }

        [TestMethod]
        public void getProfessionByID()
        {
            HCRGUniversity.Core.Data.Model.Profession profession = _professionBL.GetProfessionByID(2);
            Assert.IsTrue(profession != null, "Unable to get");
        }

        [TestMethod]
        public void GetProfessionsByCollegeID()
        {
            IEnumerable<HCRGUniversity.Core.Data.Model.Profession> profession = _professionBL.GetProfessionsByCollegeID(61);
            Assert.IsTrue(profession != null, "Unable to get");
        }

        [TestMethod]
        public void GetProfessionNotAssociateWithEducation()
        {
            IEnumerable<HCRGUniversity.Core.Data.Model.Profession> profession = _professionBL.GetProfessionNotAssociateWithEducation(61);
            Assert.IsTrue(profession != null, "Unable to get");
        }

        [TestMethod]
        public void GetAllPagedProfession()
        {
            var profession = _professionBL.GetAllPagedProfession(0, 10,1);
            Assert.IsTrue(profession != null, "Unable to find");
        }

        [TestMethod]
        public void GetAllPagedProfessionByOrganizationID()
        {
            var profession = _professionBL.GetAllPagedProfessionByOrganizationID(0, 10, 1);
            Assert.IsTrue(profession != null, "Unable to find");
        }
    }
}