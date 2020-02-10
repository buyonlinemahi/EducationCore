using System;
using System.Collections.Generic;

namespace HCRGUniversity.Core.Data.Model
{
    public class EducationDetail
    {
        public int CollegeID { get; set; }
        public int CollegeCourseID { get; set; }
        public string CollegeName { get; set; }
        public int EducationID { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public string CourseDescription { get; set; }
        public string CourseTime { get; set; }
        public DateTime CourseUploadDate { get; set; }
        public decimal CoursePrice { get; set; }
        public bool IsActive { get; set; }
        public int TotalCount { get; set; }
        public DateTime? CourseStartDate { get; set; }
        public DateTime? CourseEndDate { get; set; }
        public int? CourseAllotedTime { get; set; }
        public string CouseAllotedDaysMonth { get; set; }
        public bool? IsPublished { get; set; }
        public bool? IsTimerRequired { get; set; }
        public bool? IsCoursePreview { get; set; }        
        public IEnumerable<EducationFormat> EducationFormat { get; set; }
      
    }
}