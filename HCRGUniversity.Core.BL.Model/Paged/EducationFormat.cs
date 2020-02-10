using HCRGUniversity.Core.BL.Model.Base;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL.Model.Paged
{
    public class EducationFormat : BasePaged
    {
        public IEnumerable<BLModel.EducationFormat> EducationFormats { get; set; }
    }
}
