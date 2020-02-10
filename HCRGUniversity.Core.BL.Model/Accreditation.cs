
namespace HCRGUniversity.Core.BL.Model
{
   public class Accreditation:Base.BaseOrganizationColumn
    {
        public int AccreditationID { get; set; }
        public string AccreditationContent { get; set; }
        public string OrganizationName { get; set; }
    }
}
