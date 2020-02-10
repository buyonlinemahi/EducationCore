using HCRGUniversity.Core.BL.Model.Base;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.BL.Model.Paged
{
    public class User : BasePaged
    {
        public IEnumerable<BLModel.User> Users { get; set; }
    }
}
