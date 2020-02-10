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
    public class EducationTest
    {
        private IEducationRepository _educationRepository;
        private ICollegeEducationRepository _collegeEducationRepository;
        private IEducationFormatAvailableRepository _educationFormatAvailableRepository;
        private IEducation _educationBL;
        private IEducationTypesAvailableRepository _educationTypesAvailableRepository;
        private IEducationDetailPageRepository _educationDetailPageRepository;
        private INewsRepository _newsRepository;
        private IOrganizationRepository _organizationRepository;

        private HCRGUniversity.Core.BL.Model.Education BLModel = new HCRGUniversity.Core.BL.Model.Education();
        private HCRGUniversity.Core.Data.Model.CollegeEducation DLModel = new HCRGUniversity.Core.Data.Model.CollegeEducation();
        private HCRGUniversity.Core.Data.Model.EducationTypesAvailable DLModelEdutype = new HCRGUniversity.Core.Data.Model.EducationTypesAvailable();
        private HCRGUniversity.Core.Data.Model.EducationDetailPage DLModelEduDetailPage = new HCRGUniversity.Core.Data.Model.EducationDetailPage();

        [TestInitialize]
        public void EducationInitialize()
        {
            _educationRepository = new EducationRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _collegeEducationRepository = new CollegeEducationRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _educationFormatAvailableRepository = new EducationFormatAvialableRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _educationTypesAvailableRepository = new EducationTypesAvailableRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _educationDetailPageRepository = new EducationDetailPageRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _newsRepository = new NewsRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _organizationRepository = new OrganizationRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _educationBL = new EducationImpl(_educationRepository, _collegeEducationRepository, _educationFormatAvailableRepository, _educationTypesAvailableRepository, _educationDetailPageRepository, _newsRepository, _organizationRepository);
        }

        [TestMethod]
        public void AddEducation()
        {
            BLModel.CourseName = "testing Timer";
            BLModel.CourseDescription = "testing tesing";
            BLModel.CourseTime = "4";
            BLModel.CourseCredential = true;
            BLModel.CourseFile = "testfile";
            BLModel.CourseStartDate = DateTime.Parse("7/8/2000");
            BLModel.CourseEndDate = DateTime.Parse("7/8/2012");
            BLModel.CoursePresenterName = "harry";
            BLModel.CouseAllotedDaysMonth = "Days";
            BLModel.CourseAllotedTime = 4;
            BLModel.CourseStartTime = "asdf";
            BLModel.IsTimerRequired = false;
            BLModel.IndustryID = 2;
            BLModel.ClientID = 1;
            int result = _educationBL.AddEducation(BLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }
        [TestMethod]
        public void UpdateEducation()
        {
            BLModel.CourseName = "testing";
            BLModel.CourseDescription = "testing";
            BLModel.CourseTime = "4";
            BLModel.CourseCredential = false;
            BLModel.CourseCode = "sdf";
            BLModel.EducationID = 28;
            BLModel.AllowRevisit = true;
            BLModel.IndustryID = 1;
            BLModel.ClientID = 14;
            BLModel.EducationID = 15;
            int result = _educationBL.UpdateEducation(BLModel);
            Assert.IsTrue(result > 0, "Unable to update");
        }

        [TestMethod]
        public void Publisheducation()
        {
            int result = _educationBL.PublishEducation(559);
            Assert.IsTrue(result > 0, "Unable to update");
        }

        [TestMethod]
        public void getAllEducation()
        {
            IEnumerable<HCRGUniversity.Core.BL.Model.Education> education = _educationBL.getAllEducation();
            Assert.IsTrue(education != null, "Unable to get");
        }

        [TestMethod]
        public void getAllEducationActive()
        {
            IEnumerable<HCRGUniversity.Core.BL.Model.Education> education = _educationBL.getAllEducationActive();
            Assert.IsTrue(education != null, "Unable to get");
        }


        [TestMethod]
        public void getEducationLatest()
        {
            IEnumerable<HCRGUniversity.Core.BL.Model.Education> education = _educationBL.GetEducationLatest(229,100);
            Assert.IsTrue(education != null, "Unable to get");
        }
        
        [TestMethod]
        public void GetEducationByEducationNamePaged()
        {
            var education = _educationBL.GetEducationByEducationNamePaged("s", 0, 3);
            Assert.IsTrue(education != null, "Unable to get");
        }

        [TestMethod]
        public void GetOnSiteEducationByStartDate()
        {
            var education = _educationBL.GetOnSiteEducationByStartDate(DateTime.Now.Date, DateTime.Now.Date.AddDays(10));
            Assert.IsTrue(education != null, "Unable to get");
        }


        [TestMethod]
        public void getEducationByID()
        {
            HCRGUniversity.Core.BL.Model.Education education = _educationBL.GetEducationByID(21);
            Assert.IsTrue(education != null, "Unable to get");
        }


        //link college education and education in collegeEduction table...hp
        [TestMethod]
        public void AddCollegeEducation()
        {
            DLModel.CollegeID = 4;
            DLModel.EducationID = 1;
            // DLModel.IsActive = true;
            int result = _educationBL.AddCollegeEducation(DLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }
        [TestMethod]
        public void UpdateCollegeEducation()
        {
            DLModel.CollegeID = 1;
            DLModel.EducationID = 2;
            DLModel.CollegeCourseID = 1;
            int result = _educationBL.UpdateCollegeEducation(DLModel);
            Assert.IsTrue(result > 0, "Unable to update");
        }

        //get data from stored procedure for all education page......hp
        [TestMethod]
        public void GetEducationCollegeByCollegeID()
        {
            BLModel.Paged.Education educationDetail = _educationBL.GetEducationCollegeByCollegeIDPaged(60,167, 1, 10,1);
            Assert.IsTrue(educationDetail != null, "Unable to get");
        }

        [TestMethod]
        public void GetEducationCollegeByEducationFormatID()
        {
            BLModel.Paged.Education educationDetail = _educationBL.GetEducationCollegeByEducationFormatIDPaged(1,167, 0, 10,1);
            Assert.IsTrue(educationDetail != null, "Unable to get");
        }

        [TestMethod]
        public void GetEducationCollegeByEducationFormatIDAndCollegeID()
        {
            BLModel.Paged.Education educationDetail = _educationBL.GetEducationCollegeByEducationFormatIDAndCollegeIDPaged(60, 1,167, 1, 10,1);
            Assert.IsTrue(educationDetail != null, "Unable to get");
        }
        [TestMethod]
        public void GetEducationCollegePaged()
        {
            HCRGUniversity.Core.BL.Model.Paged.Education educationDetail = _educationBL.GetEducationCollegeAllPaged(0, 10);
            Assert.IsTrue(educationDetail != null, "Unable to get");
        }
     

        [TestMethod]
        public void GetEducationByProfessionID()
        {
            BLModel.Paged.Education educationDetail = _educationBL.GetEducationByProfessionIDPaged(2,167, 0, 10,1);
            Assert.IsTrue(educationDetail != null, "Unable to get");
        }

        [TestMethod]
        public void GetEducationByEducationFormatIDORCollegeIDORDeptIDORPrfID()
        {
            BLModel.Paged.Education educationDetail = _educationBL.GetEducationByEducationFormatIDORCollegeIDORDeptIDORPrfIDPaged(null, null, null,null, 0, 10,1);
            Assert.IsTrue(educationDetail != null, "Unable to get");
        }

        [TestMethod]
        public void GetEducationNewsSearchByTextPaged()
        {
            var educationDetail = _educationBL.GetEducationNewsSearchByTextPaged("gurl",10,1, 0, 162);
            Assert.IsTrue(educationDetail != null, "Unable to get");
        }

        [TestMethod]
        public void GetEducationAndProfession()
        {
            IEnumerable<HCRGUniversity.Core.Data.Model.EducationProfessionDetail> educationDetail = _educationBL.GetEducationAndProfession(1);
            Assert.IsTrue(educationDetail != null, "Unable to get");
        }

        [TestMethod]
        public void GetEducationAndEducationFormat()
        {
            IEnumerable<HCRGUniversity.Core.Data.Model.EducationFormatDetail> educationDetail = _educationBL.GetEducationAndEducationFormat(1);
            Assert.IsTrue(educationDetail != null, "Unable to get");
        }

        [TestMethod]
        public void GetCollegeEducationByEducationID()
        {
            var collegeDept = _educationBL.GetCollegeEducationByEducationID(2);
            Assert.IsTrue(collegeDept != null, "Unable to get");
        }

        [TestMethod]
        public void GetProfessionEducationByEducationID()
        {
            var prof = _educationBL.GetProfessionEducationByEducationID(2);
            Assert.IsTrue(prof != null, "Unable to get");
        }

        [TestMethod]
        public void GetEducationReadyToDisplayByEducationNamePaged()
        {
            var prof = _educationBL.GetEducationReadyToDisplayByEducationNamePaged("c",100,0,100);
            Assert.IsTrue(prof != null, "Unable to get");
        }

        [TestMethod]
        public void AddEducationType()
        {
            DLModelEdutype.EducationTypeID = 1;
            DLModelEdutype.EducationID = 1;
            DLModelEdutype.Price = 12;
            int result = _educationBL.AddEducationType(DLModelEdutype);
            Assert.IsTrue(result > 0, "Unable to Add");
        }

        [TestMethod]
        public void UpdateEducationType()
        {
            DLModelEdutype.EducationTypeID = 1;
            DLModelEdutype.EducationID = 2;
            DLModelEdutype.EducationTypeAID = 1;
            DLModelEdutype.Price = 19;
            int result = _educationBL.UpdateEducationType(DLModelEdutype);
            Assert.IsTrue(result > 0, "Unable to Add");
        }

        [TestMethod]
        public void getEducationTypeByEducationID()
        {
            var result = _educationBL.GetEducationTypeByEducationID(1);
            Assert.IsTrue(result != null, "Unable to Add");
        }

        //add and update education detail page for each education...hp
        [TestMethod]
        public void AddEducationDetailPageContent()
        {
            DLModelEduDetailPage.EducationID = 1;
            DLModelEduDetailPage.PContent = "sdfsdfsadf";
            DLModelEduDetailPage.PDate = System.DateTime.Now.Date;
            var result = _educationBL.AddEducationDetailPageContent(DLModelEduDetailPage);
            Assert.IsTrue(result > 0, "Unable to Add");
        }
        [TestMethod]
        public void UpdateEducationDetailPageContent()
        {
            DLModelEduDetailPage.EPageID = 1;
            DLModelEduDetailPage.EducationID = 1;
            DLModelEduDetailPage.PContent = "harry";
            DLModelEduDetailPage.PDate = System.DateTime.Now.Date;
            var result = _educationBL.UpdateEducationDetailPageContent(DLModelEduDetailPage);
            Assert.IsTrue(result > 0, "Unable to Add");
        }
        [TestMethod]
        public void getEducationDetailPageContent()
        {

            var result = _educationBL.GetEducationDetailPageContent(2);
            //Assert.IsTrue(result, "Unable to Add");
        }

        [TestMethod]
        public void GetAllPagedEducationProfession()
        {
            var Eduprf = _educationBL.GetAllPagedEducationProfession(0, 10,1);
            Assert.IsTrue(Eduprf != null, "Unable to find");
        }

        [TestMethod]
        public void GetAllPagedEducationByfilter()
        {
            var Edu = _educationBL.GetAllPagedEducationByfilter("g", 0, 10,1,1);
            Assert.IsTrue(Edu != null, "Unable to find");
        }


        [TestMethod]
        public void GetCourseCatalogByfilter()
        {
            // "1" = Preview
            // "2" = Published  
            // "3" = Expired
            var Edu = _educationBL.GetCourseCatalogByfilter("3", 0, 10, 14, 100);
            Assert.IsTrue(Edu != null, "Unable to find");
        }

        [TestMethod]
        public void GETCourseExpirySendEmailAlert()
        {
            var Edu = _educationBL.GETCourseExpirySendEmailAlert(1);
            Assert.IsTrue(Edu != null, "Unable to find");
        }

        [TestMethod]
        public void getEducationByClientID()
        {

            var result = _educationBL.GetEducationByClientID(2);
            //Assert.IsTrue(result, "Unable to Add");
        }
    }
}