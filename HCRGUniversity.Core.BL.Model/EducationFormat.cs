
namespace HCRGUniversity.Core.BL.Model
{
   public class EducationFormat:Base.BaseClientColumn
    {
        public int EducationFormatID { get; set; }
        public string EducationFormatType { get; set; }
        public int EducationPriority { get; set; }
        public string OrganizationName { get; set; }
    }
}
