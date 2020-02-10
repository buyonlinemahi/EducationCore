using HCRGUniversity.Core.BL;
using HCRGUniversity.Core.BL.Implementation;
using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreBusinessTierTest
{
    [TestClass]
    public class UserTest
    {
        private IUserRepository _userRepository;
        private IClientTypeRepository _clientUserRepository;
        private IUserResetPasswordRepository _userResetPasswordRepository;
        private IUserMenuGroupRepository _userMenuGroupRepository;
        private IUserMenuPermissionRepository _userMenuPermissionRepository;
        private IUser _userBL;
        private HCRGUniversity.Core.BL.Model.User BLModel = new HCRGUniversity.Core.BL.Model.User();

        [TestInitialize]
        public void UserInitialize()
        {
            _userRepository = new UserRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _clientUserRepository = new ClientTypeRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _userResetPasswordRepository = new UserResetPasswordRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _userMenuGroupRepository = new UserMenuGroupRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _userMenuPermissionRepository = new UserMenuPermissionRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _userBL = new UserImpl(_userRepository, _userResetPasswordRepository, _clientUserRepository, _userMenuGroupRepository, _userMenuPermissionRepository);
        }

        [TestMethod]
        public void GetUserByID()
        {
            var user = _userBL.GetUserByID(2);
            Assert.IsTrue(user != null, "Unable to find");
        }

        [TestMethod]
        public void AddUser()
        {
            BLModel.FirstName = "harry";
            BLModel.LastName = "potter";
            BLModel.Password = "Test ";
            BLModel.EmailID = "tgosain@vsaindia.com";
            BLModel.Company = "company";
            BLModel.Phone = "343434";
            BLModel.ProfessionalTitle = "Testprof";
            BLModel.IsActive = true;
            BLModel.IsLocked = false;
            BLModel.FailedAttemptCount = 1;

            BLModel.LastLoginDate = System.DateTime.Now.Date;
            int result = _userBL.AddUser(BLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }

        [TestMethod]
        public void UpdateUser()
        {
            BLModel.UID = 1;
            BLModel.FirstName = "harry1";
            BLModel.LastName = "potter1";
            BLModel.Password = "dsdfsd ";
            BLModel.EmailID = "Test@sdf1.com";
            BLModel.Company = "company11";
            BLModel.Phone = "34343411";
            BLModel.ProfessionalTitle = "Testprof1";
            BLModel.IsActive = true;
            BLModel.IsLocked = false;
            BLModel.FailedAttemptCount = 1;
            BLModel.LastLoginDate = System.DateTime.Now.Date.AddDays(1);

            int result = _userBL.UpdateUser(BLModel);

            Assert.IsTrue(result > 0, "Unable to Add");
        }
        [TestMethod]
        public void UpdateUserPassword()
        {
            _userBL.UpdateUserPassword(1, "dsdafa1sf");
        }
        [TestMethod]
        public void GetUserByUserName()
        {
            var user = _userBL.GetUserByUserName("Test@sdf1.com");
            Assert.IsTrue(user != null, "Unable to find");
        }

        [TestMethod]
        public void UpdateUserFailedAttemptCount()
        {
            BLModel.FirstName = "harry1";
            BLModel.LastName = "potter1";
            BLModel.Password = "Test1 ";
            BLModel.EmailID = "Test@sdf1.com";
            BLModel.Company = "company11";
            BLModel.Phone = "34343411";
            BLModel.ProfessionalTitle = "Testprof1";
            BLModel.IsActive = true;
            BLModel.UID = 1;
            BLModel.FailedAttemptCount = 4;

            Assert.IsTrue(_userBL.UpdateUserFailedAttemptCount(BLModel) > 0);
        }

        [TestMethod]
        public void GetUsersAll()
        {
            var user = _userBL.GetUsersAll(1);
            Assert.IsTrue(user != null, "Unable to find");
        }

       
        [TestMethod]
        public void ResetUserFailedAttemptCount()
        {
            BLModel.FirstName = "harry1";
            BLModel.LastName = "potter1";
            BLModel.Password = "Test1 ";
            BLModel.EmailID = "Test@sdf1.com";
            BLModel.Company = "company11";
            BLModel.Phone = "34343411";
            BLModel.ProfessionalTitle = "Testprof1";
            BLModel.IsActive = true;
            BLModel.UID = 1;
            var userCount = _userBL.ResetUserFailedAttemptCount(BLModel);
            Assert.IsTrue(userCount != 0, "Unable to UpdateUserFailedAttemptCount");
        }

        [TestMethod]
        public void GetAllPagedUser()
        {
            var user = _userBL.GetAllPagedUser(0, 10,14);
            Assert.IsTrue(user != null, "Unable to find");
        }

        [TestMethod]
        public void GetUsersByName()
        {
            var user = _userBL.GetUsersByName("s", 0, 12,14);
            Assert.IsTrue(user != null, "Unable to find");
        }

        //user reset temp password...hp
        [TestMethod]
        public void AddUserResetTempPassword()
        {
            var s= _userBL.AddUserResetTempPassword(1,"fggdfgd sadf sdf");
        }
        [TestMethod]
        public void DeleteUserResetTempPassword()
        {
            _userBL.DeleteUserResetTempPassword(1, "fggdfgd sadf sdf");
        }
        [TestMethod]
        public void matchUserResetTempPassword()
        {
            var s = _userBL.matchUserResetTempPassword(1, "asdfasa");
        }
        [TestMethod]
        public void GetUserVerifiedDetails()
        {
            var users = _userBL.GetUserVerifiedDetails(10,10,1);
            Assert.IsTrue(users != null, "No record found");
        }

        [TestMethod]
        public void GetUsersByPlanID()
        {
            var user = _userBL.GetUsersByPlanID(14);
            Assert.IsTrue(user != null, "Unable to find");
        }
        [TestMethod]
        public void GetUserMenuGroup()
        {
            var users = _userBL.GetAllUserMenuGroupByOrganizationID(1);
            Assert.IsTrue(users != null, "No record found");
        }

        [TestMethod]
        public void GetUserMenuGroupByGroupName()
        {
            var res = _userBL.GetUserMenuGroupByGroupName("TgGroupa", 1);
            Assert.IsTrue(res != null, "No record found");
        }

        [TestMethod]
        public void GetUserMenuGroupByMenuIDs()
        {
            var res = _userBL.GetUserMenuGroupByMenuIDs("5,4,6", 1);
            Assert.IsTrue(res != null, "No record found");
        }

        [TestMethod]
        public void GetDefaulClientAdminByOrganizationID()
        {
            var res = _userBL.GetDefaulClientAdminByOrganizationID(1);
            Assert.IsTrue(res != null, " No Record Found");
        }

        [TestMethod]
        public void getAllUserMenuGroupAndPremissionAccordingToOrganizationID()
        {
            var res = _userBL.GetAllUserMenuGroupAndPremissionAccordingToOrganizationID(1);
            Assert.IsTrue(res != null, "No record found");
        }
    }
}
