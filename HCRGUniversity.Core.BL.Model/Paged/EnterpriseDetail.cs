using HCRGUniversity.Core.BL.Model.Base;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;

namespace HCRGUniversity.Core.BL.Model.Paged
{
    public class EnterpriseDetail : BasePaged
    {
        public IEnumerable<Enterprise> EnterpriseDetails { get; set; }  
    }
}
