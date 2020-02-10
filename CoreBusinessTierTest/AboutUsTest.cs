using HCRGUniversity.Core.BL;
using HCRGUniversity.Core.BL.Implementation;
using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace CoreBusinessTierTest
{
    [TestClass]
    public class AboutUsTest
    {
        private IAboutUsRepository _aboutUsRepository;
        private IAboutUs _aboutUsBL;
        private HCRGUniversity.Core.BL.Model.About BLModel = new HCRGUniversity.Core.BL.Model.About();

        [TestInitialize]
        public void AboutUsInitialize()
        {
            _aboutUsRepository = new AboutUsRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _aboutUsBL = new AboutUsImpl(_aboutUsRepository);
        }

        [TestMethod]
        public void AddAboutUs()
        {
           
            BLModel.Description = "testing tesing testing tesing testing tesing";
            BLModel.OrganizationID = 1;
            int result = _aboutUsBL.AddAboutUs(BLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }
        [TestMethod]
        public void UpdateAboutUs()
        {
           
            BLModel.Description = "testing tesing testing tesing testing tesing asdf asdf sad";
            BLModel.AboutUsID = 2;
            int result = _aboutUsBL.UpdateAboutUs(BLModel);
            Assert.IsTrue(result > 0, "Unable to update");
        }

        [TestMethod]
        public void DeleteAboutUs()
        {
            _aboutUsBL.DeleteAboutUs(2);
        }

        [TestMethod]
        public void getAll()
        {
            IEnumerable<HCRGUniversity.Core.BL.Model.About> aboutus = _aboutUsBL.getAll(1);
            Assert.IsTrue(aboutus != null, "Unable to get");
        }

        [TestMethod]
        public void GetAllPagedAboutus()
        {
            var aboutus = _aboutUsBL.GetAllPagedAboutus(0, 10,1);
            Assert.IsTrue(aboutus != null, "Unable to find");
        }
        [TestMethod]
        public void GetAllAboutUsByOrganizationID()
        {
            IEnumerable<BLModel.About> aboutus = _aboutUsBL.GetAllAboutUsByOrganizationID(1,14);
            Assert.IsTrue(aboutus != null, "Unable to get");
        }
    }
}