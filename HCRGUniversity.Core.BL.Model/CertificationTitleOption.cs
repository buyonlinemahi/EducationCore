
namespace HCRGUniversity.Core.BL.Model
{
    public class CertificationTitleOption
    {
        public int CertificationTitleOptionID { get; set; }
        public string CertificationTitle { get; set; }
        public string CertificationContent { get; set; }
        public int EducationId { get; set; }
        public string CourseName { get; set; }
    }
}
