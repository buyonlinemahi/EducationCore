using System.Linq;
using HCRGUniversity.Core.Data;
using DLModel = HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;

namespace HCRGUniversity.Core.BL.Implementation
{
    public class EducationShoppingTempImpl : IEducationShoppingTemp
    {
        private readonly IEducationShoppingTempRepository _educationShoppingTempRepository;
        private readonly IProductShoppingTempRepository _productShoppingTempRepository;
        private readonly IMyEducationRepository _myEducationRepository;
        private readonly IProductRepository _productRepository;
        public EducationShoppingTempImpl(IEducationShoppingTempRepository educationShoppingTempRepository, IProductShoppingTempRepository productShoppingTempRepository, IMyEducationRepository myEducationRepository, IProductRepository productRepository)
        {
            _educationShoppingTempRepository = educationShoppingTempRepository;
            _productShoppingTempRepository = productShoppingTempRepository;
            _myEducationRepository = myEducationRepository;
            _productRepository = productRepository;
        }

        public int AddEducationShoppingCart(DLModel.EducationShoppingTemp educationShoppingTemp)
        {
            return _educationShoppingTempRepository.Add(educationShoppingTemp).EducationShoppingTempID;
        }

        public int DeleteEducationShoppingCart(int educationShoppingTempID)
        {
            return _educationShoppingTempRepository.DeleteEducationFromShoppingCart(educationShoppingTempID);
        }

        public DLModel.EducationShoppingTemp GetEducationShoppingTempByID(int _id)
        {
            return _educationShoppingTempRepository.GetById(_id);
        }

        public void  DeleteEducationShoppingCartByUserID(int userID)
        {
            _educationShoppingTempRepository.DeleteEducationFromShoppingCartByUserID(userID);
        }

        public void DeleteEducationShoppingCartByShippingPaymentID(int shippingPaymentID)
        {
            //if (_educationShoppingTempRepository.GetAll(rk => rk.ShippingPaymentID == shippingPaymentID).Count() > 0)
            //    _educationShoppingTempRepository.Delete(rk => rk.ShippingPaymentID == shippingPaymentID);
            _educationShoppingTempRepository.DeleteEducationShoppingCartByShippingPaymentID(shippingPaymentID);
        }

        public void ResetShippingOrderQuentityStock(int userID)
        {
            var _res = _productShoppingTempRepository.GetAll(rk => rk.ShippingPaymentID != null && rk.UserID == userID && rk.IsProcessed.Value == true).ToList();
            foreach (var res in _res)
            {
                DLModel.Product _product = new DLModel.Product();
                _product = _productRepository.GetById(res.ProductID);
                _product.ProductCurrentBalance = _product.ProductCurrentBalance.Value + res.Quantity;
                _productRepository.Update(_product);

                DLModel.ProductShoppingTemp _productShoppingTemp = new DLModel.ProductShoppingTemp();
                _productShoppingTemp = _productShoppingTempRepository.GetById(res.ProductShoppingTempID);
                _productShoppingTemp.ShippingPaymentID = null;
                _productShoppingTemp.IsProcessed = null;
                _productShoppingTemp.ProcessedDate = null;
                _productShoppingTempRepository.Update(_productShoppingTemp);
            }

            var _res1 = _educationShoppingTempRepository.GetAll(rk => rk.ShippingPaymentID != null && rk.UserID == userID).ToList();
            foreach (var res in _res1)
            {
                DLModel.EducationShoppingTemp _educationShoppingTemp = new DLModel.EducationShoppingTemp();
                _educationShoppingTemp = _educationShoppingTempRepository.GetById(res.EducationShoppingTempID);
                _educationShoppingTemp.ShippingPaymentID = null;
                _educationShoppingTemp.ProcessedDate = null;
                _educationShoppingTempRepository.Update(_educationShoppingTemp);

            }

        }

        public IEnumerable<DLModel.EducationShoppingCart> GetEducationShoppingCartByUserID(int userID)
        {
            // handle the case of tbe if user retuen from the shipping payment screen and product qty need to revert in main table
            return _educationShoppingTempRepository.GetEducationShoppingCartByUserID(userID).ToList();
        }

        public string GetShoppingCartCoursesByUserID(int userID)
        {
            // handle the case of tbe if user retuen from the shipping payment screen and product qty need to revert in main table
            return _educationShoppingTempRepository.GetShoppingCartCoursesByUserID(userID);
        }
        

        

        public IEnumerable<DLModel.EducationShoppingCart> GetEducationShoppingTempByShippingPaymentID(int _shippingPaymentID)
        {
            return _educationShoppingTempRepository.GetEducationShoppingTempByShippingPaymentID(_shippingPaymentID).ToList();
        }
        public IEnumerable<DLModel.EducationShoppingCart> GetShoppingDetailsByShippingPaymentID(int _shippingPaymentID)
        {
            return _educationShoppingTempRepository.GetShoppingDetailsByShippingPaymentID(_shippingPaymentID).ToList();
        }
        public bool checkEducationinShoppingCart(int userID, int mainID,string type)
        {
            return _educationShoppingTempRepository.GetEducationShoppingCartByUserID(userID).Any(edu => edu.EduorProID == mainID && edu.CartType == type);
        }

        public bool checkCoursePurchaseValidationByUserID(int userID, int EducationID)
        {
            if (_myEducationRepository.GetAll(rk => rk.EducationID == EducationID && rk.UserID == userID && (rk.Completed == false || rk.Completed == null) && (rk.Expired == false || rk.Expired == null)).Count() > 0)
                return true;
            else
                return false;
        }
        public int UpdateEducationShoppingCart(DLModel.EducationShoppingTemp educationShoppingTemp)
        {
            return _educationShoppingTempRepository.Update(educationShoppingTemp);
        }

        public int AddProductShoppingCart(DLModel.ProductShoppingTemp productShoppingTemp)
        {
            if (_productRepository.GetAll(rk => rk.ProductID == productShoppingTemp.ProductID && rk.ProductCurrentBalance.Value != 0).Count() > 0)
                return _productShoppingTempRepository.Add(productShoppingTemp).ProductShoppingTempID;
            else
                return 0;
        }

        public int CheckAnyProductsIsOutOfStock(int userID)
        {
            return _educationShoppingTempRepository.CheckAnyProductsIsOutOfStock(userID);
        }



        public int DeleteProductShoppingCart(int productShoppingTempID)
        {
            return _productShoppingTempRepository.DeleteProductFromShoppingCart(productShoppingTempID);
        }

        public void DeleteProductShoppingCartByUserID(int userID)
        {
            _productShoppingTempRepository.DeleteProductFromShoppingCartByUserID(userID);
        }

        public DLModel.ProductShoppingTemp GetProductShoppingTempByID(int _id)
        {
            return _productShoppingTempRepository.GetById(_id);
        }





        public void DeleteProductShoppingCartByShippingPaymentID(int _shippingPaymentID)
        {
            if (_productShoppingTempRepository.GetAll(rk => rk.ShippingPaymentID == _shippingPaymentID).Count() > 0)
                _productShoppingTempRepository.Delete(rk => rk.ShippingPaymentID == _shippingPaymentID);
        }

        public int UpdateProductShoppingCart(DLModel.ProductShoppingTemp productShoppingTemp)
        {
            return _productShoppingTempRepository.Update(productShoppingTemp);
        }
       
    }
}