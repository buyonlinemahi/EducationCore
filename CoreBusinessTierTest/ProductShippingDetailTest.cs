using HCRGUniversity.Core.BL;
using HCRGUniversity.Core.BL.Implementation;
using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;


namespace CoreBusinessTierTest
{
    [TestClass]
    public class ProductShippingDetailTest
    {
         private IProductShippingDetailRepository _productShippingDetailRepository;
         private IProductShoppingRepository _productShoppingRepository;
         private IShippingPaymentRepository _shippingPaymentRepository;
         private IShippingAddressRepository _shippingAddressRepository;
         private IProductRepository _productRepository;

         private IProductShippingDetail _IProductShippingDetailBL;

         private HCRGUniversity.Core.Data.Model.ProductPurchase DLModel = new HCRGUniversity.Core.Data.Model.ProductPurchase();
         private HCRGUniversity.Core.Data.Model.ProductShippingDetail _productShippingDetail = new HCRGUniversity.Core.Data.Model.ProductShippingDetail();

        [TestInitialize]
        public void ProductInitialize()
        {
            _productShippingDetailRepository = new ProductShippingDetailRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _productShoppingRepository = new ProductShoppingRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _shippingPaymentRepository = new ShippingPaymentRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _shippingAddressRepository = new ShippingAddressRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _productRepository = new ProductRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _IProductShippingDetailBL = new ProductShippingDetailImpl(_productShippingDetailRepository, _productShoppingRepository, _shippingPaymentRepository, _shippingAddressRepository, _productRepository);
        }

        [TestMethod]
        public void Get_ProductPurchaseDetail()
        {
            var productDetail = _IProductShippingDetailBL.GetProductPurchaseDetail(0, 50, 2);
            Assert.IsTrue(productDetail != null, "Unable to get");
        }

        [TestMethod]
        public void Get_ProductPurchaseDetailByID()
        {
            var productDetail = _IProductShippingDetailBL.GetProductPurchaseDetailByID(298,0, 50);
            Assert.IsTrue(productDetail != null, "Unable to get");
        }

        [TestMethod]
        public void Add_ProductShippingDetail()
        {
            _productShippingDetail.ShippingPaymentID = 244;
            _productShippingDetail.ProductShippedOn = System.DateTime.Now;
            _productShippingDetail.CreatedOn= System.DateTime.Now;
            _productShippingDetail.CreatedBy = 222;
            int result = _IProductShippingDetailBL.AddProductShippingDetail(_productShippingDetail);
            Assert.IsTrue(result > 0, "Unable to Add");
        }
        [TestMethod]
        public void Get_ProductShippingDetailByProductShippingID()
        {
            var productDetail = _IProductShippingDetailBL.GetProductShippingDetailByProductShippingID(246);
            Assert.IsTrue(productDetail != null, "Unable to get");
        }
    }
}
