using HCRGUniversity.Core.BL;
using HCRGUniversity.Core.BL.Implementation;
using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreBusinessTierTest
{
    [TestClass]
    public class EducationProfessionTest
    {
        private IEducationProfessionRepository _educationProfessionRepository;
        private IEducationProfession _educationProfessionBL;
        private HCRGUniversity.Core.Data.Model.EducationProfession DLModel = new HCRGUniversity.Core.Data.Model.EducationProfession();

        [TestInitialize]
        public void EducationProfessionInitialize()
        {
            _educationProfessionRepository = new EducationProfessionRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _educationProfessionBL = new EducationProfessionImpl(_educationProfessionRepository);
        }

        [TestMethod]
        public void AddEducationProfession()
        {
            DLModel.EducationID = 1;
            DLModel.ProfessionID = 1;
            int result = _educationProfessionBL.AddEducationProfession(DLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }
        [TestMethod]
        public void UpdateProfession()
        {
            DLModel.EducationID = 1;
            DLModel.ProfessionID = 2;
            DLModel.EducationProfessionID = 2;
            int result = _educationProfessionBL.UpdateEducationProfession(DLModel);
            Assert.IsTrue(result > 0, "Unable to update");
        }
    }
}