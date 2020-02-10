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
    public class PlanRepository : BaseRepository<Plan, HCRGUniversityDBContext>, IPlanRepository
    {
        public PlanRepository(IContextFactory<HCRGUniversityDBContext> contextFactory) :
            base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {
        }
        public IEnumerable<BLModel.PlanGrid> GetAllPagedPlanByClientID(int clientID,int orgID,int skip, int take)
        {
            SqlParameter _skip = new SqlParameter("@Skip", skip);
            SqlParameter _take = new SqlParameter("@Take", take);
            SqlParameter _clientID = new SqlParameter("@ClientID", clientID);
            SqlParameter _orgID = new SqlParameter("@OrgID", orgID);
            return Context.Database.SqlQuery<BLModel.PlanGrid>(Constant.StoredProcedureConst.PlanRepositoryProcedure.GetAllPagedPlanByClientID, _clientID,_orgID, _skip, _take).ToList();
        }
        public int GetAllPagedPlanByClientIDCount(int clientID, int orgID)
        {
            SqlParameter _clientID = new SqlParameter("@ClientID", clientID);
            SqlParameter _orgID = new SqlParameter("@OrgID", orgID);
            return Context.Database.SqlQuery<int>(Constant.StoredProcedureConst.PlanRepositoryProcedure.GetAllPagedPlanByClientIDCount, _clientID,_orgID).FirstOrDefault();
        }

        public IEnumerable<BLModel.PlanPackages> GetAllPlanAccToPackages()
        {
            return Context.Database.SqlQuery<BLModel.PlanPackages>(Constant.StoredProcedureConst.PlanRepositoryProcedure.GetAllPlanAccToPackages).ToList();
        }
        public IEnumerable<BLModel.Plan> GetAllPlansByClientID(int ClientID)
        {
            SqlParameter _ClientID = new SqlParameter("@ClientID", ClientID);
            return Context.Database.SqlQuery<BLModel.Plan>(Constant.StoredProcedureConst.PlanRepositoryProcedure.GetAllPlansByClientID, _ClientID).ToList();
        }
        
    }
}
