using HCRGUniversity.Core.BL.Model.Base;
using System.Collections.Generic;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL.Model.Paged
{
    public class ProductShippingDetail : BasePaged
    {
        public IEnumerable<DLModel.ProductShippingDetail> ProductShippingDetails { get; set; }
    }
}
