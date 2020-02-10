using System;

namespace HCRGUniversity.Core.Data.Model
{
    public class EducationSearchResult
    {
        public string CollegeName { get; set; }
        public string CourseName { get; set; }
        public DateTime CourseUploadDate { get; set; }
        public int NumberOfModule { get; set; }
        public int EducationID { get; set; }
        public bool? ReadyToDisplay { get; set; }
        public bool? IsPublished { get; set; }
        public bool? IsCoursePreview { get; set; }
        public string OrganizationName { get; set; }
        public string ClientName  { get; set; }
    }
}