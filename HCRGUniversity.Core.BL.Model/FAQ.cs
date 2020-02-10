using System;

namespace HCRGUniversity.Core.BL.Model
{
   public class FAQ :Base.BaseOrganizationColumn
    {
        public int FAQID { get; set; }
        public int FAQCatID { get; set; }
        public string FAQues { get; set; }
        public string FAQAns { get; set; }
        public string OrganizationName { get; set; }
        public string FaqCategoryName { get; set; }
    }
}
