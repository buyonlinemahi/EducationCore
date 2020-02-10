using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;
namespace HCRGUniversity.Core.BL
{
   public interface IFAQ
    {
       //FAQ method
        int AddFAQ(FAQ faq);
        int UpdateFAQ(FAQ faq);
        void DeleteFAQ(int faqID);
        FAQ GetFAQByID(int faqID);
        IEnumerable<FAQDetail> getAllFAQ(int organizationID);
        IEnumerable<FAQDetail> GetFAQByCatID(int faqCatID);
        IEnumerable<BLModel.FAQ> GetAllFAQAccordingToOrganizationID(int OrganizationID, int ClientID); 
       //FAQCategory 

        int AddFAQCategory(FAQCategory faqCategory);
        int UpdateFAQCategory(FAQCategory faqCategory);
        void DeleteFAQCategory(int faqCatID);
        FAQCategory GetFAQCategoryByID(int faqCatID);
        IEnumerable<BLModel.FAQCategory> GetAllFAQCategoriesAccordingToOrganizationID(int OrganizationID, int ClientID);
       
    }
}
