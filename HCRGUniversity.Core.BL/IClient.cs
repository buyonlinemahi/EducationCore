using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.BL
{
    public interface IClient
    {
        int AddClient(Client client);
        int UpdateClient(Client client);
        void DeleteClient(int clientID);
        IEnumerable<BLModel.Client> GetClientsByPlanID(int planID);
        BLModel.Paged.Client GetOrganizationClientsByID(int OrganizationID, int Skip, int take);
        IEnumerable<Client> GetAllClients();
        Client GetClientByEmailID(string EmailID);
        Client GetClientByID(int clientID);
        BLModel.Paged.Client GetClientVerifiedDetails(int _skip, int _take);
        BLModel.Client GetClientByClientName(string clientName);
        BLModel.Client GetClientByEmailAndOrganizationId(string _clientEmailID, int OrganizationID);
        BLModel.Paged.Client GetClientsByOrganizationID(int OrganizationID);
        BLModel.Paged.Client GetClientsOrganization();
        BLModel.Paged.Client GetClientsByName(string name, int skip, int take, int clientID);
        void ResetClientPassword(int _clientID, string password);
        void UpdateClientSessionIDByClientID(int clientId, string clientSessionID);
        void ResetClientSessionID(int ClientID);
    }
}
