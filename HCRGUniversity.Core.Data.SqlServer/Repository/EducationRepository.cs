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
    public class EducationRepository : BaseRepository<Education, HCRGUniversityDBContext>, IEducationRepository
    {
        public EducationRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }


        public IEnumerable<EducationProfessionDetail> GetEducationAndProfession(int OrganizationID)
        {
            SqlParameter _organizationID = new SqlParameter("@OrganizationID", OrganizationID);
            return Context.Database.SqlQuery<EducationProfessionDetail>(Constant.StoredProcedureConst.EducationRepositoryProcedure.GetEducationAndProfession, _organizationID);
        }

        public IEnumerable<EducationFormatDetail> GetEducationAndEducationFormat(int OrganizationID)
        {
            SqlParameter _organizationID = new SqlParameter("@OrganizationID", OrganizationID);
            return Context.Database.SqlQuery<EducationFormatDetail>(Constant.StoredProcedureConst.EducationRepositoryProcedure.GetEducationAndEducationFormat, _organizationID);
        }

        public IEnumerable<CollegeEducationSearch> GetCollegeEducationByEducationID(int educationID)
        {
            SqlParameter _educationID = new SqlParameter("@EducationID", educationID);
            return Context.Database.SqlQuery<CollegeEducationSearch>(Constant.StoredProcedureConst.CollegeEducatoinRepositoryProcedure.GetCollegeEducationByEducationID, _educationID);
        }

        public IEnumerable<EducationProfessionDetail> GetProfessionEducationByEducationID(int educationID)
        {
            SqlParameter _educationID = new SqlParameter("@EducationID", educationID);
            return Context.Database.SqlQuery<EducationProfessionDetail>(Constant.StoredProcedureConst.ProfessionEducatoinRepositoryProcedure.GetProfessionEducationByEducationID, _educationID);
        }

        public IEnumerable<Education> GetEducationLatest(int userID, int OrganizationID)
        {
            //return dbset.Where(hp => hp.IsActive != false && (hp.CourseStartDate<=DateTime.Now && hp.CourseEndDate>DateTime.Now ) &&  (hp.ReadyToDisplay == true)).OrderByDescending(hp => hp.EducationID).Take(15);
            SqlParameter _userID = new SqlParameter("@UserID", userID);
            SqlParameter _organizationID = new SqlParameter("@OrganizationID", OrganizationID);
            return Context.Database.SqlQuery<Education>(Constant.StoredProcedureConst.EducationRepositoryProcedure.GetEducationLatestByUserID, _userID, _organizationID);
        }

        public IEnumerable<EducationDetail> GetEducationCollegeByCollegeIDPaged(int collegeID, int? userID, int skip, int take, int OrganizationID)
        {
            SqlParameter _collegeID = new SqlParameter("@CollegeID", collegeID);
            SqlParameter _userID = new SqlParameter("@UserID", userID);
            SqlParameter _skip = new SqlParameter("@skip", skip);
            SqlParameter _take = new SqlParameter("@take", take);
            SqlParameter _organizationID = new SqlParameter("@OrganizationID", OrganizationID);
            return Context.Database.SqlQuery<EducationDetail>(Constant.StoredProcedureConst.EducationRepositoryProcedure.GetEducationCollegeByCollegeIDPaged, _collegeID, _userID, _skip, _take, _organizationID);
        }

        public IEnumerable<EducationDetail> GetEducationCollegeByEducationFormatIDPaged(int formatID, int? userID, int skip, int take, int OrganizationID)
        {
            SqlParameter _collegeID = new SqlParameter("@CollegeID", DBNull.Value);
            SqlParameter _formatID = new SqlParameter("@EducationFormatID", formatID);
            SqlParameter _userID = new SqlParameter("@UserID", userID);
            SqlParameter _skip = new SqlParameter("@skip", skip);
            SqlParameter _take = new SqlParameter("@take", take);
            SqlParameter _organizationID = new SqlParameter("@OrganizationID", OrganizationID);
            return Context.Database.SqlQuery<EducationDetail>(Constant.StoredProcedureConst.EducationRepositoryProcedure.GetEducationCollegeByEducationFormatIDAndCollegeIDPaged, _collegeID, _formatID, _userID, _skip, _take, _organizationID);
        }

        public IEnumerable<EducationDetail> GetEducationByProfessionIDPaged(int professionID, int? userID, int skip, int take, int OrganizationID)
        {
            SqlParameter _professionID = new SqlParameter("@ProfessionID", professionID);
            SqlParameter _userID = new SqlParameter("@UserID", userID);
            SqlParameter _skip = new SqlParameter("@skip", skip);
            SqlParameter _take = new SqlParameter("@take", take);
            SqlParameter _organizationID = new SqlParameter("@OrganizationID", OrganizationID);
            return Context.Database.SqlQuery<EducationDetail>(Constant.StoredProcedureConst.EducationRepositoryProcedure.GetEducationByProfessionIDPaged, _professionID, _userID, _skip, _take, _organizationID).ToList();
        }

        public IEnumerable<EducationDetail> GetEducationCollegeByEducationFormatIDAndCollegeIDPaged(int CollegeID, int formatID, int? userId, int skip, int take, int OrganizationID)
        {
            SqlParameter _collegeID = new SqlParameter("@CollegeID", CollegeID);
            SqlParameter _formatID = new SqlParameter("@EducationFormatID", formatID);
            SqlParameter _userID = new SqlParameter("@UserID", userId);
            SqlParameter _skip = new SqlParameter("@skip", skip);
            SqlParameter _take = new SqlParameter("@take", take);
            SqlParameter _organizationID = new SqlParameter("@OrganizationID", OrganizationID);
            return Context.Database.SqlQuery<EducationDetail>(Constant.StoredProcedureConst.EducationRepositoryProcedure.GetEducationCollegeByEducationFormatIDAndCollegeIDPaged, _collegeID, _formatID, _userID, _skip, _take, _organizationID);
        }




        public IEnumerable<EducationDetail> GetEducationByEducationFormatIDORCollegeIDORDeptIDORPrfIDPaged(int? CollegeID, int? formatID, int? professionID, int? userID, int skip, int take, int OrganizationID)
        {
            SqlParameter _collegeID, _formatID, _professionID, _userID;
            if (CollegeID == null)
            {
                _collegeID = new SqlParameter("@CollegeID", DBNull.Value);
            }
            else
            {
                _collegeID = new SqlParameter("@CollegeID", CollegeID);
            }
            if (formatID == null)
            {
                _formatID = new SqlParameter("@EducationFormatID", DBNull.Value);
            }
            else
            {
                _formatID = new SqlParameter("@EducationFormatID", formatID);
            }

            if (professionID == null)
            {
                _professionID = new SqlParameter("@ProfessionID", DBNull.Value);
            }
            else
            {
                _professionID = new SqlParameter("@ProfessionID", professionID);
            }

            if (userID == null)
            {
                _userID = new SqlParameter("@UserID", DBNull.Value);
            }
            else
            {
                _userID = new SqlParameter("@UserID", userID);
            }

            SqlParameter _skip = new SqlParameter("@skip", skip);
            SqlParameter _take = new SqlParameter("@take", take);
            SqlParameter _organizationID = new SqlParameter("@OrganizationID", OrganizationID);


            return Context.Database.SqlQuery<EducationDetail>(Constant.StoredProcedureConst.EducationRepositoryProcedure.GetEducationByEducationFormatIDORCollegeIDORDeptIDORPrfIDPaged, _collegeID, _formatID, _professionID, _userID, _skip, _take, _organizationID);
        }


        public IEnumerable<EducationNewsSearch> GetEducationNewsSearchByTextPaged(string searchText, int? userId,int OrganizationID,int skip, int take)
        {
            SqlParameter _searchText = new SqlParameter("@searchText", searchText);
            SqlParameter _userid = new SqlParameter("@UserID", userId);
            SqlParameter _skip = new SqlParameter("@Skip", skip);
            SqlParameter _take = new SqlParameter("@Take", take);
            SqlParameter _organizationID = new SqlParameter("@OrganizationID", OrganizationID);
            return Context.Database.SqlQuery<EducationNewsSearch>(Constant.StoredProcedureConst.EducationRepositoryProcedure.GetEducationNewsSearchByTextPaged, _searchText, _userid, _organizationID, _skip, _take);
        }

        public int GetEducationNewsSearchByTextPagedCount(string searchText, int? userid, int OrganizationID)
        {
            SqlParameter _searchText = new SqlParameter("@searchText", searchText);
            SqlParameter _userid = new SqlParameter("@UserID", userid);
            SqlParameter _organizationID = new SqlParameter("@OrganizationID", OrganizationID);
            return Context.Database.SqlQuery<int>(Constant.StoredProcedureConst.EducationRepositoryProcedure.GetEducationNewsSearchByTextPagedCount, _searchText, _userid, _organizationID).SingleOrDefault();
        }

        public IEnumerable<EducationProfessionDetail> GetAllPagedEducationProfession(int skip, int take, int OrganizationID)
        {
            SqlParameter _Skip = new SqlParameter("@Skip", skip);
            SqlParameter _Take = new SqlParameter("@Take", take);
            SqlParameter _organizationID = new SqlParameter("@OrganizationID", OrganizationID);

            return Context.Database.SqlQuery<EducationProfessionDetail>(Constant.StoredProcedureConst.EducationRepositoryProcedure.GetAllPagedEducationProfession, _Skip, _Take, _organizationID);
        }


        public int GetEducationProfessionCount()
        {
            return Context.Database.SqlQuery<int>(Constant.StoredProcedureConst.EducationRepositoryProcedure.GetCountEducationProfession).SingleOrDefault();
        }

        public IEnumerable<EducationSearchResult> GetAllPagedEducationByfilter(string coursename, int skip, int take, int ClientID, int OrgID)
        {
            SqlParameter _Coursename = new SqlParameter("@CourseName ", coursename);
            SqlParameter _skip = new SqlParameter("@Skip", skip);
            SqlParameter _take = new SqlParameter("@Take", take);
            SqlParameter _clientID = new SqlParameter("@ClientID", ClientID);
            SqlParameter _orgID = new SqlParameter("@OrgID",OrgID);
            return Context.Database.SqlQuery<EducationSearchResult>(Constant.StoredProcedureConst.EducationRepositoryProcedure.GetAllPagedEducationByfilter, _Coursename, _skip, _take, _clientID,_orgID);      
        }

        public IEnumerable<EducationSearchResult> GetCourseCatalogByfilter(string search, int skip, int take, int ClientID, int OrgID)
        {
            SqlParameter _search = new SqlParameter("@Search ", search);
            SqlParameter _skip = new SqlParameter("@Skip", skip);
            SqlParameter _take = new SqlParameter("@Take", take);
            SqlParameter _clientID = new SqlParameter("@ClientID", ClientID);
            SqlParameter _orgID = new SqlParameter("@OrgID", OrgID);
            if(search.ToString()=="1")
                return Context.Database.SqlQuery<EducationSearchResult>(Constant.StoredProcedureConst.EducationRepositoryProcedure.GetCourseCatalogByPreview, _skip, _take, _clientID, _orgID);
            else if (search.ToString() == "2")
                return Context.Database.SqlQuery<EducationSearchResult>(Constant.StoredProcedureConst.EducationRepositoryProcedure.GetCourseCatalogByPublished, _skip, _take, _clientID, _orgID);
            else
                return Context.Database.SqlQuery<EducationSearchResult>(Constant.StoredProcedureConst.EducationRepositoryProcedure.GetCourseCatalogByExpired, _skip, _take, _clientID, _orgID);

        }

        public int GetEducationCountByFilter(System.Linq.Expressions.Expression<Func<Education, bool>> where)
        {
            return dbset.Where(where).Count();
        }

        public int GetEducationCount()
        {
            return dbset.Count();
        }


        public IEnumerable<CourseExpirySendEmail> GETCourseExpirySendEmailAlert(int OrganizationID)
        {
            SqlParameter _organizationID = new SqlParameter("@OrganizationID", OrganizationID);
            return Context.Database.SqlQuery<CourseExpirySendEmail>(Constant.StoredProcedureConst.EducationRepositoryProcedure.GETCourseExpirySendEmailAlert, _organizationID);  
        }

        public void UpdateMyEducationCompletedToPassed(int educationID)
        {
            SqlParameter _educationID = new SqlParameter("@EducationID ", educationID);
            Context.Database.ExecuteSqlCommand(Constant.StoredProcedureConst.EducationRepositoryProcedure.UpdateMyEducationCompletedToPassed, _educationID);
        }

        public void UpdateEducationModulesTime(int educationID)
        {
            SqlParameter _educationID = new SqlParameter("@EducationID ", educationID);
            Context.Database.ExecuteSqlCommand(Constant.StoredProcedureConst.EducationRepositoryProcedure.UpdateEducationModulesTime, _educationID);
        }

        public IEnumerable<BLModel.Education> GetEducationByClientID(int ClientID)
        {
            SqlParameter _ClientID = new SqlParameter("@ClientID", ClientID);
            return Context.Database.SqlQuery<BLModel.Education>(Constant.StoredProcedureConst.EducationRepositoryProcedure.GetEducationsByClientID, _ClientID).ToList();
        }


        public IEnumerable<BL.Model.Education> GetEducationReadyToDisplayByEducationName(string educationName, int organizationID, int skip, int take)
        {
            SqlParameter _educationName = new SqlParameter("@EducationName", educationName);
            SqlParameter _organizationID = new SqlParameter("@OrganizationID", organizationID);
            SqlParameter _skip = new SqlParameter("@Skip", skip);
            SqlParameter _take = new SqlParameter("@Take", take);
            return Context.Database.SqlQuery<BL.Model.Education>(Constant.StoredProcedureConst.EducationRepositoryProcedure.GetEducationReadyToDisplayByEducationName, _educationName, _organizationID, _skip, _take);
        }

        public int GetEducationReadyToDisplayByEducationNameCount(string educationName, int organizationID)
        {
            SqlParameter _educationName = new SqlParameter("@EducationName", educationName);
            SqlParameter _organizationID = new SqlParameter("@OrganizationID", organizationID);
            return Context.Database.SqlQuery<int>(Constant.StoredProcedureConst.EducationRepositoryProcedure.GetEducationReadyToDisplayByEducationNameCount, _educationName, _organizationID).SingleOrDefault();
        }

        
    }
}