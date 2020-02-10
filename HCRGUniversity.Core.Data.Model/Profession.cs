using System.Collections.Generic;
namespace HCRGUniversity.Core.Data.Model
{
    public class Profession :Base.BaseClientColumn
    {
        public Profession()
        {
            this.EducationProfessions = new HashSet<EducationProfession>();
        }

        public int ProfessionID { get; set; }
        public string ProfessionTitle { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<EducationProfession> EducationProfessions { get; set; }
    }
}