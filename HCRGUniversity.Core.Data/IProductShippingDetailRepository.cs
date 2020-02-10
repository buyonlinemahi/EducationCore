using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;

namespace HCRGUniversity.Core.Data
{
    public interface IProductShippingDetailRepository : IBaseRepository<ProductShippingDetail>
    {
        void UpdateProductShippingDetailByShippingPaymentID(ProductShippingDetail _productShippingDetail);
    }
}
