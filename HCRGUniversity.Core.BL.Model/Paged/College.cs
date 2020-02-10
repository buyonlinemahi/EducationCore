using HCRGUniversity.Core.BL.Model.Base;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.BL.Model.Paged
{
    public class College : BasePaged
    {
        public IEnumerable<BLModel.College> Colleges{ get; set; }
    }
}
