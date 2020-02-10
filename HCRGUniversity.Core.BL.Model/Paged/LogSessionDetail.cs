using HCRGUniversity.Core.BL.Model.Base;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;
using DLModel = HCRGUniversity.Core.Data.Model;
namespace HCRGUniversity.Core.BL.Model.Paged
{
    public class LogSessionDetail : BasePaged
    {
        public IEnumerable<DLModel.LogSessionDetail> LogSessionDetails { get; set; }
    }
}