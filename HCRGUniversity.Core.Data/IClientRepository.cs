using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.Data
{
    public interface IClientRepository : IBaseRepository<Client>
    {
        IEnumerable<BLModel.Client> GetOrganizationClientsByID(int OrganizationID, int Skip, int take);
        int GetOrganizationClientsByIDCount(int OrganizationID);
        IEnumerable<BLModel.Client> GetClientsByPlanID(int PlanID);
        //IEnumerable<Client> GetAllPagedClientByFilter(Expression<Func<Client, bool>> where, int skip, int take);
        //int GetClientDetailByFilter(System.Linq.Expressions.Expression<Func<Client, bool>> where);

        int GetClientDetailByFilterCount(string name, int clientID);
        IEnumerable<BLModel.Client> GetClientDetailByFilter(string name, int skip, int take, int clientID);
        void UpdateClientSessionIDByClientID(int clientId, string clientSessionID);
        void ResetClientSessionID(int ClientID);
    }
}
