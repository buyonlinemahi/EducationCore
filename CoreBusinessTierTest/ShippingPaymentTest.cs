using HCRGUniversity.Core.BL;
using HCRGUniversity.Core.BL.Implementation;
using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreBusinessTierTest
{
    [TestClass]
    public class ShippingPaymentTest
    {
        private IShippingPaymentRepository _shippingPaymentRepository;
        private IShippingPayment _shippingPaymentBL;
        private HCRGUniversity.Core.Data.Model.ShippingPayment DLModel = new HCRGUniversity.Core.Data.Model.ShippingPayment();

        private IEducationShoppingTempRepository _educationShoppingTempRepository;
        private IEducationShoppingTemp _educationShoppingTempBL;
        private HCRGUniversity.Core.Data.Model.EducationShoppingTemp BLModel = new HCRGUniversity.Core.Data.Model.EducationShoppingTemp();


        private IOrderRepository _orderRepository ;
        private IMyEducationRepository _myEducationRepository;
        private IEducationModuleFileRepository _educationModuleFileRepository;
        private IMyEducationModuleRepository _myEducationModuleRepository;
        private IEducationShoppingRepository _educationShoppingRepository;
        private IProductShoppingRepository _productShoppingRepository;
        private IProductShoppingTempRepository _productShoppingTempRepository;
        private IProductQuantityRepository _productQuantityRepository;
        private IProductRepository _productRepository;


        [TestInitialize]
        public void ShippingPaymentInitialize()
        {
            _shippingPaymentRepository = new ShippingPaymentRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _educationShoppingTempRepository = new EducationShoppingTempRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _orderRepository = new OrderRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _myEducationRepository = new MyEducationRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _educationModuleFileRepository = new EducationModuleFileRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _myEducationModuleRepository = new MyEducationModuleRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());

            _educationShoppingRepository = new EducationShoppingRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _productShoppingRepository = new ProductShoppingRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _productShoppingTempRepository = new ProductShoppingTempRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());

            _productQuantityRepository = new ProductQuantityRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _productRepository = new ProductRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _shippingPaymentBL = new ShippingPaymentImpl(_orderRepository, _shippingPaymentRepository,
                                _myEducationRepository, _educationModuleFileRepository,
                                _myEducationModuleRepository, _educationShoppingTempRepository,
                                _educationShoppingRepository, _productShoppingRepository,
                                _productShoppingTempRepository, _productQuantityRepository,
                                _productRepository);
        }

        [TestMethod]
        public void addShippingPayment()
        {
            DLModel.BillingAddressID = 1;
            DLModel.CreatedBy = 1;
            DLModel.CreatedOn = System.DateTime.Now;
            DLModel.IsPaymentRecevied = false;
            DLModel.ShippingAddressID = 1;
            DLModel.ShippingMethodID = 1;
            DLModel.UserID = 171;
            DLModel.PaymentStatus = "Pending";
            int result = _shippingPaymentBL.addShippingPayment(DLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }
        [TestMethod]
        public void updateShippingPayment()
        {
            DLModel.BillingAddressID = 1;
            DLModel.CreatedBy = 1;
            DLModel.CreatedOn = System.DateTime.Now;
            DLModel.IsPaymentRecevied = false;
            DLModel.ShippingAddressID = 1;
            DLModel.ShippingMethodID = 1;
            DLModel.UserID = 171;
            DLModel.ShippingPaymentID = 1;
            int result = _shippingPaymentBL.updateShippingPayment(DLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }
        [TestMethod]
        public void getShippingPaymentByID()
        {
            var _result = _shippingPaymentBL.getShippingPaymentByID(1);
            Assert.IsTrue(_result != null, "Unable to get");
        }

        [TestMethod]
        public void getAllShippingPaymentByUserID()
        {
            var _result = _shippingPaymentBL.getAllShippingPaymentByUserID(171, 0, 10);
            Assert.IsTrue(_result != null, "Unable to get");
        }

        [TestMethod]
        public void getPendingShippingPaymentByUserID()
        {
            var _result = _shippingPaymentBL.getPendingShippingPaymentByUserID(171);
            Assert.IsTrue(_result != null, "Unable to get");
        }

        [TestMethod]
        public void addEducationShoppingRecordByShippingPaymentID()
        {
            _shippingPaymentBL.addEducationShoppingRecordByShippingPaymentID(3);
            
        }
        [TestMethod]
        public void UpdateEducationShoppingCartTempByShippingPaymentID()
        {
            _shippingPaymentBL.UpdateEducationShoppingCartTempByShippingPaymentID(40, 32, "Download");
        }
        [TestMethod]
        public void GetShippingPaymentByUserID()
        {
            _shippingPaymentBL.GetShippingPaymentByUserID(229);
        }
    }
}
