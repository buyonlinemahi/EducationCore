using HCRGUniversity.Core.BL.Implementation;
using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreBusinessTierTest
{
     [TestClass]
    public class ClientTest
    {
         private IClientRepository _clientRepository;
         private HCRGUniversity.Core.BL.IClient _ClientBL;


        private HCRGUniversity.Core.Data.Model.Client clientPage = new HCRGUniversity.Core.Data.Model.Client();

        [TestInitialize]
        public void ContactInitialize()
        {

            _clientRepository = new ClientRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _ClientBL = new ClientImpl(_clientRepository);
        }



        [TestMethod]
        public void Addclient()
        {
            clientPage.OrganizationID = 1;
            clientPage.FirstName = "jaggi";
            clientPage.LastName = "Singh";
            clientPage.EmailID = "j@J.COM";
            clientPage.Address = "TET";
            clientPage.Address2 = "tEST2";
            clientPage.City = "test343";
            clientPage.StateID = 10;
            clientPage.Zip = "454545";
            clientPage.Phone = "9915313852";
            clientPage.IsActive = false;
            clientPage.IsApproved = false;
            clientPage.Password = "null";
           
            int result = _ClientBL.AddClient(clientPage);
            Assert.IsTrue(result > 0, "Unable to Add");
        }


        [TestMethod]
        public void UpdateClient()
        {
            clientPage.ClientID = 23;
           clientPage.FirstName = "sdfsdf";
            clientPage.LastName = "dsfsf";
            clientPage.EmailID = "j@J.COM";
            clientPage.Address = "TET";
            clientPage.Address2 = "tEST2";
            clientPage.City = "test343";
            clientPage.StateID = 45;
            clientPage.Zip = "45sds";
            clientPage.Phone = "65665565";
            clientPage.IsActive = true;
            clientPage.IsApproved = true;
            clientPage.IsEmailSent = true;
            int result = _ClientBL.UpdateClient(clientPage);
            Assert.IsTrue(result > 0, "Unable to update");
        }

        [TestMethod]
        public void GetallclientbyID()
        {
            var _client = _ClientBL.GetOrganizationClientsByID(1, 0, 12);
            Assert.IsTrue(_client != null, "Unable to find");
        }

        [TestMethod]
        public void Getallclient()
        {
            var _client = _ClientBL.GetAllClients();
            Assert.IsTrue(_client != null, "Unable to find");
        }

        [TestMethod]
        public void GetClientByEmailID()
        {
            var _client = _ClientBL.GetClientByEmailID("pk@vsaindia.com");
            Assert.IsTrue(_client != null, "Unable to find");
        }


        [TestMethod]
        public void GetClientByID()
        {
            var ClientDetail = _ClientBL.GetClientByID(11);
            Assert.IsTrue(ClientDetail != null, "Unable to get");
        }

        [TestMethod]
        public void GetUserVerifiedDetails()
        {
            var clients = _ClientBL.GetClientVerifiedDetails(0, 40);
            Assert.IsTrue(clients != null, "No record found");
        }
        [TestMethod]
        public void GetClientByClientName()
        {
            var client = _ClientBL.GetClientByClientName("pk@vsaindia.com");
            Assert.IsTrue(client != null, "Unable to find");
        }
    }
}
