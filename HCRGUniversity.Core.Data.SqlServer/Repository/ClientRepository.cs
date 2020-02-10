using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using HCRGUniversity.Core.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using BLModel = HCRGUniversity.Core.BL.Model;


namespace HCRGUniversity.Core.Data.SqlServer.Repository
{
    public class ClientRepository : BaseRepository<Client, HCRGUniversityDBContext>, IClientRepository
    {
        public ClientRepository(IContextFactory<HCRGUniversityDBContext> contextFactory):base(new BaseUnitOfWork<HCRGUniversityDBContext>(contextFactory), contextFactory)
        {

        }

        public IEnumerable<BLModel.Client> GetOrganizationClientsByID(int OrganizationID, int Skip, int take)
        {
            SqlParameter _organizationID = new SqlParameter("@OrganizationID", OrganizationID);
            SqlParameter _Skip = new SqlParameter("Skip", Skip);
            SqlParameter _take = new SqlParameter("@take", take);
            return Context.Database.SqlQuery<BLModel.Client>(Constant.StoredProcedureConst.ClientRepositoryProcedure.GetOrganizationClientsByID, _organizationID, _Skip, _take);
        }

        public int GetOrganizationClientsByIDCount(int OrganizationID)
        {
            SqlParameter _organizationID = new SqlParameter("@OrganizationID", OrganizationID);
            return Context.Database.SqlQuery<int>(Constant.StoredProcedureConst.ClientRepositoryProcedure.GetOrganizationClientsByIDCount, _organizationID).SingleOrDefault();
        }

        public IEnumerable<BLModel.Client> GetClientsByPlanID(int PlanID)
        {
            SqlParameter _PlanID = new SqlParameter("@PlanID ", PlanID);
            return Context.Database.SqlQuery<BLModel.Client>(Constant.StoredProcedureConst.ClientRepositoryProcedure.GetClientsByPlanID, _PlanID);
        }
        public IEnumerable<Client> GetAllPagedClientByFilter(System.Linq.Expressions.Expression<Func<Client, bool>> where, int skip, int take)
        {
            if (where != null)
                return dbset.Where(where).OrderBy(c => c.ClientID).Skip(skip).Take(take);
            else
                return dbset.ToArray().OrderByDescending(c => c.ClientID).Skip(skip).Take(take);
        }

        public IEnumerable<BLModel.Client> GetClientDetailByFilter(string searchText, int skip, int take, int clientID)
        {
            SqlParameter _searchText = new SqlParameter("@SearchText", searchText);
            SqlParameter _skip = new SqlParameter("Skip", skip);
            SqlParameter _take = new SqlParameter("@take", take);
            SqlParameter _clientID = new SqlParameter("@ClientID", clientID);
            return Context.Database.SqlQuery<BLModel.Client>(Constant.StoredProcedureConst.ClientRepositoryProcedure.GetClientDetailByFilter, _searchText, _skip, _take, _clientID);
        }
        public int GetClientDetailByFilterCount(string searchText, int clientID)
        {
            SqlParameter _searchText = new SqlParameter("@SearchText", searchText);
            SqlParameter _clientID = new SqlParameter("@ClientID", clientID);
            return Context.Database.SqlQuery<int>(Constant.StoredProcedureConst.ClientRepositoryProcedure.GetClientDetailByFilterCount, _searchText, _clientID).SingleOrDefault();
        }

        public void UpdateClientSessionIDByClientID(int clientId, string clientSessionID)
        {
            SqlParameter _clientId = new SqlParameter("@ClientID", clientId);
            SqlParameter _clientSessionID = new SqlParameter("@ClientSessionID", clientSessionID);
            Context.Database.ExecuteSqlCommand(Constant.StoredProcedureConst.ClientRepositoryProcedure.UpdateClientSessionIDByClientID, _clientId, _clientSessionID);
        }

        public void ResetClientSessionID(int ClientID)
        {
            SqlParameter _clientID = new SqlParameter("@ClientID", ClientID);
            Context.Database.ExecuteSqlCommand(Constant.StoredProcedureConst.ClientRepositoryProcedure.ResetClientSessionID, _clientID);
        }
    }
}
