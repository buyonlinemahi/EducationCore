using HCRGUniversity.Core.BL.Model.Base;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.BL.Model.Paged
{
    public class CoursePlan : BasePaged
    {
        public IEnumerable<BLModel.CoursePlan> CoursePlanRecords { get; set; }
    }
}
