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
    public class CoursePlanRepository : BaseRepository<CoursePlan, HCRGUniversityDBContext>, ICoursePlanRepository
    {
        public CoursePlanRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }
        public int CheckCoursesAreadyExistsForPlan(int PlanID, int CourseID)
        {
            SqlParameter _PlanID = new SqlParameter("@PlanID", PlanID);
            SqlParameter _CourseID = new SqlParameter("@CourseID", CourseID);
            return Context.Database.SqlQuery<int>(Constant.StoredProcedureConst.CoursesPlanRepositoryProcedure.CheckCoursesAreadyExistsForPlan, _PlanID, _CourseID).FirstOrDefault();
        }

        public IEnumerable<BLModel.PlanPackages> GetCoursesPlanAccToPlanID(int PlanID)
        {
            SqlParameter _PlanID = new SqlParameter("@PlanID", PlanID);
            return Context.Database.SqlQuery<BLModel.PlanPackages>(Constant.StoredProcedureConst.CoursesPlanRepositoryProcedure.GetCoursesPlanAccToPlanID, _PlanID).ToList();
        }

        public IEnumerable<BLModel.PlanPackages> GetAllCoursesPlan()
        {
            return Context.Database.SqlQuery<BLModel.PlanPackages>(Constant.StoredProcedureConst.CoursesPlanRepositoryProcedure.GetAllCoursesPlan).ToList();
        }
    }
}
