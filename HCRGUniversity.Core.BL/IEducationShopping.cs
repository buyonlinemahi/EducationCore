using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL
{
    public interface IEducationShopping
    {

        void AddEducationShoppingOrder(IEnumerable<DLModel.EducationShoppingCart> shoppingcart);

        void AddEducationShoppingOrderAllAccessPass(DLModel.EducationShoppingCart shoppingcart);

        int UpdateEducationShoppingOrder(EducationShopping educationShopping);      

        int UpdateProductShoppingOrder(ProductShopping productShopping);

        //Order
        int AddShoppingOrder(Order order);
        int UpdateShoppingOrder(Order order);
        void DeleteShoppingOrder(Order order);
    }
}