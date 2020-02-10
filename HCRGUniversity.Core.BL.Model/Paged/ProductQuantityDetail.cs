using HCRGUniversity.Core.BL.Model.Base;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;

namespace HCRGUniversity.Core.BL.Model.Paged
{
    public class ProductQuantityDetail : BasePaged
    {
        public IEnumerable<ProductQuantity> ProductQuantityDetails { get; set; }  
    }
}
