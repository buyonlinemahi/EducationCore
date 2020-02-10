using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.Data
{
    public interface ICoursePlanRepository : IBaseRepository<CoursePlan>
    {
        int CheckCoursesAreadyExistsForPlan(int PlanID, int CourseID);
        IEnumerable<BLModel.PlanPackages> GetCoursesPlanAccToPlanID(int PlanID);
        IEnumerable<BLModel.PlanPackages> GetAllCoursesPlan();
    }
}
