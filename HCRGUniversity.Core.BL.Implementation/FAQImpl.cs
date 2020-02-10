using HCRGUniversity.Core.Data;
using Omu.ValueInjecter;
using System.Collections.Generic;
using System.Linq;
using BLModel = HCRGUniversity.Core.BL.Model;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL.Implementation
{
   public  class FAQImpl : IFAQ
    {
       private readonly IFAQRepository _faqRepository;
       private readonly IFAQCategoryRepository _faqCategoryRepository;

       public FAQImpl(IFAQRepository faqRepository, IFAQCategoryRepository faqCategoryRepository)
        {
            _faqRepository = faqRepository;
            _faqCategoryRepository = faqCategoryRepository;
        }

       public int AddFAQCategory(DLModel.FAQCategory faqCategory)
       {
           return _faqCategoryRepository.Add((DLModel.FAQCategory)new DLModel.FAQCategory().InjectFrom(faqCategory)).FAQCatID;

       }

       public int UpdateFAQCategory(DLModel.FAQCategory faqCategory)
       {
           return _faqCategoryRepository.Update((DLModel.FAQCategory)new DLModel.FAQCategory().InjectFrom(faqCategory));
       }

       public void DeleteFAQCategory(int faqCatID)
       {
           _faqCategoryRepository.Delete(_faqCategoryRepository.GetById(faqCatID));
       }

       public DLModel.FAQCategory GetFAQCategoryByID(int faqCatID)
       {
           return (DLModel.FAQCategory)new DLModel.FAQCategory().InjectFrom(_faqCategoryRepository.GetById(faqCatID));
       }

       public IEnumerable<BLModel.FAQCategory> GetAllFAQCategoriesAccordingToOrganizationID(int OrganizationID, int ClientID)
       {
           return _faqCategoryRepository.GetAllFAQCategoriesAccordingToOrganizationID(OrganizationID, ClientID);
       }


       //FAQ method

       public int AddFAQ(DLModel.FAQ faq)
       {
           return _faqRepository.Add((DLModel.FAQ)new DLModel.FAQ().InjectFrom(faq)).FAQID;

       }

       public int UpdateFAQ(DLModel.FAQ faq)
       {
           return _faqRepository.Update((DLModel.FAQ)new DLModel.FAQ().InjectFrom(faq));
       }

       public void DeleteFAQ(int faqCatID)
       {
           _faqRepository.Delete(_faqRepository.GetById(faqCatID));
       }

       public DLModel.FAQ GetFAQByID(int faqID)
       {
           return (DLModel.FAQ)new DLModel.FAQ().InjectFrom(_faqRepository.GetById(faqID));
       }

       public IEnumerable<DLModel.FAQDetail> getAllFAQ(int organizationID)
       {
           IEnumerable<DLModel.FAQDetail> _FAQ = _faqRepository.GetFAQAll(organizationID).ToList();
           return _FAQ;
       }

       public IEnumerable<DLModel.FAQDetail> GetFAQByCatID(int faqCatID)
       {
           IEnumerable<DLModel.FAQDetail> _FAQ = _faqRepository.GetFAQByFaqCatID(faqCatID).ToList();
           return _FAQ;
       }

       //*******************Lazy binding
       public IEnumerable<BLModel.FAQ> GetAllFAQAccordingToOrganizationID(int OrganizationID, int ClientID)
       {
           return _faqRepository.GetAllFAQAccordingToOrganizationID(OrganizationID, ClientID);
       }
      
    }
}
