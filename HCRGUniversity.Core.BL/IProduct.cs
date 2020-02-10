using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.BL
{
    public interface IProduct
    {
        int AddProduct(Product product);
        int UpdateProduct(Product product);
        void DeleteProduct(int productID);
        Product GetProductByID(int productID);
        BLModel.Paged.Product GetPagedProductByProductName(string productName, int skip, int take);
        BLModel.Paged.Product GetPagedProduct(int skip, int take);
        BLModel.Paged.ProductPurchaseDetail GetPagedProductByProductType(string productType, int userid, int skip, int take);
        IEnumerable<ProductShopping> GetProductShoppingAllByProductID(int productID);

        // ProductQuantities

        int AddProductQuantity(ProductQuantity productQuantity);
        int UpdateProductQuantity(ProductQuantity productQuantity);
        ProductQuantity GetProductQuantityByID(int productQuantityID);
        BLModel.Paged.ProductQuantityDetail GetProductQuantityDetailByProductID(int productID, int skip, int take);
        BLModel.Paged.ProductQuantityDetail GetProductQuantityByProductID(int productID);
    }
}
