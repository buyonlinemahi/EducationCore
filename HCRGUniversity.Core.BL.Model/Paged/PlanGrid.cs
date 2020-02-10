using HCRGUniversity.Core.BL.Model.Base;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.BL.Model.Paged
{
    public class PlanGrid : BasePaged
    {
        public IEnumerable<BLModel.PlanGrid> PlanRecords { get; set; }
    }
}
