using HCRGUniversity.Core.BL;
using HCRGUniversity.Core.BL.Implementation;
using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace CoreBusinessTierTest
{
    [TestClass]
    public class NewsTest
    {
        private INewsRepository _newsRepository;
        private IEventRepository _eventRepository;
        private IOrganizationRepository _oganizationRepository;
        private INews _newsBL;
        private HCRGUniversity.Core.Data.Model.News BLModel = new HCRGUniversity.Core.Data.Model.News();
        private HCRGUniversity.Core.Data.Model.Event DLModelEvent = new HCRGUniversity.Core.Data.Model.Event();

        [TestInitialize]
        public void NewsInitialize()
        {
            _newsRepository = new NewsRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _eventRepository = new EventRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _oganizationRepository = new OrganizationRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _newsBL = new NewsImpl(_newsRepository, _eventRepository, _oganizationRepository);
        }

        [TestMethod]
        public void AddNews()
        {
            BLModel.NewsDescription = "testing tesing";
            BLModel.NewsEditorPick = true;
            BLModel.NewsSectionID = 26;
            BLModel.NewsAuthor = "testauthor";
            BLModel.NewsTitle = "NewsTitle";
            BLModel.NewsDate = DateTime.Now;
            BLModel.NewsType = "Photo";
            int result = _newsBL.AddNews(BLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }
        [TestMethod]
        public void UpdateNews()
        {
            BLModel.NewsDescription = "testing tesing  11";
            BLModel.NewsAuthor = "testauthorupdate";
            BLModel.NewsEditorPick = true;
            BLModel.NewsSectionID = 26;
            BLModel.NewsTitle = "NewsTitle";
            BLModel.NewsID = 216;
            int result = _newsBL.UpdateNews(BLModel);
            Assert.IsTrue(result > 0, "Unable to update");
        }

        [TestMethod]
        public void DeleteNews()
        {
            _newsBL.DeleteNews(1);
        }

        [TestMethod]
        public void getAllNews()
        {
            IEnumerable<HCRGUniversity.Core.Data.Model.News> news = _newsBL.getAllNews(1);
            Assert.IsTrue(_newsBL != null, "Unable to get");
        }

        [TestMethod]
        public void getNewslatest()
        {
            IEnumerable<HCRGUniversity.Core.Data.Model.News> news = _newsBL.GetNewslatest(1);
            Assert.IsTrue(_newsBL != null, "Unable to get");
        }
        [TestMethod]
        public void getNewsByID()
        {
            HCRGUniversity.Core.Data.Model.News news = _newsBL.GetNewsByID(216);
            Assert.IsTrue(_newsBL != null, "Unable to get");
        }

        [TestMethod]
        public void GetNewsByNewsTitlePaged()
        {
            var s = _newsBL.GetNewsByNewsTitlePaged("tarun", 1, 2,10);
            Assert.IsTrue(_newsBL != null, "Unable to get");
        }

        [TestMethod]
        public void getAllNewsDetail()
        {
            var getallNews = _newsBL.GetAllNewsDetail("All", 0, 10,1);
            Assert.IsTrue(_newsBL != null, "Unable to get");
        }

        [TestMethod]
        public void getNewsDetailByNewsID()
        {
            IEnumerable<HCRGUniversity.Core.Data.Model.NewsFullDetail> newsFullDetail = _newsBL.GetNewsDetailByNewsID(56, "Photo");
            Assert.IsTrue(_newsBL != null, "Unable to get");
        }

        [TestMethod]
        public void getAllNewsDetailByNewsSectionID()
        {
            var getallNews = _newsBL.GetAllNewsDetailByNewsSectionID(2, 0, 10);
            Assert.IsTrue(_newsBL != null, "Unable to get");
        }

        [TestMethod]
        public void getAllNewsDetailByNewsSectionIDAndType()
        {
            var getallNews = _newsBL.GetAllNewsDetailByNewsSectionIDAndType("All", 26, 0, 10,1);
            Assert.IsTrue(_newsBL != null, "Unable to get");
        }

        [TestMethod]
        public void GetAllPagedNews()
        {
            var news = _newsBL.GetAllPagedNews(0, 10,1);
            Assert.IsTrue(news != null, "Unable to find");
        }


        [TestMethod]
        public void getNewsDetailsAccordingToNewsSearch()
        {
            IEnumerable<HCRGUniversity.Core.Data.Model.NewsSearchCarousel> newsFullDetail = _newsBL.GetNewsDetailsAccordingToNewsSearch("tyu",1);
            Assert.IsTrue(_newsBL != null, "Unable to get");
        }

        [TestMethod]
        public void GetAllNewsByOrganizationID()
        {
            IEnumerable<BLModel.News> news = _newsBL.GetAllNewsByOrganizationID(1, 14);
            Assert.IsTrue(news != null, "Unable to get");
        }

        //Events
        [TestMethod]
        public void AddEvent()
        {
            DLModelEvent.EventDescription = "testing tesing";
            DLModelEvent.EventName = "dsf";
            //DLModelEvent.EducationID = 2;
            DLModelEvent.NewsID = 791;
            DLModelEvent.EventDate = DateTime.Now;
            int result = _newsBL.AddEvent(DLModelEvent);
            Assert.IsTrue(result > 0, "Unable to Add");
        }
        [TestMethod]
        public void UpdateEvent()
        {
            DLModelEvent.EventDescription = "testing tesing";
            DLModelEvent.EventName = "dsf";
            DLModelEvent.EducationID = 1;
            DLModelEvent.EventDate = DateTime.Now;
            DLModelEvent.EventID = 2;
            int result = _newsBL.UpdateEvent(DLModelEvent);
            Assert.IsTrue(result > 0, "Unable to update");
        }

        [TestMethod]
        public void DeleteEvent()
        {
            _newsBL.DeleteEvent(2);
        }

        [TestMethod]
        public void getAllEvent()
        {
            var Event = _newsBL.getAllEventsPaged(0,10,14,0);
            Assert.IsTrue(_newsBL != null, "Unable to get");
        }
        [TestMethod]
        public void GetEventsByEventDateRange()
        {
            var Event = _newsBL.GetEventsByEventDateRange(System.DateTime.Now, System.DateTime.Now.AddDays(20),1);
            Assert.IsTrue(_newsBL != null, "Unable to get");
        }
        [TestMethod]
        public void GetEventsUpcoming()
        {
            var Event = _newsBL.GetEventsUpcoming(1);
            Assert.IsTrue(_newsBL != null, "Unable to get");
        }
    }
}