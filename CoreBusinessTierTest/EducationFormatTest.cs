using HCRGUniversity.Core.BL;
using HCRGUniversity.Core.BL.Implementation;
using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CoreBusinessTierTest
{
    [TestClass]
    public class EducationFormatTest
    {
        private IEducationFormatRepository _educationFormatRepository;
        private IOrganizationRepository _organizationRepository;
        private IEducationFormat _educationFormatBL;
        private HCRGUniversity.Core.Data.Model.EducationFormat DLModel = new HCRGUniversity.Core.Data.Model.EducationFormat();
   
        [TestInitialize]
        public void EducationFormatInitialize()
        {
            _educationFormatRepository = new EducationFormatRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _organizationRepository = new OrganizationRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _educationFormatBL = new EducationFormatImpl(_educationFormatRepository, _organizationRepository);
        }

        [TestMethod]
        public void AddEducationFormat()
        {
            DLModel.EducationFormatType = "sdfsdfsdf";
             
            int result = _educationFormatBL.AddEducationFormat(DLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }
        [TestMethod]
        public void UpdateEducationFormat()
        {
            DLModel.EducationFormatType = "sadf dsf asd";
            DLModel.EducationFormatID = 1;
            int result = _educationFormatBL.UpdateEducationFormat(DLModel);
            Assert.IsTrue(result > 0, "Unable to update");
        }
        [TestMethod]
        public void getAllEducationFormat()
        {
            var educationFormat = _educationFormatBL.getAllEducationFormat(1);
            Assert.IsTrue(educationFormat != null, "Unable to get");
        }

        [TestMethod]
        public void GetEducationFormatNotAssociateWithEducation()
        {
            IEnumerable<HCRGUniversity.Core.Data.Model.EducationFormat> educationFormat = _educationFormatBL.GetEducationFormatNotAssociateWithEducation(1);
            Assert.IsTrue(educationFormat != null, "Unable to get");
        }

        [TestMethod]
        public void GetAllPagedEducationFormat()
        {
            var educationformat = _educationFormatBL.GetAllPagedEducationFormat(0, 10);
            Assert.IsTrue(educationformat != null, "Unable to find");
        }

       
    }
}