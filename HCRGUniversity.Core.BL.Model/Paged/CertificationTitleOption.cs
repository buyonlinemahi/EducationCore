using HCRGUniversity.Core.BL.Model.Base;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;
namespace HCRGUniversity.Core.BL.Model.Paged
{
    public class CertificationTitleOption : BasePaged
    {
        public IEnumerable<BLModel.CertificationTitleOption> CertificationTitleOptionDetails { get; set; }
    }
}
