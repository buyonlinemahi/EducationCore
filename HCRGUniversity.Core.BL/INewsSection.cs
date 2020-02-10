using System.Collections.Generic;
using HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL
{
   public  interface INewsSection
    {
        int AddNewsSection(NewsSection newsSection);
        int UpdateNewsSection(NewsSection newsSection );
        void DeleteNewsSection(int newsSectionID);
        NewsSection GetNewsSectionByID(int newsSectionID);
        IEnumerable<NewsSection> getAllNewsSection(int OrganizationID);
    }
}
