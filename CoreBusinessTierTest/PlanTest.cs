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
    public class PlanTest
    {
        private IPlanRepository _planRepository;
        private IPlan _planBL;
        private IUserPlanRepository _userPlanRepository;
        private ICoursePlanRepository _courceplanRepository;
        private HCRGUniversity.Core.BL.Model.Plan BLModel = new HCRGUniversity.Core.BL.Model.Plan();

        [TestInitialize]
        public void PlanInitialize()
        {
            _planRepository = new PlanRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _userPlanRepository = new UserPlanRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _courceplanRepository = new CoursePlanRepository( new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _planBL = new PlanImpl(_planRepository, _userPlanRepository, _courceplanRepository);
        }

        [TestMethod]
        public void Addplan()
        {
            BLModel.PlanName = "Plan four";
            BLModel.ClientID = 1;
            int result = _planBL.AddPlan(BLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }
        [TestMethod]
        public void Updateplan()
        {
            BLModel.PlanName = "Plan Two Two";
            BLModel.PlanID = 1;
            BLModel.ClientID = 1;
            int result = _planBL.UpdatePlan(BLModel);
            Assert.IsTrue(result > 0, "Unable to update");
        }

        [TestMethod]
        public void DeleteAboutUs()
        {
            _planBL.DeletePlan(1);
        }

        [TestMethod]
        public void getAllplan()
        {
            IEnumerable<HCRGUniversity.Core.BL.Model.Plan> plan = _planBL.getAll();
            Assert.IsTrue(plan != null, "Unable to get");
        }

        
        [TestMethod]
        public void GetAllPagedPlanByClientID()
        {
            var plan = _planBL.GetAllPagedPlanByClientID(14,100,0,10);
            Assert.IsTrue(plan != null, "Unable to find");
        }

        [TestMethod]
        public void GetAllPlansByClientID()
        {
            IEnumerable<BLModel.Plan> plan = _planBL.GetAllPlansByClientID(14);
            Assert.IsTrue(plan != null, "Unable to get");
        }
    }
}
