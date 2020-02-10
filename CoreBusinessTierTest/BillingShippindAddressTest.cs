using HCRGUniversity.Core.BL;
using HCRGUniversity.Core.BL.Implementation;
using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreBusinessTierTest
{
    [TestClass]
    public class BillingShippindAddressTest
    {
        private IShippingAddressRepository _shippingAddressRepository;
        private IShippingAddress _shippingAddressBL;

        private IBillingAddressRepository _billingAddressRepository;
        private IBillingAddress _billingAddressBL;

        private HCRGUniversity.Core.Data.Model.BillingAddress DLModel = new HCRGUniversity.Core.Data.Model.BillingAddress();
        private HCRGUniversity.Core.Data.Model.ShippingAddress DLModel2 = new HCRGUniversity.Core.Data.Model.ShippingAddress();

        [TestInitialize]
        public void BillingShippindAddressInitialize()
        {
            _shippingAddressRepository = new ShippingAddressRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _shippingAddressBL = new ShippingAddressImpl(_shippingAddressRepository);

            _billingAddressRepository = new BillingAddressRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _billingAddressBL = new BillingAddressImpl(_billingAddressRepository);
        }
        
        [TestMethod]
        public void addBillingAddress()
        {
            DLModel.BAAddress = "BAAddress";
            DLModel.BAAddress2 = "BAAddress2";
            DLModel.BACity = "BACity";
            DLModel.BAFirstName = "BAFirstName";
            DLModel.BALastName = "BALastName";
            DLModel.BAPhone = "132-132(1259)";
            DLModel.BAPostalCode = "90029";
            DLModel.BAStateID = 1;
            DLModel.BAUserID = 1;
            int result = _billingAddressBL.addBillingAddress(DLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }

        [TestMethod]
        public void updateBillingAddress()
        {
            DLModel.BAAddress = "BAAddress";
            DLModel.BAAddress2 = "BAAddress2";
            DLModel.BACity = "BACity";
            DLModel.BAFirstName = "BAFirstName";
            DLModel.BALastName = "BALastName";
            DLModel.BAPhone = "987-654(4569)";
            DLModel.BAPostalCode = "90029";
            DLModel.BAStateID = 1;
            DLModel.BAUserID = 1;
            DLModel.BillingAddressID = 1;
            int result = _billingAddressBL.updateBillingAddress(DLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }

        [TestMethod]
        public void getBillingAddressByID()
        {
            var _result = _billingAddressBL.getBillingAddressByID(1);
            Assert.IsTrue(_result != null, "Unable to get");
        }

        [TestMethod]
        public void getAllBillingAddressByUserID()
        {
            var _result = _billingAddressBL.getAllBillingAddressByUserID(1, 0, 10);
            Assert.IsTrue(_result != null, "Unable to get");
        }


        [TestMethod]
        public void addShippingAddress()
        {
            DLModel2.SAAddress = "SAAddress";
            DLModel2.SAAddress2 = "SAAddress2";
            DLModel2.SACity = "SACity";
            DLModel2.SAFirstName = "SAFirstName";
            DLModel2.SALastName = "SALastName";
            DLModel2.SAPhone = "132-132(1259)";
            DLModel2.SAPostalCode = "90029";
            DLModel2.SAStateID = 1;
            DLModel2.SAUserID = 1;
            int result = _shippingAddressBL.addShippingAddress(DLModel2);
            Assert.IsTrue(result > 0, "Unable to Add");
        }

        [TestMethod]
        public void updateShippingAddress()
        {
            DLModel2.SAAddress = "SAAddress";
            DLModel2.SAAddress2 = "SAAddress2";
            DLModel2.SACity = "SACity";
            DLModel2.SAFirstName = "SAFirstName";
            DLModel2.SALastName = "SALastName";
            DLModel2.SAPhone = "798-654(4681)";
            DLModel2.SAPostalCode = "90029";
            DLModel2.SAStateID = 1;
            DLModel2.SAUserID = 1;
            DLModel2.ShippingAddressID = 1;
            int result = _shippingAddressBL.updateShippingAddress(DLModel2);
            Assert.IsTrue(result > 0, "Unable to Add");
        }

        [TestMethod]
        public void getShippingAddressByID()
        {
            var _result = _shippingAddressBL.getShippingAddressByID(1);
            Assert.IsTrue(_result != null, "Unable to get");
        }

        [TestMethod]
        public void getAllShippingAddressByUserID()
        {
            var _result = _shippingAddressBL.getAllShippingAddressByUserID(1, 0, 10);
            Assert.IsTrue(_result != null, "Unable to get");
        }


    }
}
