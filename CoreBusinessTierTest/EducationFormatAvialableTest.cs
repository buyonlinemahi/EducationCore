using HCRGUniversity.Core.BL;
using HCRGUniversity.Core.BL.Implementation;
using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.Model;
using HCRGUniversity.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;

namespace CoreBusinessTierTest
{
    [TestClass]
    public class EducationFormatAvialableTest
    {
        private IEducationFormatAvailableRepository _educationFormatAvailableRepository;
        private IEducationFormatAvailable _educationFormatAvialableBL;
        private HCRGUniversity.Core.Data.Model.EducationFormatAvailable DLModel = new HCRGUniversity.Core.Data.Model.EducationFormatAvailable();

        [TestInitialize]
        public void EducationFormatAvialableInitialize()
        {
            _educationFormatAvailableRepository = new EducationFormatAvialableRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _educationFormatAvialableBL = new EducationFormatAvialableImpl(_educationFormatAvailableRepository);
        }

        [TestMethod]
        public void AddEducationFormatAvailable()
        {
            DLModel.EducationFormatID = 1;
            DLModel.EducationID = 1;
            int result = _educationFormatAvialableBL.AddEducationFormatAvailable(DLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }
        [TestMethod]
        public void UpdateEducationFormatAvailable()
        {
            DLModel.EducationID = 1;
            DLModel.EducationFormatID = 2;
            DLModel.EducationAvailableID = 1;
            int result = _educationFormatAvialableBL.UpdateEducationFormatAvailable(DLModel);
            Assert.IsTrue(result > 0, "Unable to update");
        }
        [TestMethod]
        public void GetEducationFormatByEducationID()
        {
            IEnumerable<EducationFormatDetail> result = _educationFormatAvialableBL.GetEducationFormatsByEducationID(1);
            Assert.IsTrue(result != null, "Unable to Get");
        }
    }
}