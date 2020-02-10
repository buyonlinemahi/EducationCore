using HCRGUniversity.Core.BL;
using HCRGUniversity.Core.BL.Implementation;
using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CoreBusinessTierTest
{
    [TestClass]
    public class ProductTest
    {
        private IProductRepository _productRepository;
        private IProductShoppingRepository _productShoppingRepository;
        private IProductQuantityRepository _productQuantityRepository;
        private IProduct _productBL;
        private HCRGUniversity.Core.Data.Model.Product DLModel = new HCRGUniversity.Core.Data.Model.Product();

        [TestInitialize]
        public void ProductInitialize()
        {
            _productRepository = new ProductRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _productShoppingRepository = new ProductShoppingRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _productQuantityRepository = new ProductQuantityRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _productBL = new ProductImpl(_productRepository, _productShoppingRepository, _productQuantityRepository);
        }


        [TestMethod]
        public void AddProduct()
        {
            DLModel.ProductName = "testing tesing";
            DLModel.ProductDesc = "testing tesing";
            DLModel.ProductFile = "testing tesing";
            DLModel.ProductImage = "testing tesing";
            DLModel.ProductPrice = 11;
        
            int result = _productBL.AddProduct(DLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }
        [TestMethod]
        public void UpdateProduct()
        {
            DLModel.ProductName = "testing dgdfg tesing";
            DLModel.ProductDesc = "testing tesing";
            DLModel.ProductFile = "testing tesing";
            DLModel.ProductImage = "testing tesing";
            DLModel.ProductPrice = 11;
         
            DLModel.ProductID = 1;
            int result = _productBL.UpdateProduct(DLModel);
            Assert.IsTrue(result > 0, "Unable to update");
        }

        [TestMethod]
        public void DeleteProduct()
        {
            _productBL.DeleteProduct(1);
        }

        [TestMethod]
        public void GetEducationByEducationNamePaged()
        {
            var product = _productBL.GetPagedProductByProductName("t", 0, 3);
            Assert.IsTrue(product != null, "Unable to get");
        }

        [TestMethod]
        public void GetPagedProduct()
        {
            var product = _productBL.GetPagedProduct(0, 3);
            Assert.IsTrue(product != null, "Unable to get");
        }
        [TestMethod]
        public void GetPagedProductByProductType() 
        {
            var productDetail = _productBL.GetPagedProductByProductType("Download", 173, 0, 5);
            Assert.IsTrue(productDetail != null, "Unable to get");
        }

        [TestMethod]
        public void GetProductShoppingAllByProductID() 
        {
            var productDetail = _productBL.GetProductShoppingAllByProductID(48);
            Assert.IsTrue(productDetail != null, "Unable to get");
        }
    }
}
