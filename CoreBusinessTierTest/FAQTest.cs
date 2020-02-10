using HCRGUniversity.Core.BL;
using HCRGUniversity.Core.BL.Implementation;
using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace CoreBusinessTierTest
{
    [TestClass]
  public  class FAQTest
    {
        private IFAQRepository _faqRepository;
        private IFAQCategoryRepository _faqCategoryRepository;
        private IFAQ _faqBL;
        private HCRGUniversity.Core.Data.Model.FAQ BLModel = new HCRGUniversity.Core.Data.Model.FAQ();
        private HCRGUniversity.Core.Data.Model.FAQCategory DLModel = new HCRGUniversity.Core.Data.Model.FAQCategory();
        [TestInitialize]
        public void MyEducationInitialize()
        {
            _faqRepository = new FAQRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _faqCategoryRepository = new FAQCategoryRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _faqBL = new FAQImpl(_faqRepository, _faqCategoryRepository);
           
        }

        [TestMethod]
        public void Addfaq()
        {
            BLModel.FAQAns = "testing tesing";
            BLModel.FAQues = "testing tesing";
            BLModel.FAQCatID = 2;          
            int result = _faqBL.AddFAQ(BLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }
        [TestMethod]
        public void Updatefaq()
        {
            BLModel.FAQAns = "tebcvbcsting tesing";
            BLModel.FAQues = "testifdgdfgdfgng tesing";
            BLModel.FAQCatID = 2;
            BLModel.FAQID = 3;
            int result = _faqBL.UpdateFAQ(BLModel);
            Assert.IsTrue(result > 0, "Unable to update");
        }

        [TestMethod]
        public void Deletefaq()
        {
            _faqBL.DeleteFAQ(1);
        }

        [TestMethod]
        public void getAllfaq()
        {
            IEnumerable<HCRGUniversity.Core.Data.Model.FAQDetail> faq = _faqBL.getAllFAQ(1);
            Assert.IsTrue(_faqBL != null, "Unable to get");
        }
        [TestMethod]
        public void getfaqByID()
        {
            HCRGUniversity.Core.Data.Model.FAQ faq = _faqBL.GetFAQByID(1);
            Assert.IsTrue(_faqBL != null, "Unable to get");
        }
              

        [TestMethod]
        public void getAllfaqByfaqCatID()
        {
            IEnumerable<HCRGUniversity.Core.Data.Model.FAQDetail> faqFullDetail = _faqBL.GetFAQByCatID(2);
            Assert.IsTrue(_faqBL != null, "Unable to get");
        }
        
        //FAQCAT
        [TestMethod]
        public void AddfaqCategory()
        {
            DLModel.FAQCategoryTitle = "testing tesing";
            int result = _faqBL.AddFAQCategory(DLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }
        [TestMethod]
        public void UpdatefaqCategory()
        {
            DLModel.FAQCategoryTitle = "test  ing tesing";
            DLModel.FAQCatID = 1;
            int result = _faqBL.UpdateFAQCategory(DLModel);
            Assert.IsTrue(result > 0, "Unable to update");
        }

        [TestMethod]
        public void DeletefaqCategory()
        {
            _faqBL.DeleteFAQCategory(4);
        }

        [TestMethod]
        public void getAllfaqCategory()
        {
            IEnumerable<BLModel.FAQCategory> faqCategory = _faqBL.GetAllFAQCategoriesAccordingToOrganizationID(0,14);
            Assert.IsTrue(_faqBL != null, "Unable to get");
        }

        [TestMethod]
        public void getAllfaqs()
        {
            IEnumerable<BLModel.FAQ> faqCategory = _faqBL.GetAllFAQAccordingToOrganizationID(0, 14);
            Assert.IsTrue(_faqBL != null, "Unable to get");
        }

        [TestMethod]
        public void getfaqCategoryByID()
        {
            HCRGUniversity.Core.Data.Model.FAQCategory faqCategory = _faqBL.GetFAQCategoryByID(1);
            Assert.IsTrue(_faqBL != null, "Unable to get");
        }

       
             
    }
}
