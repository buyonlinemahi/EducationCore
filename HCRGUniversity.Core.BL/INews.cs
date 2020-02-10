using HCRGUniversity.Core.Data.Model;
using System;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;
namespace HCRGUniversity.Core.BL
{
    public interface INews
    {
        int AddNews(News news);
        int UpdateNews(News news);
        void DeleteNews(int newsID);
        News GetNewsByID(int newsID);
        IEnumerable<News> getAllNews(int OrganizationID);
        BLModel.Paged.NewsFullDetail GetAllNewsDetail(string type, int skip, int take, int OrganizationID);//paging
        IEnumerable<NewsFullDetail> GetNewsDetailByNewsID(int newsID, string type);
        BLModel.Paged.News GetNewsByNewsTitlePaged(string newsTitle, int OrganizationID, int skip, int take);
        BLModel.Paged.NewsFullDetail GetAllNewsDetailByNewsSectionID(int newsSectionID,int skip,int take);//paging
        BLModel.Paged.NewsFullDetail GetAllNewsDetailByNewsSectionIDAndType(string type, int newsSectionID, int skip, int take, int OrganizationID);//paging
        IEnumerable<News> GetNewslatest(int OrganizationID);
        BLModel.Paged.News GetAllPagedNews(int skip, int take, int OrganizationID);
        IEnumerable<NewsSearchCarousel> GetNewsDetailsAccordingToNewsSearch(string searchText, int OrganizationID);
        IEnumerable<BLModel.News> GetAllNewsByOrganizationID(int OrganizationID, int ClientID);

        //Events
        int AddEvent(Event evnt);
        int UpdateEvent(Event evnt);
        void DeleteEvent(int evnt);
        BLModel.Paged.Events getAllEventsPaged(int skip, int take, int clientID, int orgID);
        IEnumerable<EventDetail> GetEventsByEventDateRange(DateTime startDate, DateTime endDate, int organizationID);
        IEnumerable<EventDetail> GetEventsUpcoming(int organizationID);
    }
}
