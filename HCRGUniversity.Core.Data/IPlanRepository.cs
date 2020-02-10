using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.Data
{
    public interface IPlanRepository : IBaseRepository<Plan>
    {
       
        IEnumerable<BLModel.PlanPackages> GetAllPlanAccToPackages();
        IEnumerable<BLModel.Plan> GetAllPlansByClientID(int ClientID);
        IEnumerable<BLModel.PlanGrid> GetAllPagedPlanByClientID(int clientID,int orgID,int skip, int take);
        int GetAllPagedPlanByClientIDCount(int clientID,int orgID);
       
    }
}
