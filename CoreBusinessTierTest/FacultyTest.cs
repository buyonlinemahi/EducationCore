using HCRGUniversity.Core.BL;
using HCRGUniversity.Core.BL.Implementation;
using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreBusinessTierTest
{
    [TestClass]
   public class FacultyTest
    {
        private IFacultyRepository _facultyRepository;
        private IOrganizationRepository _organizationRepository;
        private IFaculty _facutlyBL;

        private HCRGUniversity.Core.Data.Model.Faculty DLModel = new HCRGUniversity.Core.Data.Model.Faculty();

        [TestInitialize]
        public void FacutlyInitialize()
        {
            _facultyRepository = new FacultyRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _organizationRepository = new OrganizationRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _facutlyBL = new FacultyImpl(_facultyRepository, _organizationRepository);
        }

        [TestMethod]
        public void AddFaculty()
        {
            DLModel.FirstName = "testing tesing";
            DLModel.LastName = "Last name";
            DLModel.Email = "a@s.com";
            DLModel.Company = "compaly";
            DLModel.Phone = "4";
            DLModel.ProfessionalTitle = "prof";
            DLModel.AddressStreet = "street";
            DLModel.AddressFloor = "floor";
            DLModel.City = "city";
            DLModel.State = "CA";
            DLModel.Zip = "7878";
            DLModel.AreaOfExpertise = "area of s";
            DLModel.Topics = "topics";
            DLModel.Resume = "resume";
            int result = _facutlyBL.AddFaculty(DLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }

        [TestMethod]
        public void updateFaculty()
        {
            DLModel.FacultyID = 1;
            DLModel.FirstName = "testing tesing";
            DLModel.LastName = "Last tsst";
            DLModel.Email = "a@s.com";
            DLModel.Company = "compaly";
            DLModel.Phone = "1234567891";
            DLModel.ProfessionalTitle = "prof";
            DLModel.AddressStreet = "street";
            DLModel.AddressFloor = "floor";
            DLModel.City = "city";
            DLModel.State = "state";
            DLModel.Zip = "7878";
            DLModel.AreaOfExpertise = "area of s";
            DLModel.Topics = "topics";
            DLModel.Resume = "resume";
            int result = _facutlyBL.UpdateFaculty(DLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }

        [TestMethod]
        public void GetAllFaculties()
        {
            var getallFaculty = _facutlyBL.GetAllFaculties(0,10,1,14);
            Assert.IsTrue(_facutlyBL != null, "Unable to get");
        }

        [TestMethod]
        public void GetAllFacultiesByID()
        {
            HCRGUniversity.Core.Data.Model.Faculty faq = _facutlyBL.GetFacultyById(114);
            Assert.IsTrue(_facutlyBL != null, "Unable to get");
        }
    }
}
