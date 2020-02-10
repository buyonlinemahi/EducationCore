using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace HCRGUniversity.Core.Data.SqlServer.Repository
{
    public class MyEducationModuleRepository : BaseRepository<MyEducationModule, HCRGUniversityDBContext>, IMyEducationModuleRepository
    {
        public MyEducationModuleRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {

        }
        public void AddEducationModuleToMyEducationByEducationID(int meid, int educationID)
        {
            SqlParameter _meid = new SqlParameter("@MEID", meid);
            SqlParameter _educationID = new SqlParameter("@EducationID", educationID);
            Context.Database.ExecuteSqlCommand(Constant.StoredProcedureConst.MyEducationRepositoryProcedure.AddEducationModuleToMyEducationByEducationID, _meid, _educationID);
        }
        public IEnumerable<MyEducationModuleDetail> GetMyEducationModulesDetailsByMEID(int meID, int userID)
        {
            SqlParameter _meD = new SqlParameter("@MEID", meID);
            SqlParameter _userID = new SqlParameter("@UserID", userID);
            return Context.Database.SqlQuery<MyEducationModuleDetail>(Constant.StoredProcedureConst.MyEducationRepositoryProcedure.GetMyEducationModulesDetailsByMEID, _meD, _userID);
        }
        public MyEducationModuleDetail GetMyEducationModulesDetailByMEMID(int memID)
        {
            SqlParameter _memID = new SqlParameter("@MEMID", memID);
            return Context.Database.SqlQuery<MyEducationModuleDetail>(Constant.StoredProcedureConst.MyEducationRepositoryProcedure.GetMyEducationModulesDetailByMEMID, _memID).SingleOrDefault();
        }
        public void UpdateMyEducationModuleTimeLeft(int memID, string TimeLeft)
        {
            SqlParameter _memID = new SqlParameter("@MEMID", memID);
            SqlParameter _timeLeft = new SqlParameter("@TimeLeft", TimeLeft);
            Context.Database.ExecuteSqlCommand(Constant.StoredProcedureConst.MyEducationRepositoryProcedure.UpdateMyEducationModuleTimeLeft, _memID, _timeLeft);
        }

     
    }
}