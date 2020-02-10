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
  public class DiscountCouponTest
    {
        private IDiscountCouponRepository _discountCouponRepository;
        private IDiscountCoupon _discountCouponBL;
        private HCRGUniversity.Core.BL.Model.DiscountCoupon BLModel = new HCRGUniversity.Core.BL.Model.DiscountCoupon();

        [TestInitialize]
        public void DiscountCouponInitialize()
        {
            _discountCouponRepository = new DiscountCouponRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _discountCouponBL = new DiscountCouponImpl(_discountCouponRepository);
        }

        [TestMethod]
        public void AddDiscountCoupon()
        {
            BLModel.CouponCode = "1qwq2qw";
            BLModel.CouponEducationID = 1;
            BLModel.CouponDiscount =12;
            BLModel.CouponExpiryDate = DateTime.Now;
            BLModel.CouponIssueDate = DateTime.Now;
            BLModel.CouponProduactID = 0;
            BLModel.CouponType = "Percent";
            int result = _discountCouponBL.AddDiscountCoupon(BLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }
        [TestMethod]
        public void UpdateDiscountCoupon()
        {
            BLModel.CouponCode = "1qwq2qw";
            BLModel.CouponEducationID = 1;
            BLModel.CouponDiscount = 1;
            BLModel.CouponExpiryDate = DateTime.Now;
            BLModel.CouponIssueDate = DateTime.Now;
            BLModel.CouponProduactID = 0;
            BLModel.CouponType = "Percent";
            BLModel.CouponID = 1;
            int result = _discountCouponBL.UpdateDiscountCoupon(BLModel);
            Assert.IsTrue(result > 0, "Unable to update");
        }

        [TestMethod]
        public void DeleteDiscountCoupon()
        {
            _discountCouponBL.DeleteDiscountCoupon(1);
        } 

        [TestMethod]
        public void getAllDiscountCoupon()
        {
            IEnumerable<HCRGUniversity.Core.BL.Model.DiscountCoupon> discountCoupon = _discountCouponBL.getAllDiscountCoupons();
            Assert.IsTrue(discountCoupon != null, "Unable to get");
        }
        [TestMethod]
        public void getDiscountCouponByID()
        {
            HCRGUniversity.Core.BL.Model.DiscountCoupon discountCoupon = _discountCouponBL.GetDiscountCouponByID(152);
            Assert.IsTrue(discountCoupon != null, "Unable to get");
        }

        [TestMethod]
        public void getDiscountCouponByCouponCode()
        {
            HCRGUniversity.Core.BL.Model.DiscountCoupon discountCoupon = _discountCouponBL.GetDiscountCouponByCouponCode("J6L1gEh0WV");
            Assert.IsTrue(discountCoupon != null, "Unable to get");
        }

        [TestMethod]
        public void GetDiscountCouponForCourses()
        {
            IEnumerable<HCRGUniversity.Core.Data.Model.DiscountCouponForCourses> discountCoupon = _discountCouponBL.GetDiscountCouponForCourses(1);
            Assert.IsTrue(discountCoupon != null, "Unable to get");
        }

        [TestMethod]
        public void GetDiscountCouponForProducts()
        {
            IEnumerable<HCRGUniversity.Core.Data.Model.DiscountCouponForCourses> discountCoupon = _discountCouponBL.GetDiscountCouponForProducts(1);
            Assert.IsTrue(discountCoupon != null, "Unable to get");
        }

        [TestMethod]
        public void UpdateCouponStatus()
        {

            int result = _discountCouponBL.UpdateDiscountCouponStatus("1qwq2qw", false);
            Assert.IsTrue(result > 0, "Unable to update");
        }

        [TestMethod]
        public void GetAllPagedDiscountCoupon()
        {
            var discountCoupon = _discountCouponBL.GetAllPagedDiscountCoupon( 0, 10);
            Assert.IsTrue(discountCoupon != null, "Unable to find");
        }

        [TestMethod]
        public void GetAllPagedDiscountCouponForCourse()
        {
            var discountCoupon = _discountCouponBL.GetAllPagedDiscountCouponForCourse(0, 10,1);
            Assert.IsTrue(discountCoupon != null, "Unable to find");
        }
    }
}
