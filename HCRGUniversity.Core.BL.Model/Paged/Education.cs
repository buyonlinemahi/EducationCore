using HCRGUniversity.Core.BL.Model.Base;
using System.Collections.Generic;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL.Model.Paged
{
    public class Education : BasePaged
    {
        public IEnumerable<DLModel.EducationSearchResult> Educations { get; set; }
        public IEnumerable<DLModel.EducationDetail> educationsDetail { get; set; }
        public IEnumerable<BL.Model.Education> _educations { get; set; }
    }
}
