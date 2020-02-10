using HCRGUniversity.Core.BL;
using HCRGUniversity.Core.BL.Implementation;
using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CoreBusinessTierTest
{
    [TestClass]
  public  class NewsVideoTest
    {

        private INewsVideoRepository _newsVideoRepository;
        private INewsVideo _newsVideoBL;
        private HCRGUniversity.Core.Data.Model.NewsVideo BLModel = new HCRGUniversity.Core.Data.Model.NewsVideo();

        [TestInitialize]
        public void NewsVideoInitialize()
        {
            _newsVideoRepository = new NewsVideoRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _newsVideoBL = new NewsVideoImpl(_newsVideoRepository);
        }

        [TestMethod]
        public void AddNewsVideo()
        {
            BLModel.NewsID = 2;
            BLModel.NewsVideos = "Video testtt";
            int result = _newsVideoBL.AddNewsVideo(BLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }
        [TestMethod]
        public void UpdateNewsVideo()
        {
            BLModel.NewsID = 2;
            BLModel.NewsVideos = "Video testtt 11";
            BLModel.NewsVideoID = 5;
            int result = _newsVideoBL.UpdateNewsVideo(BLModel);
            Assert.IsTrue(result > 0, "Unable to update");
        }

        [TestMethod]
        public void DeleteNewsVideo()
        {
            _newsVideoBL.DeleteNewsVideo(5);
        }

        [TestMethod]
        public void getAllNewsVideo()
        {
            IEnumerable<HCRGUniversity.Core.Data.Model.NewsVideo> newsVideo = _newsVideoBL.getAllNewsVideo();
            Assert.IsTrue(newsVideo != null, "Unable to get");
        }
        [TestMethod]
        public void getNewsVideoByID()
        {
            HCRGUniversity.Core.Data.Model.NewsVideo newsVideo = _newsVideoBL.GetNewsVideoByID(6);
            Assert.IsTrue(_newsVideoBL != null, "Unable to get");
        }
        [TestMethod]
        public void getNewsVideoByNewsID()
        {
            HCRGUniversity.Core.Data.Model.NewsVideo newsVideo = _newsVideoBL.GetNewsVideoByNewsID(2);
            Assert.IsTrue(_newsVideoBL != null, "Unable to get");
        }

    }
}
