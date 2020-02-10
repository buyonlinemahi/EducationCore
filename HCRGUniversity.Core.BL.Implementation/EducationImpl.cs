using HCRGUniversity.Core.Data;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;
using BLModel = HCRGUniversity.Core.BL.Model;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL.Implementation
{
    public class EducationImpl : IEducation
    {
        private readonly IEducationRepository _eduRepository;
        private readonly ICollegeEducationRepository _collegeEducationRepository;
        private readonly IEducationFormatAvailableRepository _educationFormatAvailableRepository;
        private readonly IEducationTypesAvailableRepository _educationTypesAvailableRepository;
        private readonly IEducationDetailPageRepository _educationDetailPageRepository;
        private readonly INewsRepository _newsRepository;
        private readonly IOrganizationRepository _organizationRepository;

        public EducationImpl(IEducationRepository eduRepository, ICollegeEducationRepository collegeEducationRepository, IEducationFormatAvailableRepository educationFormatAvailableRepository, IEducationTypesAvailableRepository educationTypesAvailableRepository, IEducationDetailPageRepository educationDetailPageRepository, INewsRepository newsRepository, IOrganizationRepository organizationRepository)
        {
            _eduRepository = eduRepository;
            _collegeEducationRepository = collegeEducationRepository;
            _educationFormatAvailableRepository = educationFormatAvailableRepository;
            _educationTypesAvailableRepository = educationTypesAvailableRepository;
            _educationDetailPageRepository = educationDetailPageRepository;
            _newsRepository = newsRepository;
            _organizationRepository = organizationRepository;
        }

        public int AddEducation(BLModel.Education education)
        {
            return _eduRepository.Add((DLModel.Education)new DLModel.Education().InjectFrom(education)).EducationID;
        }

        public int UpdateEducation(BLModel.Education education)
        {
            return _eduRepository.Update((DLModel.Education)new DLModel.Education().InjectFrom(education));
        }

        public int PublishEducation(int educationID)
        {
            DLModel.Education edu = new DLModel.Education
            {
                EducationID = educationID,
                IsPublished = true,
                IsCoursePreview = null
            };
            return _eduRepository.Update(edu, ed => ed.IsPublished, ed => ed.IsCoursePreview);
        }

        public int CoursePreviewEducation(int educationID)
        {
            DLModel.Education edu = new DLModel.Education
            {
                EducationID = educationID,
                IsCoursePreview = true
            };
            return _eduRepository.Update(edu, ed => ed.IsCoursePreview);
        }

        public BLModel.Education GetEducationByID(int educationID)
        {
            return (BLModel.Education)new BLModel.Education().InjectFrom(_eduRepository.GetById(educationID));
        }

        public IEnumerable<BLModel.Education> getAllEducation()
        {
            return _eduRepository.GetAll().Select(edu => new BLModel.Education().InjectFrom(edu)).Cast<BLModel.Education>().OrderBy(education => education.EducationID).ToList();
        }

        public IEnumerable<BLModel.Education> getAllEducationActive()
        {
            return _eduRepository.GetAll(hp => hp.IsActive != false).Select(edu => new BLModel.Education().InjectFrom(edu)).Cast<BLModel.Education>().OrderBy(education => education.CourseName).ToList();
        }


        public IEnumerable<BLModel.Education> GetEducationLatest(int UserID, int OrganizationID)
        {
            IEnumerable<BLModel.Education> _education = _eduRepository.GetEducationLatest(UserID, OrganizationID).Select(edu => new BLModel.Education().InjectFrom(edu)).Cast<BLModel.Education>().ToList();
            return _education;
        }

        public BLModel.Paged.Education GetEducationByEducationNamePaged(string educationName, int skip, int take)
        {
            return new BLModel.Paged.Education
            {
                _educations = _eduRepository.GetDbSet().ToList().Where(hp => (hp.IsActive != false) && (hp.CourseName.ToLower().StartsWith(educationName.ToLower()))).OrderBy(education => education.EducationID).Skip(skip).Take(take).Select(edu => new BLModel.Education().InjectFrom(edu)).Cast<BLModel.Education>().ToList(),
                TotalCount = _eduRepository.GetDbSet().ToList().Where(hp => (hp.IsActive != false) && (hp.CourseName.ToLower().StartsWith(educationName.ToLower()))).Count()
            };
        }

        public BLModel.Paged.Education GetEducationReadyToDisplayByEducationNamePaged(string educationName, int _organizationID, int skip, int take)
        {
            if (_organizationRepository.GetById(_organizationID).IsOrganizationAdmin)
            {
                return new BLModel.Paged.Education
                {
                    _educations = _eduRepository.GetDbSet().ToList().Where(hp => (hp.IsActive != false) && (hp.CourseName.ToLower().StartsWith(educationName.ToLower())) && (hp.ReadyToDisplay != false) && (hp.IsCoursePreview != true)).OrderBy(education => education.EducationID).Skip(skip).Take(take).Select(edu => new BLModel.Education().InjectFrom(edu)).Cast<BLModel.Education>().ToList(),
                    TotalCount = _eduRepository.GetDbSet().ToList().Where(hp => (hp.IsActive != false) && (hp.CourseName.ToLower().StartsWith(educationName.ToLower())) && (hp.ReadyToDisplay != false) && (hp.IsCoursePreview != true)).Count()
                };
            }
            else
            {
                return new BLModel.Paged.Education
                {
                    _educations = _eduRepository.GetEducationReadyToDisplayByEducationName(educationName, _organizationID, skip, take).Select(edu => new BLModel.Education().InjectFrom(edu)).Cast<BLModel.Education>().ToList(),
                    TotalCount = _eduRepository.GetEducationReadyToDisplayByEducationNameCount(educationName, _organizationID)
                };
            }
        }

        public IEnumerable<BLModel.Education> GetOnSiteEducationByStartDate(DateTime startDate, DateTime endDate)
        {
            return (from _edu in _eduRepository.GetDbSet().ToList()
                    join _eduFormat in _educationFormatAvailableRepository.GetDbSet().ToList()
                    on _edu.EducationID equals _eduFormat.EducationID
                    where (_edu.CourseStartDate >= startDate) && (_edu.CourseStartDate <= endDate) && (_edu.IsActive != false) && (_edu.ReadyToDisplay != false)
                           && (_eduFormat.IsActive != false) && (_eduFormat.EducationFormatID == Global.GlobalConst.EducationFormats.OnSiteEducationID)
                    orderby (_edu.EducationID)
                    select _edu).Select(edu => new BLModel.Education().InjectFrom(edu)).Cast<BLModel.Education>().ToList();
        }



        //link college Educatoin and education in collegeEduction table...hp
        public int AddCollegeEducation(DLModel.CollegeEducation cEdu)
        {
            return _collegeEducationRepository.Add(cEdu).CollegeCourseID;
        }

        public int UpdateCollegeEducation(DLModel.CollegeEducation cEdu)
        {
            return _collegeEducationRepository.Update(cEdu);
        }


        //get data from stored procedure for all education page......hp
        //paging
        public BLModel.Paged.Education GetEducationCollegeByCollegeIDPaged(int collegeID, int? userid, int skip, int take, int OrganizationID)
        {
            BLModel.Paged.Education _education = new BLModel.Paged.Education
            {
                educationsDetail = AddEducationFormat(_eduRepository.GetEducationCollegeByCollegeIDPaged(collegeID, userid, skip, take, OrganizationID).ToList()),
            };
            _education.TotalCount = (_education.educationsDetail.Count() > 0) ? _education.educationsDetail.First().TotalCount : _education.educationsDetail.Count();
            return _education;
        }

        public BLModel.Paged.Education GetEducationCollegeByEducationFormatIDPaged(int formatID, int? userId, int skip, int take, int OrganizationID)
        {
            BLModel.Paged.Education _education = new BLModel.Paged.Education
            {
                educationsDetail = AddEducationFormat(_eduRepository.GetEducationCollegeByEducationFormatIDPaged(formatID, userId, skip, take, OrganizationID).ToList()),
            };
            _education.TotalCount = (_education.educationsDetail.Count() > 0) ? _education.educationsDetail.First().TotalCount : _education.educationsDetail.Count();
            return _education;
        }

        public BLModel.Paged.Education GetEducationCollegeByEducationFormatIDAndCollegeIDPaged(int collegeID, int formatID, int? userid, int skip, int take, int OrganizationID)
        {
            BLModel.Paged.Education _education = new BLModel.Paged.Education
            {
                educationsDetail = AddEducationFormat(_eduRepository.GetEducationCollegeByEducationFormatIDAndCollegeIDPaged(collegeID, formatID, userid, skip, take, OrganizationID).ToList()),
            };
            _education.TotalCount = (_education.educationsDetail.Count() > 0) ? _education.educationsDetail.First().TotalCount : _education.educationsDetail.Count();
            return _education;
        }

        public BLModel.Paged.Education GetEducationCollegeAllPaged(int skip, int take)
        {
            BLModel.Paged.Education _education = new BLModel.Paged.Education
            {
                educationsDetail = AddEducationFormat(_eduRepository.GetDbSet().OrderByDescending(hp => hp.CourseUploadDate).ThenByDescending(hp => hp.EducationID).Skip(skip).Take(take).ToList().Select(dept => new DLModel.EducationDetail().InjectFrom(dept)).Cast<DLModel.EducationDetail>().ToList()),
                TotalCount = _eduRepository.GetDbSet().OrderByDescending(hp => hp.CourseUploadDate).Count()
            };
            return _education;
        }


        public BLModel.Paged.Education GetEducationByProfessionIDPaged(int professionID, int? userID, int skip, int take, int OrganizationID)
        {
            BLModel.Paged.Education _education = new BLModel.Paged.Education
            {
                educationsDetail = AddEducationFormat(_eduRepository.GetEducationByProfessionIDPaged(professionID, userID, skip, take, OrganizationID).ToList()),
            };
            _education.TotalCount = (_education.educationsDetail.Count() > 0) ? _education.educationsDetail.First().TotalCount : _education.educationsDetail.Count();
            return _education;
        }

        public BLModel.Paged.Education GetEducationByEducationFormatIDORCollegeIDORDeptIDORPrfIDPaged(int? collegeID, int? formatID, int? professionID, int? UserID, int skip, int take, int OrganizationID)
        {
            BLModel.Paged.Education _education = new BLModel.Paged.Education
            {
                educationsDetail = AddEducationFormat(_eduRepository.GetEducationByEducationFormatIDORCollegeIDORDeptIDORPrfIDPaged(collegeID, formatID, professionID, UserID, skip, take, OrganizationID).ToList()),
            };
            _education.TotalCount = (_education.educationsDetail.Count() > 0) ? _education.educationsDetail.First().TotalCount : _education.educationsDetail.Count();
            return _education;
        }

        public BLModel.Paged.EducationNewsSearch GetEducationNewsSearchByTextPaged(string searchText, int? userid, int OrganizationID, int skip, int take)
        {
            BLModel.Paged.EducationNewsSearch _educationNews = new BLModel.Paged.EducationNewsSearch
            {
                educationNewsSearch = _eduRepository.GetEducationNewsSearchByTextPaged(searchText, userid, OrganizationID, skip, take).ToList(),
                TotalCount = _eduRepository.GetEducationNewsSearchByTextPagedCount(searchText, userid, OrganizationID)
            };
            return _educationNews;
        }

        private IEnumerable<DLModel.EducationDetail> AddEducationFormat(IEnumerable<DLModel.EducationDetail> _education)
        {
            foreach (DLModel.EducationDetail education in _education)
            {
                education.EducationFormat = _educationFormatAvailableRepository.GetEducationFormatsByEducationID(education.EducationID).Select(hp => new DLModel.EducationFormat().InjectFrom(hp)).Cast<DLModel.EducationFormat>().ToList();
            }
            return _education;
        }

        public IEnumerable<DLModel.CollegeEducationSearch> GetCollegeEducationByEducationID(int educationID)
        {
            return _eduRepository.GetCollegeEducationByEducationID(educationID).OrderBy(clgDept => clgDept.CollegeCourseID).ToList();
        }

        public IEnumerable<DLModel.EducationProfessionDetail> GetProfessionEducationByEducationID(int educationID)
        {
            return _eduRepository.GetProfessionEducationByEducationID(educationID).OrderBy(prof => prof.EducationProfessionID).ToList();
        }

        // Get profession and education

        public IEnumerable<DLModel.EducationProfessionDetail> GetEducationAndProfession(int OrganizationID)
        {
            IEnumerable<DLModel.EducationProfessionDetail> _educationProf = _eduRepository.GetEducationAndProfession(OrganizationID).OrderBy(hp => hp.EducationProfessionID).ToList();
            return _educationProf;
        }

        //get education format and education
        public IEnumerable<DLModel.EducationFormatDetail> GetEducationAndEducationFormat(int OrganizationID)
        {
            IEnumerable<DLModel.EducationFormatDetail> _educationFormat = _eduRepository.GetEducationAndEducationFormat(OrganizationID).OrderBy(hp => hp.EducationAvailableID).ToList();
            return _educationFormat;
        }

        //add education type...hp
        public int AddEducationType(DLModel.EducationTypesAvailable eduType)
        {
            return _educationTypesAvailableRepository.Add((DLModel.EducationTypesAvailable)new DLModel.EducationTypesAvailable().InjectFrom(eduType)).EducationTypeAID;
        }

        public int UpdateEducationType(DLModel.EducationTypesAvailable eduType)
        {
            return _educationTypesAvailableRepository.Update((DLModel.EducationTypesAvailable)new DLModel.EducationTypesAvailable().InjectFrom(eduType));
        }

        public IEnumerable<DLModel.EducationTypesAvailable> GetEducationTypeByEducationID(int educationID)
        {
            return _educationTypesAvailableRepository.GetAll(hp => hp.EducationID == educationID);
        }

        //add and update education detail page for each education...hp
        public int AddEducationDetailPageContent(DLModel.EducationDetailPage eduDetailPage)
        {
            return _educationDetailPageRepository.Add(eduDetailPage).EPageID;
        }

        public int UpdateEducationDetailPageContent(DLModel.EducationDetailPage eduDetailPage)
        {
            return _educationDetailPageRepository.Update(eduDetailPage);
        }

        public DLModel.EducationDetailPageWithEducation GetEducationDetailPageContent(int educationID)
        {
            return _educationDetailPageRepository.GetEducationDetailPageContent(educationID);
        }




        //*******************Lazy binding
        public BLModel.Paged.EducationProfession GetAllPagedEducationProfession(int skip, int take, int OrganizationID)
        {
            return new BLModel.Paged.EducationProfession
            {
                TotalCount = _eduRepository.GetEducationProfessionCount(),
                EducationProfessions = _eduRepository.GetAllPagedEducationProfession(skip, take,OrganizationID).ToList()
            };
        }

        public BLModel.Paged.Education GetAllPagedEducationByfilter(string coursename, int skip, int take, int ClientID,int OrgID)
        {
            int count = 0;
            if (coursename == "%")
            {
                count = _eduRepository.GetEducationCount();
            }
            else
            {
                count = _eduRepository.GetEducationCountByFilter(education => (education.CourseName.StartsWith(coursename)));
            }
            return new BLModel.Paged.Education
            {

                TotalCount = count,
                Educations = _eduRepository.GetAllPagedEducationByfilter(coursename, skip, take, ClientID, OrgID).ToList()
            };
        }

        public BLModel.Paged.Education GetCourseCatalogByfilter(string _search, int skip, int take, int ClientID, int OrgID)
        {

            return new BLModel.Paged.Education
            {
                TotalCount = _eduRepository.GetEducationCount(),
                Educations = _eduRepository.GetCourseCatalogByfilter(_search, skip, take, ClientID, OrgID).ToList()
            };

        }

        public IEnumerable<DLModel.CourseExpirySendEmail> GETCourseExpirySendEmailAlert(int OrganizationID)
        {
            IEnumerable<DLModel.CourseExpirySendEmail> _CourseExpirySendEmailAlert = _eduRepository.GETCourseExpirySendEmailAlert(OrganizationID).ToList();
            return _CourseExpirySendEmailAlert;
        }
        /// uPDATE isPASSED WHEN cOURSE COMPLETED AND eXAM AND EVALUTION REMOVED FROM ADMIN

        public void UpdateMyEducationCompletedToPassed(int educationID)
        {
            _eduRepository.UpdateMyEducationCompletedToPassed(educationID);
        }
        //Update Education Modules Time in admin preview course.
        public void UpdateEducationModulesTime(int educationID)
        {
            _eduRepository.UpdateEducationModulesTime(educationID);
        }

        public IEnumerable<BLModel.Education> GetEducationByClientID(int ClientID)
        {
            return _eduRepository.GetEducationByClientID(ClientID);
        }

    }
}