using HCRGUniversity.Core.Data;
using Omu.ValueInjecter;
using System.Collections.Generic;
using System.Linq;
using BLModel = HCRGUniversity.Core.BL.Model;
using DLModel = HCRGUniversity.Core.Data.Model;


namespace HCRGUniversity.Core.BL.Implementation
{
    public class PlanImpl : IPlan
    {
        private readonly IPlanRepository _planRepository;
        private readonly IUserPlanRepository _userPlanRepository;
        private readonly ICoursePlanRepository _coursePlanRepository;
        public PlanImpl(IPlanRepository planRepository, IUserPlanRepository userPlanTermRepository, ICoursePlanRepository coursePlanRepository)
        {
            _planRepository = planRepository;
            _userPlanRepository = userPlanTermRepository;
            _coursePlanRepository = coursePlanRepository;
        }
        #region Plan
        public int AddPlan(BLModel.Plan plan)
        {
            return _planRepository.Add((DLModel.Plan)new DLModel.Plan().InjectFrom(plan)).PlanID;
        }

        public int UpdatePlan(BLModel.Plan plan)
        {
            return _planRepository.Update((DLModel.Plan)new DLModel.Plan().InjectFrom(plan));
        }


        public void DeletePlan(int planID)
        {
            _planRepository.Delete(_planRepository.GetById(planID));
        }
        public IEnumerable<BLModel.Plan> getAll()
        {
            IEnumerable<BLModel.Plan> _plan = _planRepository.GetAll().Select(plan => new BLModel.Plan().InjectFrom(plan)).Cast<BLModel.Plan>().OrderBy(plan => plan.PlanID).ToList();
            return _plan;
        }

        public DLModel.Plan GetPlanById(int _planID)
        {
            return (DLModel.Plan)new DLModel.Plan().InjectFrom(_planRepository.GetById(_planID));
        }

        public BLModel.Paged.PlanGrid GetAllPagedPlanByClientID(int clientID, int orgID, int skip, int take)
        {
            return new BLModel.Paged.PlanGrid
            {
                TotalCount = _planRepository.GetAllPagedPlanByClientIDCount(clientID,orgID),
                PlanRecords = _planRepository.GetAllPagedPlanByClientID(clientID,orgID,skip, take).Select(plan => (BLModel.PlanGrid)new BLModel.PlanGrid().InjectFrom(plan)).ToList()
            };
        }
        public IEnumerable<BLModel.PlanPackages> GetAllPlanAccToPackages()
        {
            return _planRepository.GetAllPlanAccToPackages();
        }

        public IEnumerable<BLModel.Plan> GetAllPlansByClientID(int ClientID)
        {
            return _planRepository.GetAllPlansByClientID(ClientID);
        }
        #endregion

        #region UserPlan
        public int AddUserPlan(DLModel.UserPlan userPlan)
        {
            if (_userPlanRepository.CheckUserAreadyExistsForPlan(userPlan.PlanID, userPlan.UserID) > 0)
            {
                return 0;
            }
            else
            {
                return _userPlanRepository.Add((DLModel.UserPlan)new DLModel.UserPlan().InjectFrom(userPlan)).UserPlanID;
            }
        }
        public void DeleteUserPlan(int userPlanID)
        {
            _userPlanRepository.Delete(_userPlanRepository.GetById(userPlanID));
        }
        public IEnumerable<BLModel.PlanPackages> GetUsersPlanAccToPlanID(int PlanID)
        {
            return _userPlanRepository.GetUsersPlanAccToPlanID(PlanID);
        }
        public IEnumerable<BLModel.PlanPackages> GetAllUsersPlan()
        {
            return _userPlanRepository.GetAllUsersPlan();
        }

        public int AddMyEducationRecordByPlanID(int _planID)
        {
            return _userPlanRepository.AddMyEducationRecordByPlanID(_planID);
        }
        #endregion

        #region CoursePlan
        public int AddCoursePlan(BLModel.CoursePlan coursePlan)
        {
            if (_coursePlanRepository.CheckCoursesAreadyExistsForPlan(coursePlan.PlanID, coursePlan.CourseID) > 0)
            {
                return 0;
            }
            else
            {
                return _coursePlanRepository.Add((DLModel.CoursePlan)new DLModel.CoursePlan().InjectFrom(coursePlan)).CoursePlanID;
            }
        }
        public void DeleteCoursePlan(int coursePlanID)
        {
            _coursePlanRepository.Delete(_coursePlanRepository.GetById(coursePlanID));

        }
        public IEnumerable<BLModel.PlanPackages> GetCoursesPlanAccToPlanID(int PlanID)
        {
            return _coursePlanRepository.GetCoursesPlanAccToPlanID(PlanID);
        }
        public IEnumerable<BLModel.PlanPackages> GetAllCoursesPlan()
        {
            return _coursePlanRepository.GetAllCoursesPlan();
        }
        #endregion
    }
}
