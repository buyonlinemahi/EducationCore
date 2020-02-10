using HCRGUniversity.Core.BL.Model.Base;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.BL.Model.Paged
{
   public class AboutUs : BasePaged
    {
       public IEnumerable<BLModel.About> AboutUsRecords { get; set; }
    }
}
