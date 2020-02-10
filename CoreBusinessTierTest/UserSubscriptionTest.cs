using HCRGUniversity.Core.BL;
using HCRGUniversity.Core.BL.Implementation;
using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace CoreBusinessTierTest
{
    [TestClass]
    public class UserSubscriptionTest
    {

        private IUserSubscriptionRepository _userSubscriptionRepository;
        private IUserSubscription _userSubscriptionBL;
        private HCRGUniversity.Core.BL.Model.UserSubscription BLModel = new HCRGUniversity.Core.BL.Model.UserSubscription();

        [TestInitialize]
        public void AboutUsInitialize()
        {
            _userSubscriptionRepository = new UserSubscriptionRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _userSubscriptionBL = new UserSubscriptionImpl(_userSubscriptionRepository);
        }
        [TestMethod]
        public void GetAllUserSubscriptionByOrganizationID()
        {
            IEnumerable<BLModel.UserSubscription> userSubscription = _userSubscriptionBL.GetAllUserSubscriptionByOrganizationID(1,14);
            Assert.IsTrue(userSubscription != null, "Unable to get");
        }
    }
}
