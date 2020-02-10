using HCRGUniversity.Core.BL;
using HCRGUniversity.Core.BL.Implementation;
using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreBusinessTierTest
{
    [TestClass]
    public class SuggestCourseTest
    {
        private ISuggestCourseRepository _suggestCourse;     

        [TestInitialize]
        public void SuggestCourseInitialize()
        {
            _suggestCourse = new SuggestCourseRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
        }

        [TestMethod]
        public void GetAllSuggestCoursesByOrganizationID()
        {
            var res = _suggestCourse.GetAllSuggestCoursesByOrganizationID(14,100);
            Assert.IsTrue(res != null, "Unable to find");
        }        
    }
}
