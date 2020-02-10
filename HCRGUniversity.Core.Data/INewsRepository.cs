using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;


namespace HCRGUniversity.Core.Data
{
    public interface INewsRepository : IBaseRepository<News>
    {
        IEnumerable<NewsFullDetail> GetAllNewsDetail(string type, int skip, int take, int OrganizationID);
        int GetAllNewsDetailCount(string type, int OrganizationID);
        IEnumerable<NewsFullDetail> GetNewsDetailByNewsID(int newsID,string type);
        IEnumerable<NewsFullDetail> GetAllNewsDetailByNewsSectionIDAndType(string type, int newsSectionID, int skip, int take);
        int GetAllNewsDetailByNewsSectionIDAndTypeCount(string type, int newsSectionID, int OrganizationID);
        IEnumerable<News> GetNewslatest(int OrganizationID);
        IEnumerable<News> GetAllPagedNews(int skip, int take, int OrganizationID);
        int GetNewsCountByFilter(System.Linq.Expressions.Expression<Func<News, bool>> where);
        int GetNewsCount(int OrganizationID);
        IEnumerable<NewsSearchCarousel> GetNewsDetailsAccordingToNewsSearch(string searchText, int OrganizationID);
        IEnumerable<BLModel.News> GetAllNewsByOrganizationID(int OrganizationID, int ClientID);
    }
}
