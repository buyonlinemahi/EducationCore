using HCRGUniversity.Core.BL;
using HCRGUniversity.Core.BL.Implementation;
using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CoreBusinessTierTest
{
    [TestClass]
    public class NewsPhotoTest
    {
        private INewsPhotoRepository _newsPhotoRepository;
        private INewsPhoto _newsPhotoBL;
        private HCRGUniversity.Core.Data.Model.NewsPhoto BLModel = new HCRGUniversity.Core.Data.Model.NewsPhoto();

        [TestInitialize]
        public void NewsPhotoInitialize()
        {
            _newsPhotoRepository = new NewsPhotoRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _newsPhotoBL = new NewsPhotoImpl(_newsPhotoRepository);
        }

        [TestMethod]
        public void AddNewsPhoto()
        {
            BLModel.NewsID = 2;
            BLModel.NewsPhotos = "Photo testtt";
            int result = _newsPhotoBL.AddNewsPhoto(BLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }
        [TestMethod]
        public void UpdateNewsPhoto()
        {
            BLModel.NewsID = 2;
            BLModel.NewsPhotos = "Photo testtt 11";
            BLModel.NewsPhotoID = 1;
            int result = _newsPhotoBL.UpdateNewsPhoto(BLModel);
            Assert.IsTrue(result > 0, "Unable to update");
        }

        [TestMethod]
        public void DeleteNewsPhoto()
        {
            _newsPhotoBL.DeleteNewsPhoto(1);
        }

        [TestMethod]
        public void getAllNewsPhoto()
        {
            IEnumerable<HCRGUniversity.Core.Data.Model.NewsPhoto> newsPhoto = _newsPhotoBL.getAllNewsPhoto();
            Assert.IsTrue(newsPhoto != null, "Unable to get");
        }
        [TestMethod]
        public void getNewsPhotoByID()
        {
            HCRGUniversity.Core.Data.Model.NewsPhoto newsPhoto = _newsPhotoBL.GetNewsPhotoByID(2);
            Assert.IsTrue(_newsPhotoBL != null, "Unable to get");
        }

        [TestMethod]
        public void getAllNewsPhotoByNewsID()
        {
            IEnumerable<HCRGUniversity.Core.Data.Model.NewsPhoto> newsPhoto = _newsPhotoBL.getAllNewsPhotoByNewsID(56);
            Assert.IsTrue(newsPhoto != null, "Unable to get");
        }
    }
}
