using HCRGUniversity.Core.BL.Model.Base;
using System.Collections.Generic;
using HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.BL.Model.Paged
{
    public class Faculties : BasePaged
    {
        public IEnumerable<Faculty> FacultyDetails { get; set; }
    }
}
