
namespace HCRGUniversity.Core.Data.Model
{
    public class EducationProfession
    {
        public int EducationProfessionID { get; set; }
        public int EducationID { get; set; }
        public int ProfessionID { get; set; }
        public bool IsActive { get; set; }
        public virtual Profession Profession { get; set; }
    }
}