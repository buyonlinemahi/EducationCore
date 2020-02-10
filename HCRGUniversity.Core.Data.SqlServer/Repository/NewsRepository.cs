using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using HCRGUniversity.Core.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.Data.SqlServer.Repository
{
    public class NewsRepository : BaseRepository<News, HCRGUniversityDBContext>, INewsRepository
    {
        public NewsRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }
        public IEnumerable<NewsFullDetail> GetAllNewsDetail(string type, int skip, int take, int OrganizationID)
        {
            SqlParameter _type = new SqlParameter("@Type", type);
            SqlParameter _skip = new SqlParameter("@skip", skip);
            SqlParameter _take = new SqlParameter("@take", take);
            SqlParameter _organizationID = new SqlParameter("@OrganizationID", OrganizationID);

            return Context.Database.SqlQuery<NewsFullDetail>(Constant.StoredProcedureConst.NewsRepositoryProcedure.GetAllNewsDetail, _type, _skip, _take, _organizationID).ToList();
        }

        public int GetAllNewsDetailCount(string type, int OrganizationID)
        {
            SqlParameter _type = new SqlParameter("@Type", type);
            SqlParameter _organizationID = new SqlParameter("@OrganizationID", OrganizationID);
            return Context.Database.SqlQuery<int>(Constant.StoredProcedureConst.NewsRepositoryProcedure.GetAllNewsDetailCount, _type, _organizationID).FirstOrDefault();
        }

        public IEnumerable<NewsSearchCarousel> GetNewsDetailsAccordingToNewsSearch(string searchText, int OrganizationID)
        {
            SqlParameter _NewsTitle = new SqlParameter("@NewsTitle", searchText);
            SqlParameter _organizationID = new SqlParameter("@OrganizationID", OrganizationID);
            return Context.Database.SqlQuery<NewsSearchCarousel>(Constant.StoredProcedureConst.NewsRepositoryProcedure.GetNewsDetailsAccordingToNewsSearch, _NewsTitle, _organizationID);
        }

        public IEnumerable<NewsFullDetail> GetNewsDetailByNewsID(int newsID,string type)
        {
            SqlParameter _type = new SqlParameter("@Type", type);
            SqlParameter _newsID = new SqlParameter("@NewsID", newsID);
            return Context.Database.SqlQuery<NewsFullDetail>(Constant.StoredProcedureConst.NewsRepositoryProcedure.GetNewsDetailByNewsID,_newsID,_type);
        }

        public IEnumerable<NewsFullDetail> GetAllNewsDetailByNewsSectionIDAndType(string type, int newsSectionID, int skip, int take)
        {
            SqlParameter _type = new SqlParameter("@Type", type);
            SqlParameter _newsSectionID = new SqlParameter("@SectionID", newsSectionID);
            SqlParameter _skip = new SqlParameter("@Skip", skip);
            SqlParameter _take = new SqlParameter("@Take", take);
            return Context.Database.SqlQuery<NewsFullDetail>(Constant.StoredProcedureConst.NewsRepositoryProcedure.GetNewsDetailBySectionIDandType,_type,_newsSectionID,_skip,_take).ToList();
        }

        public int GetAllNewsDetailByNewsSectionIDAndTypeCount(string type, int newsSectionID, int OrganizationID)
        {
            SqlParameter _type = new SqlParameter("@Type", type);
            SqlParameter _newsSectionID = new SqlParameter("@SectionID", newsSectionID);
            SqlParameter _organizationID = new SqlParameter("@OrganizationID", OrganizationID);
            return Context.Database.SqlQuery<int>(Constant.StoredProcedureConst.NewsRepositoryProcedure.GetNewsDetailBySectionIDandTypeCount, _type, _newsSectionID, _organizationID).FirstOrDefault();
        }

        public IEnumerable<News> GetNewslatest(int OrganizationID)
        {
            SqlParameter _organizationID = new SqlParameter("@OrganizationID", OrganizationID);
            return Context.Database.SqlQuery<News>(Constant.StoredProcedureConst.NewsRepositoryProcedure.GetNewslatest, _organizationID);
        }

        public IEnumerable<News> GetAllPagedNews(int skip, int take, int OrganizationID)
        {
            return dbset.Where(rk => rk.OrganizationID == OrganizationID).ToArray().OrderByDescending(o => o.NewsID).Skip(skip).Take(take);
        }

        public int GetNewsCountByFilter(System.Linq.Expressions.Expression<Func<News, bool>> where)
        {
            return dbset.Where(where).Count();
        }

        public int GetNewsCount(int OrganizationID)
        {
            return dbset.Where(rk => rk.OrganizationID == OrganizationID).Count();
        }

        public IEnumerable<BLModel.News> GetAllNewsByOrganizationID(int OrganizationID, int ClientID)
        {
            SqlParameter _OrganizationID = new SqlParameter("@OrgID", OrganizationID);
            SqlParameter _ClientID = new SqlParameter("@ClientID", ClientID);
            return Context.Database.SqlQuery<BLModel.News>(Constant.StoredProcedureConst.NewsRepositoryProcedure.GetAllNewsByOrganizationID, _OrganizationID, _ClientID).ToList();
        }
       
    }
}
