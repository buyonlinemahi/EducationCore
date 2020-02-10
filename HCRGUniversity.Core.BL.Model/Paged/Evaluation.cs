using HCRGUniversity.Core.BL.Model.Base;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.BL.Model.Paged
{
    public class Evaluation : BasePaged
    {
        public IEnumerable<BLModel.Evaluation> Evaluations { get; set; }
    }
}
