using HCRGUniversity.Core.BL;
using HCRGUniversity.Core.BL.Implementation;
using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
namespace CoreBusinessTierTest
{
    [TestClass]
    public class EducationShoppingTempTest
    {
        private IEducationShoppingTempRepository _educationShoppingTempRepository;
        private IProductShoppingTempRepository _productShoppingTempRepository;
        private IMyEducationRepository _myEducationRepository;
        private IEducationShoppingTemp _educationShoppingTempBL;

        private IProductRepository _productRepository;
        private HCRGUniversity.Core.Data.Model.EducationShoppingTemp BLModel = new HCRGUniversity.Core.Data.Model.EducationShoppingTemp();
        private HCRGUniversity.Core.Data.Model.EducationShoppingCart DLModel = new HCRGUniversity.Core.Data.Model.EducationShoppingCart();

        private HCRGUniversity.Core.Data.Model.ProductShoppingTemp BLModelPro = new HCRGUniversity.Core.Data.Model.ProductShoppingTemp();
        private HCRGUniversity.Core.Data.Model.ProductShoppingCart DLModelPro = new HCRGUniversity.Core.Data.Model.ProductShoppingCart();

        [TestInitialize]
        public void EducationShoppingTempInitialize()
        {
            _productRepository = new ProductRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _educationShoppingTempRepository = new EducationShoppingTempRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _productShoppingTempRepository = new ProductShoppingTempRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _myEducationRepository = new MyEducationRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _educationShoppingTempBL = new EducationShoppingTempImpl(_educationShoppingTempRepository, _productShoppingTempRepository, _myEducationRepository, _productRepository);
        }

        [TestMethod]
        public void AddEducationShoppingCart()
        {
            BLModel.UserID = 1;
            BLModel.EducationID = 1;
            BLModel.EducationTypeID =2;
            BLModel.Quantity = 1;
            BLModel.Amount = 1;
            BLModel.Date = DateTime.Now;
            int result = _educationShoppingTempBL.AddEducationShoppingCart(BLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }

        [TestMethod]
        public void DeleteEducationShoppingCart()
        {
            var result = _educationShoppingTempBL.DeleteEducationShoppingCart(1);
            Assert.IsTrue(result > 0, "Unable to get");
        }

        [TestMethod]
        public void GetEducationShoppingByUserID()
        {
            IEnumerable<HCRGUniversity.Core.Data.Model.EducationShoppingCart> Shoppingcart = _educationShoppingTempBL.GetEducationShoppingCartByUserID(171);
            Assert.IsTrue(Shoppingcart != null, "Unable to get");
        }

        [TestMethod]
        public void GetEducationShoppingTempByShippingPaymentID() 
        {
            IEnumerable<HCRGUniversity.Core.Data.Model.EducationShoppingCart> Shoppingcart = _educationShoppingTempBL.GetEducationShoppingTempByShippingPaymentID(244);
            Assert.IsTrue(Shoppingcart != null, "Unable to get");
        }

        [TestMethod]
        public void GetEducationShoppingTempByID()
        {
            HCRGUniversity.Core.Data.Model.ProductShoppingTemp _productShoppingTemp = _educationShoppingTempBL.GetProductShoppingTempByID(82);
            Assert.IsTrue(_productShoppingTemp != null, "Unable to get");
        }

        [TestMethod]
        public void checkEducationinShoppingCart()
        {
            bool check = _educationShoppingTempBL.checkEducationinShoppingCart(171,2,"Product");
            Assert.IsTrue(check != false, "not exists");
        }

        [TestMethod]
        public void checkCoursePurchaseValidationByUserID()
        {
            bool check = _educationShoppingTempBL.checkCoursePurchaseValidationByUserID(229, 40);
            Assert.IsTrue(check != false, "not exists");
        }

        [TestMethod]
        public void UpdateEducationShoppingCart()
        {
            BLModel.UserID = 1;
            BLModel.EducationID = 1;
            BLModel.EducationTypeID = 1;
            BLModel.Quantity = 1;
            BLModel.Amount = 1;
            BLModel.Date = DateTime.Now;
            BLModel.CoupanID = 1;
            BLModel.EducationShoppingTempID = 2;
            var result = _educationShoppingTempBL.UpdateEducationShoppingCart(BLModel);
            Assert.IsTrue(result > 0, "Unable to get");
        }

        //product

        [TestMethod]
        public void AddProductShoppingCart()
        {
            BLModelPro.UserID = 173;
            BLModelPro.ProductID = 48;          
            BLModelPro.Quantity = 1;
            BLModelPro.Amount = 12;
            BLModelPro.ShippingPaymentID = null;
            BLModelPro.IsProcessed = null;
            BLModelPro.Date = DateTime.Now;
            int result = _educationShoppingTempBL.AddProductShoppingCart(BLModelPro);
            Assert.IsTrue(result > 0, "Unable to Add");
        }

        [TestMethod]
        public void DeleteProductShoppingCart()
        {
            var result = _educationShoppingTempBL.DeleteProductShoppingCart(1);
            Assert.IsTrue(result > 0, "Unable to get");
        } 

       
        [TestMethod]
        public void UpdateProductShoppingCart()
        {
            BLModelPro.UserID = 1;
            BLModelPro.ProductID = 2;         
            BLModelPro.Quantity = 1;
            BLModelPro.Amount = 1;
            BLModelPro.Date = DateTime.Now;
            BLModelPro.CoupanID = null;
            BLModelPro.ProductShoppingTempID = 1;
            var result = _educationShoppingTempBL.UpdateProductShoppingCart(BLModelPro);
            Assert.IsTrue(result > 0, "Unable to get");
        }

        [TestMethod]
        public void GetShoppingDetailsByShippingPaymentID()
        {   
            IEnumerable<HCRGUniversity.Core.Data.Model.EducationShoppingCart> res = _educationShoppingTempRepository.GetShoppingDetailsByShippingPaymentID(510);//_educationBL.getAllEducationActive();
            Assert.IsTrue(res != null, "Unable to get");
        }
    }
}