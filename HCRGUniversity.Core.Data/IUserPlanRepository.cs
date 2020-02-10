using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;
namespace HCRGUniversity.Core.Data
{
    public interface IUserPlanRepository : IBaseRepository<UserPlan>
    {
        int CheckUserAreadyExistsForPlan(int PlanID, int UserID);
        IEnumerable<BLModel.PlanPackages> GetUsersPlanAccToPlanID(int PlanID);
        IEnumerable<BLModel.PlanPackages> GetAllUsersPlan();

        int AddMyEducationRecordByPlanID(int _planID);
    }
}
