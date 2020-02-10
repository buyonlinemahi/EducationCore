using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.Data
{
    public interface IEducationRepository : IBaseRepository<Education>
    {
        IEnumerable<EducationProfessionDetail> GetEducationAndProfession(int OrganizationID);
        IEnumerable<EducationFormatDetail> GetEducationAndEducationFormat(int OrganizationID);
        IEnumerable<CollegeEducationSearch> GetCollegeEducationByEducationID(int educationID);
        IEnumerable<EducationProfessionDetail> GetProfessionEducationByEducationID(int educationID);
        IEnumerable<Education> GetEducationLatest(int UserID, int OrganizationID);


        IEnumerable<EducationDetail> GetEducationCollegeByCollegeIDPaged(int collegeID, int? userId, int skip, int take, int OrganizationID);
        IEnumerable<EducationDetail> GetEducationCollegeByEducationFormatIDPaged(int formatID, int? userId, int skip, int take, int OrganizationID);
        IEnumerable<EducationDetail> GetEducationCollegeByEducationFormatIDAndCollegeIDPaged(int collegeID, int formatID, int? userId, int skip, int take, int OrganizationID);
        IEnumerable<EducationDetail> GetEducationByProfessionIDPaged(int professionID, int? userID, int skip, int take, int OrganizationID);
        IEnumerable<EducationDetail> GetEducationByEducationFormatIDORCollegeIDORDeptIDORPrfIDPaged(int? collegeID, int? formatID, int? professionID, int? UserID, int skip, int take, int OrganizationID);

        IEnumerable<EducationNewsSearch> GetEducationNewsSearchByTextPaged(string searchText,int? userId,int OrganizationID, int skip, int take);
        int GetEducationNewsSearchByTextPagedCount(string searchText, int? userid, int OrganizationID);

        IEnumerable<EducationProfessionDetail> GetAllPagedEducationProfession(int skip, int take, int OrganizationID);
        int GetEducationProfessionCount();
        IEnumerable<EducationSearchResult> GetAllPagedEducationByfilter(string coursename, int skip, int take, int ClientID,int OrgID);
        int GetEducationCountByFilter(System.Linq.Expressions.Expression<Func<Education, bool>> where);
        int GetEducationCount();
        IEnumerable<CourseExpirySendEmail> GETCourseExpirySendEmailAlert(int OrganizationID);

        void UpdateMyEducationCompletedToPassed(int educationID);
        void UpdateEducationModulesTime(int educationID);
        IEnumerable<BLModel.Education> GetEducationByClientID(int ClientID);


        IEnumerable<BL.Model.Education> GetEducationReadyToDisplayByEducationName(string educationName, int _organizationID, int skip, int take);
        int GetEducationReadyToDisplayByEducationNameCount(string educationName, int _organizationID);

        IEnumerable<EducationSearchResult> GetCourseCatalogByfilter(string _search, int skip, int take, int ClientID, int OrgID);
    }
}