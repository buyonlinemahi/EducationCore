
namespace HCRGUniversity.Core.BL.Model
{
   public class Profession:Base.BaseClientColumn
    {
        public int ProfessionID { get; set; }
        public string ProfessionTitle { get; set; }
        public bool IsActive { get; set; }
        public string OrganizationName { get; set; }
    }
}
