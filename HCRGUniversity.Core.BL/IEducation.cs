using HCRGUniversity.Core.BL.Model;
using System;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL
{
    public interface IEducation
    {
        int AddEducation(Education education);
        int UpdateEducation(Education education);
        Education GetEducationByID(int educationID);
        IEnumerable<Education> getAllEducation();
        IEnumerable<Education> getAllEducationActive();
        IEnumerable<Education> GetEducationLatest(int UserID, int OrganizationID);
        BLModel.Paged.Education GetEducationByEducationNamePaged(string educationName, int skip, int take);
        BLModel.Paged.Education GetEducationReadyToDisplayByEducationNamePaged(string educationName, int _organizationID, int skip, int take);        
        IEnumerable<Education> GetOnSiteEducationByStartDate(DateTime startDate, DateTime endDate);
        int PublishEducation(int educationID);
        int CoursePreviewEducation(int educationID);

        //link college Education and education in collegeEduction table...hp
        int AddCollegeEducation(DLModel.CollegeEducation cEdu);
        int UpdateCollegeEducation(DLModel.CollegeEducation cEdu);
    

        //add education type...hp
        int AddEducationType(DLModel.EducationTypesAvailable eduType);
        int UpdateEducationType(DLModel.EducationTypesAvailable eduType);
        IEnumerable<DLModel.EducationTypesAvailable> GetEducationTypeByEducationID(int educationID);

        //get data from stored procedure for all education page......hp
        BLModel.Paged.Education GetEducationCollegeAllPaged(int skip, int take);
        BLModel.Paged.Education GetEducationCollegeByEducationFormatIDPaged(int formatID, int? userId, int skip, int take, int OrganizationID);
        BLModel.Paged.Education GetEducationCollegeByEducationFormatIDAndCollegeIDPaged(int collegeID, int formatID, int? userId, int skip, int take, int OrganizationID);
        BLModel.Paged.Education GetEducationByProfessionIDPaged(int professionID, int? userID, int skip, int take, int OrganizationID);
        BLModel.Paged.Education GetEducationByEducationFormatIDORCollegeIDORDeptIDORPrfIDPaged(int? collegeID, int? formatID, int? professionID, int? UserID, int skip, int take, int OrganizationID);
        BLModel.Paged.Education GetEducationCollegeByCollegeIDPaged(int collegeID, int? userid, int skip, int take, int OrganizationID);


        BLModel.Paged.EducationNewsSearch GetEducationNewsSearchByTextPaged(string searchText, int? userid, int OrganizationID, int skip, int take);

        //get data from stored procedure for college Education by education id on education add page......hp
        IEnumerable<DLModel.CollegeEducationSearch> GetCollegeEducationByEducationID(int educationID);

        //get profession and education
        IEnumerable<DLModel.EducationProfessionDetail> GetEducationAndProfession(int OrganizationID);

        //get education format and education
        IEnumerable<DLModel.EducationFormatDetail> GetEducationAndEducationFormat(int OrganizationID);

        //add and update education detail page for each education...hp
        int AddEducationDetailPageContent(DLModel.EducationDetailPage eduDetailPage);
        int UpdateEducationDetailPageContent(DLModel.EducationDetailPage eduDetailPage);
        DLModel.EducationDetailPageWithEducation GetEducationDetailPageContent(int educationID);

        BLModel.Paged.EducationProfession GetAllPagedEducationProfession(int skip, int take, int OrganizationID);

        BLModel.Paged.Education GetAllPagedEducationByfilter(string coursename, int skip, int take, int ClientID,int OrgID);


        BLModel.Paged.Education GetCourseCatalogByfilter(string _search, int skip, int take, int ClientID, int OrgID);

        //get data from stored procedure for Profession Education by education id on education add page......
        IEnumerable<DLModel.EducationProfessionDetail> GetProfessionEducationByEducationID(int educationID);


        IEnumerable<DLModel.CourseExpirySendEmail> GETCourseExpirySendEmailAlert(int OrganizationID);

        /// uPDATE isPASSED WHEN cOURSE COMPLETED AND eXAM AND EVALUTION REMOVED FROM ADMIN
        /// 
        void UpdateMyEducationCompletedToPassed(int educationID);
        //Update Education Modules Time in admin preview course.
        void UpdateEducationModulesTime(int educationID);

        IEnumerable<BLModel.Education> GetEducationByClientID(int ClientID);
    }
}