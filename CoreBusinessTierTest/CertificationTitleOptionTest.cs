using HCRGUniversity.Core.BL;
using HCRGUniversity.Core.BL.Implementation;
using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreBusinessTierTest
{
    [TestClass]
    public class CertificationTitleOptionTest
    {
        private ICertificationTitleOptionRepository _certificationTitleOptionRepository;
        private IEducationRepository _educationRepository;
        private ICollegeEducationRepository _collegeEducationRepository;
        private IEducation _educationBL;
        private IEducationFormatAvailableRepository _educationFormatAvailableRepository;
        private IEducationTypesAvailableRepository _educationTypesAvailableRepository;
        private IEducationDetailPageRepository _educationDetailPageRepository;
        private INewsRepository _newsRepository;
        private ICertificationTitleOption _certificationTitleOptionBL;
        private IOrganizationRepository _organizationRepository;

        private HCRGUniversity.Core.Data.Model.CertificationTitleOption DLModel = new HCRGUniversity.Core.Data.Model.CertificationTitleOption();


        [TestInitialize]
        public void CertificationTitleOptionInitialize()
        {
            _certificationTitleOptionRepository = new CertificationTitleOptionRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _educationRepository = new EducationRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _collegeEducationRepository = new CollegeEducationRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _educationFormatAvailableRepository = new EducationFormatAvialableRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _educationTypesAvailableRepository = new EducationTypesAvailableRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _educationDetailPageRepository = new EducationDetailPageRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _newsRepository = new NewsRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _organizationRepository = new OrganizationRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _educationBL = new EducationImpl(_educationRepository, _collegeEducationRepository, _educationFormatAvailableRepository, _educationTypesAvailableRepository, _educationDetailPageRepository, _newsRepository, _organizationRepository);
            _certificationTitleOptionBL = new CertificationTitleOptionImpl(_certificationTitleOptionRepository, _educationRepository);
        }


        [TestMethod]
        public void addCertificationTitleOptions()
        {
            DLModel.CertificationTitle = "Testing Guru 1";
            DLModel.CertificationContent = "BAAddress2";
            DLModel.EducationId = 574;
            int result = _certificationTitleOptionBL.AddCertificationTitleOption(DLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }

        [TestMethod]
        public void updateCertificationTitleOptions()
        {
            DLModel.CertificationTitleOptionID = 1;
            DLModel.CertificationTitle = "Testing 1s";
            DLModel.CertificationContent = "BAAddress2";
            DLModel.EducationId = 574;
            int result = _certificationTitleOptionBL.UpdateCertificationTitleOption(DLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }

        [TestMethod]
        public void GetCertificationTitleOptionsByID()
        {
            var _result = _certificationTitleOptionBL.GetCertificationTitleOptionsByID(1);
            Assert.IsTrue(_result != null, "Unable to get");
        }

        [TestMethod]
        public void getAllBillingAddressByUserID()
        {
            _certificationTitleOptionBL.DeleteCertificationTitleOption(1);
        }

        [TestMethod]
        public void GetPagedCertificationTitleOption()
        {
            var _result = _certificationTitleOptionBL.GetPagedCertificationTitleOption(0, 10);
            Assert.IsTrue(_result != null, "Unable to get");
        }

        [TestMethod]
        public void GetDropDownListOption()
        {
            var _result = _certificationTitleOptionBL.GetCourseDropDownList(1);
            Assert.IsTrue(_result != null, "Unable to get");
        }

    }
}
