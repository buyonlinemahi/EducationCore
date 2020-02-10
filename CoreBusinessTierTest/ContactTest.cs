using HCRGUniversity.Core.BL;
using HCRGUniversity.Core.BL.Implementation;
using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;


namespace CoreBusinessTierTest
{
    [TestClass]
    public class ContactTest
    {
       private IContactRepository _contactRepository;
       private HCRGUniversity.Core.BL.IContact _ContactBL;
     
    
        private HCRGUniversity.Core.Data.Model.Contact ContactPage = new HCRGUniversity.Core.Data.Model.Contact();

        [TestInitialize]
        public void ContactInitialize()
        {

            _contactRepository = new ContactRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _ContactBL = new ContactImpl(_contactRepository);
        }


        [TestMethod]
        public void AddContact()
        {
            ContactPage .ClientID= 9;
            ContactPage.Phone  = "991531852";
            ContactPage.Fax = "4";
            ContactPage.EmailID = "j@J.COM";
            ContactPage.Address = "TET";
            ContactPage.Address2 = "tEST2";
            ContactPage.City = "test343";
            ContactPage.StateID= 45;
            ContactPage.Zip = "45sds";
            ContactPage.OperationHour = "Monday-Friday";
            ContactPage.StartTime = "10.00 pm";
            ContactPage.EndTime = "6.00 am";
            int result = _ContactBL.AddContact(ContactPage);
            Assert.IsTrue(result > 0, "Unable to Add");
        }
        [TestMethod]
        public void UpdateEducation()
        {
            ContactPage.ContactID = 2;
            ContactPage.ClientID = 4;
            ContactPage.Phone = "00000";
            ContactPage.Fax = "000";
            ContactPage.EmailID = "0A@0.0";
            ContactPage.Address = "0";
            ContactPage.Address2 = "00000";
            ContactPage.City = "00000";
            ContactPage.StateID = 000;
            ContactPage.Zip = "00000";
            ContactPage.OperationHour = "Monday-Friday";
            ContactPage.StartTime = "10.00 pm";
            ContactPage.EndTime = "6.00 am";
            int result = _ContactBL.UpdateContact(ContactPage);
            Assert.IsTrue(result > 0, "Unable to update");
        }
    }
}
