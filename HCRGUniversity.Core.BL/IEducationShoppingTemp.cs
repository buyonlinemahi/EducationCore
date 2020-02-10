using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL
{
    public interface IEducationShoppingTemp
    {
        int AddEducationShoppingCart(EducationShoppingTemp educationShoppingTemp);
        int UpdateEducationShoppingCart(EducationShoppingTemp educationShoppingTemp);
        int DeleteEducationShoppingCart(int educationShoppingTempID);
        void DeleteEducationShoppingCartByUserID(int userID);
        void DeleteEducationShoppingCartByShippingPaymentID(int shippingPaymentID);
        IEnumerable<DLModel.EducationShoppingCart> GetEducationShoppingCartByUserID(int userID);
        IEnumerable<EducationShoppingCart> GetEducationShoppingTempByShippingPaymentID(int _shippingPaymentID);
        IEnumerable<EducationShoppingCart> GetShoppingDetailsByShippingPaymentID(int shippingPaymentID);
        bool checkEducationinShoppingCart(int userID, int mainID, string type);
        bool checkCoursePurchaseValidationByUserID(int userID, int EducationID);
        DLModel.ProductShoppingTemp GetProductShoppingTempByID(int _id);
        void ResetShippingOrderQuentityStock(int userID);
        DLModel.EducationShoppingTemp GetEducationShoppingTempByID(int _id);
            //Product
        int AddProductShoppingCart(ProductShoppingTemp productShoppingTemp);
        int UpdateProductShoppingCart(ProductShoppingTemp productShoppingTemp);
        int DeleteProductShoppingCart(int productShoppingTempID);
        void DeleteProductShoppingCartByUserID(int userID);
        void DeleteProductShoppingCartByShippingPaymentID(int shippingPaymentID);
        int CheckAnyProductsIsOutOfStock(int userID);
        string GetShoppingCartCoursesByUserID(int userID);
       
    }
}