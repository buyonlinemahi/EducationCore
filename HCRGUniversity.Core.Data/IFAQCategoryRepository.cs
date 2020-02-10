using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.Data
{
    public interface IFAQCategoryRepository : IBaseRepository<FAQCategory>
    {
        IEnumerable<BLModel.FAQCategory> GetAllFAQCategoriesAccordingToOrganizationID(int OrganizationID, int ClientID);
    }
}
