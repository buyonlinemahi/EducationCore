using HCRGUniversity.Core.BL;
using HCRGUniversity.Core.BL.Implementation;
using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CoreBusinessTierTest
{
    [TestClass]
    public class CollegeTest
    {
        private ICollegeRepository _collegeRepository;
        private IOrganizationRepository _organizationRepository;
        private ICollege _collegeBL;
        private HCRGUniversity.Core.BL.Model.College BLModel = new HCRGUniversity.Core.BL.Model.College();

        [TestInitialize]
        public void CollegeInitialize()
        {
            _collegeRepository = new CollegeRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _organizationRepository = new OrganizationRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _collegeBL = new CollegeImpl(_collegeRepository, _organizationRepository);
        }

        [TestMethod]
        public void AddCollege()
        {
            BLModel.CollegeName = "testing tesing";
            int result = _collegeBL.AddCollege(BLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }
        [TestMethod]
        public void UpdateCollege()
        {
            BLModel.CollegeName = "testing tesing af asdf";
            BLModel.CollegeID = 90;
            BLModel.IsActive = false;
            int result = _collegeBL.UpdateCollege(BLModel);
            Assert.IsTrue(result > 0, "Unable to update");
        }

        [TestMethod]
        public void DeleteCollege()
        {
            _collegeBL.DeleteCollege(156,true);
        }

        [TestMethod]
        public void getAllCollege()
        {
            IEnumerable<HCRGUniversity.Core.BL.Model.College> college = _collegeBL.getAllCollege(1);
            Assert.IsTrue(college != null, "Unable to get");
        }
        [TestMethod]
        public void getCollegeByID()
        {
            HCRGUniversity.Core.BL.Model.College college = _collegeBL.GetCollageByID(2);
            Assert.IsTrue(college != null, "Unable to get");
        }

        [TestMethod]
        public void GetAllPagedCollege()
        {
            var college = _collegeBL.GetAllPagedCollege(0, 10,1);
            Assert.IsTrue(college != null, "Unable to find");
        }
        [TestMethod]
        public void GetAllCollegeWeb()
        {
            IEnumerable<HCRGUniversity.Core.BL.Model.College> college = _collegeBL.GetAllCollegeWeb(100);
            Assert.IsTrue(college != null, "Unable to get");
        }
    }
}