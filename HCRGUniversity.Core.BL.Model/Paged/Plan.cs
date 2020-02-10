using HCRGUniversity.Core.BL.Model.Base;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.BL.Model.Paged
{
    public class Plan : BasePaged
    {
        public IEnumerable<BLModel.Plan> PlanRecords { get; set; }
    }
}
