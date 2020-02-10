using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using BLModel = HCRGUniversity.Core.BL.Model;


namespace HCRGUniversity.Core.Data.SqlServer.Repository
{
    public class UserPlanRepository : BaseRepository<UserPlan, HCRGUniversityDBContext>, IUserPlanRepository
    {
        public UserPlanRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }

        public int CheckUserAreadyExistsForPlan(int PlanID, int UserID)
        {
            SqlParameter _PlanID = new SqlParameter("@PlanID", PlanID);
            SqlParameter _UserID = new SqlParameter("@UserID", UserID);
            return Context.Database.SqlQuery<int>(Constant.StoredProcedureConst.UserPlanRepositoryProcedure.CheckUserAreadyExistsForPlan, _PlanID, _UserID).FirstOrDefault();
        }

        public IEnumerable<BLModel.PlanPackages> GetUsersPlanAccToPlanID(int PlanID)
        {
            SqlParameter _PlanID = new SqlParameter("@PlanID", PlanID);
            return Context.Database.SqlQuery<BLModel.PlanPackages>(Constant.StoredProcedureConst.UserPlanRepositoryProcedure.GetUsersPlanAccToPlanID,_PlanID).ToList();
        }

        public IEnumerable<BLModel.PlanPackages> GetAllUsersPlan()
        {
            return Context.Database.SqlQuery<BLModel.PlanPackages>(Constant.StoredProcedureConst.UserPlanRepositoryProcedure.GetAllUsersPlan).ToList();
        }

        public int AddMyEducationRecordByPlanID(int planID)
        {
            SqlParameter _planID = new SqlParameter("@PlanID", planID);
            return Context.Database.SqlQuery<int>(Constant.StoredProcedureConst.UserPlanRepositoryProcedure.AddMyEducationRecordByPlanID, _planID).SingleOrDefault();
        }
    }
}
