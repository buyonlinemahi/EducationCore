using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;

namespace HCRGUniversity.Core.Data
{
    public interface IProductShoppingTempRepository : IBaseRepository<ProductShoppingTemp>
    {
      
        int DeleteProductFromShoppingCart(int productShoppingTempID);
        int DeleteProductFromShoppingCartByUserID(int userID);
        ProductShoppingTemp getProductShoppingTempByID(int ID);
    }
}
