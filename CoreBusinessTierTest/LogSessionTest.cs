using HCRGUniversity.Core.BL;
using HCRGUniversity.Core.BL.Implementation;
using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace CoreBusinessTierTest
{
    [TestClass]
    public class LogSessionTest
    {
        private ILogSessionRepository _logSessionRepository;
        private ILogSession _logSessionBL;
        private  IEducationRepository _EducationRepository;
        private  IMyEducationRepository _myEducationRepository;
        private  IUserRepository _UserRepository;
        private HCRGUniversity.Core.Data.Model.LogSession DLModel = new HCRGUniversity.Core.Data.Model.LogSession();
        [TestInitialize]
        public void LogSessionInitialize()
        {
            _logSessionRepository = new LogSessionRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _myEducationRepository = new MyEducationRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _EducationRepository = new EducationRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _UserRepository = new UserRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _logSessionBL = new LogSessionImpl(_logSessionRepository,_EducationRepository,_myEducationRepository,_UserRepository);
        }
        [TestMethod]
        public void AddLogSession()
        {
            DLModel.SessionId = 166;
            DLModel.UserId = 166;
            DLModel.PageUrl = "RevisitModule";
            DLModel.Browser = "ie";
            DLModel.MEID = 316;
            DLModel.LogCreatedDate = System.DateTime.Now;
            int result = _logSessionBL.AddSession(DLModel);
       //     _logSessionBL.LogModuleOrExam("12", "12", 12, 12);
        }
        [TestMethod]
        public void DeleteSession()
        {
            _logSessionBL.DeleteSession("ie", 321, 166);
        }
        [TestMethod]
        public void LogModuleOrExam()
        {
            _logSessionBL.LogModuleOrExam("ie", "RevisitModule",321,166);
        }
        [TestMethod]
        public void CheckLogModuleOrExam()
        {
            bool result = _logSessionBL.CheckLogModuleOrExam(12, 12);
        }
    
        [TestMethod]
        public void getLogSessionByUserIDAndMEID()
        {
            var d = _logSessionBL.getLogSessionByUserIDAndMEID(12,123);
        }
        [TestMethod]
        public void DeleteSessionAfterSchedule()
        {
            _logSessionBL.DeleteSessionAfterSchedule(12,1);
        }
        [TestMethod]
        public void getAllLogSession()
        {
            var ss = _logSessionBL.getAllLogSession(0,10);
        }
        [TestMethod]
        public void GetLogSessionByUserName()
        {
            var ss = _logSessionBL.GetLogSessionByUserName("t",0, 10,1);
        }
        [TestMethod]
        public void DeleteSessionByAdmin()
        {
            _logSessionBL.DeleteSessionByAdmin(21);
        }
    }
}
