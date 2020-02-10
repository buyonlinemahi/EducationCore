using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.Model;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;
using BLModel = HCRGUniversity.Core.BL.Model;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL.Implementation
{
    public class NewsImpl : INews
    {
        private readonly INewsRepository _newsRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IOrganizationRepository _organizationRepository;

        public NewsImpl(INewsRepository newsRepository, IEventRepository eventRepository, IOrganizationRepository organizationRepository)
        {
            _newsRepository = newsRepository;
            _eventRepository = eventRepository;
            _organizationRepository = organizationRepository;

        }

        public int AddNews(DLModel.News news)
        {
            return _newsRepository.Add((DLModel.News)new DLModel.News().InjectFrom(news)).NewsID;

        }

        public IEnumerable<DLModel.NewsSearchCarousel> GetNewsDetailsAccordingToNewsSearch(string searchText, int OrganizationID)
        {
            IEnumerable<DLModel.NewsSearchCarousel> getNewsDetailsResult = _newsRepository.GetNewsDetailsAccordingToNewsSearch(searchText, OrganizationID).Select(news => new DLModel.NewsSearchCarousel().InjectFrom(news)).Cast<DLModel.NewsSearchCarousel>().ToList();
            return getNewsDetailsResult;
        }

        public int UpdateNews(DLModel.News news)
        {
            return _newsRepository.Update((DLModel.News)new DLModel.News().InjectFrom(news));
        }

        public void DeleteNews(int newsID)
        {
            _newsRepository.Delete(_newsRepository.GetById(newsID));
        }

        public DLModel.News GetNewsByID(int newsID)
        {
            return (DLModel.News)new DLModel.News().InjectFrom(_newsRepository.GetById(newsID));
        }

        public BLModel.Paged.News GetNewsByNewsTitlePaged(string newsTitle, int _organizationID, int skip, int take)
        {

            if (_organizationRepository.GetById(_organizationID).IsOrganizationAdmin)
            {
                return new BLModel.Paged.News
                {
                    NewsRecords = _newsRepository.GetAll(hp => (hp.NewsTitle.StartsWith(newsTitle))).OrderBy(hp => hp.NewsID).Skip(skip).Take(take).ToList(),
                    TotalCount = _newsRepository.GetAll(hp => (hp.NewsTitle.StartsWith(newsTitle))).Count()
                };
            }
            else
            {
                return new BLModel.Paged.News
                {
                    NewsRecords = _newsRepository.GetAll(hp => (hp.OrganizationID == _organizationID) && (hp.NewsTitle.StartsWith(newsTitle))).OrderBy(hp => hp.NewsID).Skip(skip).Take(take).ToList(),
                    TotalCount = _newsRepository.GetAll(hp => (hp.OrganizationID == _organizationID) && (hp.NewsTitle.StartsWith(newsTitle))).Count()
                };
            }
        }

        public IEnumerable<DLModel.News> getAllNews(int _organizationID)
        {
            IEnumerable<DLModel.News> _news = _newsRepository.GetAll(rk => rk.OrganizationID == _organizationID).Select(news => new DLModel.News().InjectFrom(news)).Cast<DLModel.News>().OrderBy(news => news.NewsID).ToList();
            return _news;
        }

        public BLModel.Paged.NewsFullDetail GetAllNewsDetail(string type, int skip, int take, int OrganizationID)
        {
            return new BLModel.Paged.NewsFullDetail
            {
                NewsFullDetailRecords = _newsRepository.GetAllNewsDetail(type, skip, take, OrganizationID).ToList(),
                TotalCount = _newsRepository.GetAllNewsDetailCount(type, OrganizationID)
            };       
        }

        public IEnumerable<DLModel.NewsFullDetail> GetNewsDetailByNewsID(int newsID, string type)
        {
            IEnumerable<DLModel.NewsFullDetail> _newFullDetail = _newsRepository.GetNewsDetailByNewsID(newsID, type).ToList();
            return _newFullDetail;
        }

        public BLModel.Paged.NewsFullDetail GetAllNewsDetailByNewsSectionID(int newsSectionID, int skip, int take)
        {
            return new BLModel.Paged.NewsFullDetail
            {
                NewsFullDetailRecords = _newsRepository.GetAll(newsFullDetail => newsFullDetail.NewsSectionID == newsSectionID).Select(newsFullDetail => new DLModel.NewsFullDetail().InjectFrom(newsFullDetail)).Cast<DLModel.NewsFullDetail>().OrderBy(newsFullDetail => newsFullDetail.NewsID).ToList().Skip(skip).Take(take),
                TotalCount = _newsRepository.GetAll(newsFullDetail => newsFullDetail.NewsSectionID == newsSectionID).Select(newsFullDetail => new DLModel.NewsFullDetail().InjectFrom(newsFullDetail)).Cast<DLModel.NewsFullDetail>().Count()
            }; 
        }

        public BLModel.Paged.NewsFullDetail GetAllNewsDetailByNewsSectionIDAndType(string type, int newsSectionID, int skip, int take, int OrganizationID)
        {
            return new BLModel.Paged.NewsFullDetail
            {
                NewsFullDetailRecords = _newsRepository.GetAllNewsDetailByNewsSectionIDAndType(type, newsSectionID, skip, take).ToList(),
                TotalCount = _newsRepository.GetAllNewsDetailByNewsSectionIDAndTypeCount(type, newsSectionID, OrganizationID)
            }; 
          
        }

        public IEnumerable<DLModel.News> GetNewslatest(int OrganizationID)
        {
            IEnumerable<DLModel.News> _news = _newsRepository.GetNewslatest(OrganizationID).ToList();
            return _news;
        }

        //*******************Lazy binding
        public BLModel.Paged.News GetAllPagedNews(int skip, int take, int _organizationID)
        {
            return new BLModel.Paged.News
            {
                TotalCount = _newsRepository.GetNewsCount(_organizationID),
                NewsRecords = _newsRepository.GetAllPagedNews(skip, take, _organizationID).ToList()
            };
        }

        public IEnumerable<BLModel.News> GetAllNewsByOrganizationID(int OrganizationID, int ClientID)
        {
            return _newsRepository.GetAllNewsByOrganizationID(OrganizationID, ClientID);
        }
        //Events

        public int AddEvent(DLModel.Event evnt)
        {
            return _eventRepository.Add(evnt).EventID;

        }

        public int UpdateEvent(DLModel.Event evnt)
        {
            return _eventRepository.Update(evnt);
        }

        public void DeleteEvent(int EventID)
        {
            _eventRepository.Delete(_eventRepository.GetById(EventID));
        }

        public BLModel.Paged.Events getAllEventsPaged(int skip, int take, int clientID, int orgID)
        {
            return new BLModel.Paged.Events
            {
                _events = _eventRepository.GetEventsAllPaged(skip, take, clientID,orgID).ToList(),
                TotalCount = _eventRepository.GetEventsAllPagedCount(clientID, orgID)
            };
        }
        public IEnumerable<EventDetail> GetEventsByEventDateRange(DateTime startDate, DateTime endDate, int organizationID)
        {
            return _eventRepository.GetEventsByEventDateRange(startDate, endDate, organizationID).ToList();
        }
        public IEnumerable<EventDetail> GetEventsUpcoming(int organizationID)
        {
            return _eventRepository.GetEventsUpcoming(organizationID).ToList();
        }
    }
}