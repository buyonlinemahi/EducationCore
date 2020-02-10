using System.Collections.Generic;
using HCRGUniversity.Core.BL.Model.Base;
using DLModel=HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL.Model.Paged
{
    public class Events : BasePaged
    {
        public IEnumerable<DLModel.EventDetail> _events { get; set; }
    }
}