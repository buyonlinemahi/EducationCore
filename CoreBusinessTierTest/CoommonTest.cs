using HCRGUniversity.Core.BL.Implementation;
using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreBusinessTierTest
{
    [TestClass]
    public class CoommonTest
    {
        private IIndustryRepository _industryRepository;

        private HCRGUniversity.Core.BL.IIndustry _IndustryBL;
        private HCRGUniversity.Core.Data.Model.Industry IndustryPage = new HCRGUniversity.Core.Data.Model.Industry();

        [TestInitialize]
        public void IndustryInitialize()
        {
            _industryRepository = new IndustryRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _IndustryBL = new IndustryImpl(_industryRepository);
        }
        [TestMethod]
        public void get_AllIndustry()
        {
            var getallIndustry = _IndustryBL.getAllIndustry();
            Assert.IsTrue(getallIndustry != null, "Unable to get");

        }



    }
}
