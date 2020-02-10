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
    public class CarouselSetUpTest
    {
        private ICarouselSetUpRepository _carouselSetupRepository;
        private INewsPhotoRepository _newsPhotoRepository;
        private IHomeContentRepository _homeContentRepository;
        private ICarouselSetUp _carouselSetupBL;
        private IIndustryResearchRepository _industryResearchBL;

        private HCRGUniversity.Core.Data.Model.CarouselSetUp DLModel = new HCRGUniversity.Core.Data.Model.CarouselSetUp();
        private HCRGUniversity.Core.Data.Model.HomeContent DLModelHome = new HCRGUniversity.Core.Data.Model.HomeContent();
        private HCRGUniversity.Core.Data.Model.IndustryResearch DLModelIndustryResearch = new HCRGUniversity.Core.Data.Model.IndustryResearch();

        [TestInitialize]
        public void CollegeInitialize()
        {
            _carouselSetupRepository = new CarouselSetUpRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _newsPhotoRepository = new NewsPhotoRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _homeContentRepository = new HomeContentRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _industryResearchBL = new IndustryResearchRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _carouselSetupBL = new CarouselSetUpImpl(_carouselSetupRepository, _newsPhotoRepository, _homeContentRepository, _industryResearchBL);
        }

        [TestMethod]
        public void AddCarouselDataITem()
        {
            DLModel.CarouselTitle = "testing tesing";
            DLModel.CarouselDescription = "test.jpg";
            DLModel.CarouselBgColor = "sdfsddfsfsd";
            DLModel.NewsID = 618;
            int result = _carouselSetupBL.AddCarouselSetup(DLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }
        [TestMethod]
        public void Get_CarouselData()
        {
            IEnumerable<BLModel.CarouselSetUp> _carouselDataResult = _carouselSetupBL.GetCarouselSetUpAll(1);
            Assert.IsTrue(_carouselDataResult != null, "Unable to get");
        }

        [TestMethod]
        public void Get_AllCarousel()
        {
            IEnumerable<BLModel.CarouselSetUp> _carouselDataResult = _carouselSetupBL.GetAllCarouselSetUp(0,14);
            Assert.IsTrue(_carouselDataResult != null, "Unable to get");
        }

        [TestMethod]
        public void GetAllCarouselSetUp()
        {
            IEnumerable<BLModel.CarouselSetUp> _carouselDataResult = _carouselSetupBL.GetAllCarouselSetUp(1, 14);
            Assert.IsTrue(_carouselDataResult != null, "Unable to get");
        }
        
        [TestMethod]
        public void Get_CarouselNewsDetail()
        {
            IEnumerable<BLModel.CarouselSetUp> _carouselDataResult = _carouselSetupBL.GetCarouselNewsDetail(100);
            Assert.IsTrue(_carouselDataResult != null, "Unable to get");
        }

        [TestMethod]
        public void UpdateCarouselDataITem()
        {
            DLModel.CarouselID = 5;
            DLModel.CarouselTitle = "testing tesing";
            DLModel.CarouselDescription = "test.jpg";
            DLModel.CarouselBgColor = "sdfsddfsfsd";
            DLModel.NewsID = 619;
            int result = _carouselSetupBL.UpdateCarouselSetUp(DLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }

        //HomeContent
            
        [TestMethod]
        public void UpdateHomeContent()
        {
            DLModelHome.HomePageContent = "testing ghfg dfsfsf tesing";
            int result = _carouselSetupBL.UpdateHomeContent(DLModelHome);
            Assert.IsTrue(result > 0, "Unable to Add");
        }

        [TestMethod]
        public void GetHomeContent()
        {
            HCRGUniversity.Core.Data.Model.HomeContent homeContent = _carouselSetupBL.GetHomeContent(1);
            Assert.IsTrue(homeContent != null, "Unable to get");
        }

        [TestMethod]
        public void GetAllHomeContentByOrganizationID()
        {
            IEnumerable<BLModel.HomeContent> homeCarousel = _carouselSetupBL.GetAllHomeContentByOrganizationID(14,100);
            Assert.IsTrue(homeCarousel != null, "Unable to get");
        }

        //industry research...hp
        [TestMethod]
        public void AddIndustryResearchContent()
        {
            DLModelIndustryResearch.IndustryResearchContent = "asdf sda";
            int result = _carouselSetupBL.AddIndustryResearchContent(DLModelIndustryResearch);
            Assert.IsTrue(result > 0, "Unable to Add");
        }
        [TestMethod]
        public void UpdateIndustryResearchContent()
        {
            DLModelIndustryResearch.IndustryResearchID = 1;
            DLModelIndustryResearch.IndustryResearchContent = "asdf sda df sfsdf sda";
            int result = _carouselSetupBL.UpdateIndustryResearchContent(DLModelIndustryResearch);
            Assert.IsTrue(result > 0, "Unable to Add");
        }
        [TestMethod]
        public void GetIndustryResearchContent()
        {
            var result = _carouselSetupBL.GetIndustryResearchContent(1);
            Assert.IsTrue(result != null, "Unable to get");
        }

        [TestMethod]
        public void GetAllIndustryResearchesByOrganizationID()
        {
            IEnumerable<BLModel.IndustryResearch> Industry = _carouselSetupBL.GetAllIndustryResearchesByOrganizationID(1, 14);
            Assert.IsTrue(Industry != null, "Unable to get");
        }
    }
}
