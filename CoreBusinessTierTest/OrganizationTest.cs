using HCRGUniversity.Core.BL;
using HCRGUniversity.Core.BL.Implementation;
using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreBusinessTierTest
{
    [TestClass]
    public class OrganizationTest
    {
        private IOrganizationContactRepository _OrganizationContactRepository;
        private IOrganizationContact _OrganizationContactBL;
        private IOrganizationRepository _organizationRepository;
      
        private HCRGUniversity.Core.Data.Model.OrganizationContact dataModel = new HCRGUniversity.Core.Data.Model.OrganizationContact();
        private HCRGUniversity.Core.BL.Model.OrganizationContact BLModel = new HCRGUniversity.Core.BL.Model.OrganizationContact();

        [TestInitialize]
        public void OrganizationInitialize()
        {
            _OrganizationContactRepository = new OrganizationContactRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _organizationRepository = new OrganizationRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _OrganizationContactBL = new OrganizationContactImpl(_OrganizationContactRepository, _organizationRepository);

        }


        [TestMethod]
        public void getOrgContactByOrgID()
        {
            var faqFullDetail = _OrganizationContactBL.GetOrganizationContactByOrganizationID(0,14);
            Assert.IsTrue(faqFullDetail != null, "Unable to get");
        }
        [TestMethod]
        public void getSingleOrgContactByOrgID()
        {
            var faqFullDetail = _OrganizationContactBL.GetSingleOrgContactByOrgID(100);
            Assert.IsTrue(faqFullDetail != null, "Unable to get");
        }

        [TestMethod]
        public void GetOrganizationMenuByOrganizationID()
        {
            var faqFullDetail = _organizationRepository.GetOrganizationMenuByOrganizationID(100);
            Assert.IsTrue(faqFullDetail != null, "Unable to get");
        }
       
    }
}
