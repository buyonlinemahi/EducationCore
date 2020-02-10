using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.Model;
using Omu.ValueInjecter;
using System.Collections.Generic;
using System.Linq;
using BLModel = HCRGUniversity.Core.BL.Model;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL.Implementation
{
   public class ClientImpl : IClient
    {
       private readonly IClientRepository _clientRepository;

       public ClientImpl(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

       public int AddClient(DLModel.Client client)
       {
        return _clientRepository.Add(client).ClientID;
       }

       public int UpdateClient(DLModel.Client client)
       {
           return _clientRepository.Update(client, (_c => _c.ClientID), (_c => _c.FirstName), (_c => _c.LastName), (_c => _c.EmailID), (_c => _c.Address), (_c => _c.Password),(_c => _c.ClientTypeID)
               , (_c => _c.Address2), (_c => _c.City), (_c => _c.StateID), (_c => _c.Zip), (_c => _c.Phone), (_c => _c.IsActive), (_c => _c.IsApproved),(_c => _c.IsEmailSent));
       }

       public void DeleteClient(int clientID)
       {
           _clientRepository.Delete(_clientRepository.GetById(clientID));
       }


       public BLModel.Paged.Client GetOrganizationClientsByID(int OrganizationID, int Skip, int take)
       {
           return new BLModel.Paged.Client
           {
               TotalCount = _clientRepository.GetOrganizationClientsByIDCount(OrganizationID),
               Clients = _clientRepository.GetOrganizationClientsByID(OrganizationID, Skip, take).Select(client => (BLModel.Client)new BLModel.Client().InjectFrom(client)).ToList()
           };
       }


       public BLModel.Paged.Client GetClientsByOrganizationID(int OrganizationID)
       {
           return new BLModel.Paged.Client
           {
               TotalCount = _clientRepository.GetAll(rk => rk.OrganizationID == OrganizationID).Count(),
               Clients = _clientRepository.GetAll(rk => rk.OrganizationID == OrganizationID).Select(client => (BLModel.Client)new BLModel.Client().InjectFrom(client)).ToList()
           };
       }

       public BLModel.Paged.Client GetClientsOrganization()
       {
           return new BLModel.Paged.Client
           {
               TotalCount = _clientRepository.GetAll().Count(),
               Clients = _clientRepository.GetAll().Select(client => (BLModel.Client)new BLModel.Client().InjectFrom(client)).ToList()
           };
       }



       public IEnumerable<Client> GetAllClients()
       {
           return _clientRepository.GetAll();
       }
       public Client GetClientByEmailID(string EmailID)
       {
           var Client = _clientRepository.GetAll(cl => cl.EmailID == EmailID).FirstOrDefault();
           return Client != null ? (Client)new Client().InjectFrom(Client) : null;
       }


       public Client GetClientByID(int clientID)
        {          
             return _clientRepository.GetById(clientID) ;
        }
       public BLModel.Paged.Client GetClientVerifiedDetails(int _skip, int _take)
       {
           return new BLModel.Paged.Client
           {
               TotalCount = _clientRepository.GetAll(c => c.IsActive.Value == true && c.IsApproved.Value == true).Select(user => (BLModel.Client)new BLModel.Client().InjectFrom(user)).Count(),
               Clients = _clientRepository.GetAll(c => c.IsActive.Value == true && c.IsApproved.Value == true).OrderByDescending(client => client.ClientID).Skip(_skip).Take(_take).Select(client => (BLModel.Client)new BLModel.Client().InjectFrom(client)).ToList()
           };
       }

       public BLModel.Client GetClientByClientName(string clientName)
       {
           var Client = _clientRepository.GetAll(c => c.EmailID == clientName && c.IsActive.Value == true && c.IsApproved.Value == true).FirstOrDefault();
           return Client != null ? (BLModel.Client)new BLModel.Client().InjectFrom(Client) : null;
       }

       public BLModel.Client GetClientByEmailAndOrganizationId(string _clientEmailID, int OrganizationID)
       {
           var Client = _clientRepository.GetAll(c => c.EmailID == _clientEmailID && c.OrganizationID == OrganizationID).FirstOrDefault();
           return Client != null ? (BLModel.Client)new BLModel.Client().InjectFrom(Client) : null;
       }

       public IEnumerable<BLModel.Client> GetClientsByPlanID(int planID)
       {
           return _clientRepository.GetClientsByPlanID(planID);
       }
      public BLModel.Paged.Client GetClientsByName(string name, int skip, int take, int clientID)
       {
           return new BLModel.Paged.Client
           {
               //TotalCount = _clientRepository.GetClientDetailByFilter((client => client.FirstName.StartsWith(name) && (client.OrganizationID == OrganizationID))),
               //Clients = _clientRepository.GetAllPagedClientByFilter((client => client.FirstName.StartsWith(name) && (client.OrganizationID == OrganizationID)), skip, take).Select(client => (BLModel.Client)new BLModel.Client().InjectFrom(client)).ToList()

               TotalCount = _clientRepository.GetClientDetailByFilterCount(name, clientID),
               Clients = _clientRepository.GetClientDetailByFilter(name, skip, take, clientID).Select(client => (BLModel.Client)new BLModel.Client().InjectFrom(client)).ToList()
           };
       }

      public void ResetClientPassword(int _clientID, string password)
      {
          DLModel.Client _client = new DLModel.Client
          {
              ClientID = _clientID,
              Password = password,
              IsActive = true,
          };
          _clientRepository.Update((DLModel.Client)new DLModel.Client().InjectFrom(_client), hp => hp.Password, hp => hp.IsActive);
      }

      public void UpdateClientSessionIDByClientID(int clientId, string clientSessionID)
      {
          _clientRepository.UpdateClientSessionIDByClientID(clientId, clientSessionID);
      }

      public void ResetClientSessionID(int ClientID)
      {
          _clientRepository.ResetClientSessionID(ClientID);
      }
    }
}
