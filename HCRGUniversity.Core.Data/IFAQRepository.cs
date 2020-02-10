using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.Data
{
    public interface IFAQRepository : IBaseRepository<FAQ>
    {
        IEnumerable<FAQDetail> GetFAQByFaqCatID(int faqCatID);
        IEnumerable<FAQDetail> GetFAQAll(int organizationID);
        IEnumerable<BLModel.FAQ> GetAllFAQAccordingToOrganizationID(int OrganizationID, int ClientID);
        int GetFAQCount(int organizationID);
    }
}
