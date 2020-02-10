
using System;
namespace HCRGUniversity.Core.Data.Model
{
    public class MyEducationDetail
    {
        public int MEID { get; set; }
        public int UserID { get; set; }
        public int EducationID { get; set; }
        public int EducationTypeID { get; set; }
        public bool Completed { get; set; }
        public int TotalModuleCompleted { get; set; }
        public int TotalModule { get; set; }
        public int percentCompleted { get; set; }
        public string CourseFile { get; set; }
        public DateTime? CourseCompletedDate { get; set; }
        public string CourseName { get; set; }
        public bool? IsPassed { get; set; }
        public bool? Expired { get; set; }
        public bool? CertificatePrinted { get; set; }
        public string CertificateURL { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public bool AllowRevisit { get; set; }
    }
}