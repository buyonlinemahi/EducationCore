using System;
namespace HCRGUniversity.Core.BL.Model
{
    public class Education : Base.BaseClientColumn
    {
        public int EducationID { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public string CourseDescription { get; set; }
        public string CourseTime { get; set; }
        public bool CourseCredential { get; set; }
        public DateTime CourseUploadDate { get; set; }
        public decimal CoursePrice { get; set; }
        public bool IsActive { get; set; }
        public string CourseFile { get; set; }
        public DateTime? CourseStartDate { get; set; }
        public DateTime? CourseEndDate { get; set; }
        public string CoursePresenterName { get; set; }
        public string CourseLocation { get; set; }
        public string CourseStartTime { get; set; }
        public string CourseEndTime { get; set; }
        public DateTime? CourseDate { get; set; }
        public int? CourseAllotedTime { get; set; }
        public string CouseAllotedDaysMonth { get; set; }
        public bool? ReadyToDisplay  { get; set; }
        public bool? AllowRevisit { get; set; }
        public bool? IsPublished { get; set; }
        public bool? IsTimerRequired { get; set; }
        public bool? IsProgramRequired { get; set; }
        public int? StateID { get; set; }
        public bool? IsCoursePreview { get; set; }
        public int IndustryID { get; set; }
        public string OrganizationName { get; set; }

    }
}
