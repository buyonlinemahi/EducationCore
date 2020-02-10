using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL
{
    public interface IPlan
    {
        #region Plan
        int AddPlan(BLModel.Plan plan);
        int UpdatePlan(BLModel.Plan plan);
        void DeletePlan(int planID);
        DLModel.Plan GetPlanById(int _planID);
        IEnumerable<BLModel.Plan> getAll();
        BLModel.Paged.PlanGrid GetAllPagedPlanByClientID(int clientID, int orgID, int skip, int take);
        IEnumerable<BLModel.PlanPackages> GetAllPlanAccToPackages();
        IEnumerable<BLModel.Plan> GetAllPlansByClientID(int ClientID);
        #endregion

         #region UserPlan
        int AddUserPlan(DLModel.UserPlan userPlan);
        void DeleteUserPlan(int userPlanID);
        IEnumerable<BLModel.PlanPackages> GetUsersPlanAccToPlanID(int PlanID);
        IEnumerable<BLModel.PlanPackages> GetAllUsersPlan();

        int AddMyEducationRecordByPlanID(int _planID);

        #endregion

        #region CoursePlan
        int AddCoursePlan(BLModel.CoursePlan plan);
        void DeleteCoursePlan(int coursePlanID);
        IEnumerable<BLModel.PlanPackages> GetCoursesPlanAccToPlanID(int PlanID);
        IEnumerable<BLModel.PlanPackages> GetAllCoursesPlan();
        #endregion
    }
}
