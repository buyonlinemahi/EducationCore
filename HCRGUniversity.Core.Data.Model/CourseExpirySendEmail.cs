using System;

namespace HCRGUniversity.Core.Data.Model
{
    public class CourseExpirySendEmail
    {
        public string CourseName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
