using HCRGUniversity.Core.Data.Model;
using BLModel = HCRGUniversity.Core.BL.Model;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL
{
    public interface IProductShippingDetail
    {
        int AddProductShippingDetail(ProductShippingDetail _productShippingDetail);
        int UpdateProductShippingDetail(ProductShippingDetail _productShippingDetail);
        ProductShippingDetail GetProductShippingDetailByID(int _productShippingDetailID);
        DLModel.ProductShippingDetail GetProductShippingDetailByProductShippingID(int? _shippingPaymentID);
        BLModel.Paged.ProductShippingDetail GetProductShippingDetail(int _skip, int _take);
        BLModel.Paged.ProductPurchaseDetail GetProductPurchaseDetailByID(int? _shippingPaymentID, int _skip, int _take);
        BLModel.ProductShippingAddressDetailByID GetProductShippingAddressDetailByID(int? _shippingPaymentID);
        BLModel.Paged.ProductPurchasesRecord GetProductPurchaseDetail(int _skip, int _take, int organizationID);
    }
}
