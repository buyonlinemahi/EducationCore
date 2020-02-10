using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;

namespace HCRGUniversity.Core.Data
{
    public interface IEducationShoppingTempRepository : IBaseRepository<EducationShoppingTemp>
    {
        IEnumerable<EducationShoppingCart> GetEducationShoppingCartByUserID(int userID);
        IEnumerable<EducationShoppingCart> GetEducationShoppingTempByShippingPaymentID(int _shippingPaymentID);
        IEnumerable<EducationShoppingCart> GetShoppingDetailsByShippingPaymentID(int ShippingPaymentID);
        int DeleteEducationFromShoppingCart(int educationShoppingTempID);
        int DeleteEducationFromShoppingCartByUserID(int userID);
        void DeleteEducationShoppingCartByShippingPaymentID(int shippingPaymentID);

        int CheckAnyProductsIsOutOfStock(int userID);

        string GetShoppingCartCoursesByUserID(int userID);
    }
}