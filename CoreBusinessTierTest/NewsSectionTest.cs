using HCRGUniversity.Core.BL;
using HCRGUniversity.Core.BL.Implementation;
using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CoreBusinessTierTest
{
    [TestClass]
    public class NewsSectionTest
    {
        private INewsSectionRepository _newsSectionRepository;
        private INewsSection _newsSectionBL;
        private HCRGUniversity.Core.Data.Model.NewsSection BLModel = new HCRGUniversity.Core.Data.Model.NewsSection();

        [TestInitialize]
        public void NewsSectionInitialize()
        {
            _newsSectionRepository = new NewsSectionRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _newsSectionBL = new NewsSectionImpl(_newsSectionRepository);
        }

        [TestMethod]
        public void AddNewsSection()
        {
            BLModel.NewsSectionTitle = "testing tesing";
            BLModel.NewsSectionType = "Section";
            int result = _newsSectionBL.AddNewsSection(BLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }
        [TestMethod]
        public void UpdateNewsSection()
        {
            BLModel.NewsSectionTitle = "testing tesing 11";
            BLModel.NewsSectionType = "Section";
            BLModel.NewsSectionID = 1;
            int result = _newsSectionBL.UpdateNewsSection(BLModel);
            Assert.IsTrue(result > 0, "Unable to update");
        }

        [TestMethod]
        public void DeleteNewsSection()
        {
            _newsSectionBL.DeleteNewsSection(1);
        }

        [TestMethod]
        public void getAllNewsSection()
        {
            IEnumerable<HCRGUniversity.Core.Data.Model.NewsSection> newsSection = _newsSectionBL.getAllNewsSection(1);
            Assert.IsTrue(newsSection != null, "Unable to get");
        }
        [TestMethod]
        public void getNewsSectionByID()
        {
            HCRGUniversity.Core.Data.Model.NewsSection newsSection = _newsSectionBL.GetNewsSectionByID(2);
            Assert.IsTrue(_newsSectionBL != null, "Unable to get");
        }
    }

}
