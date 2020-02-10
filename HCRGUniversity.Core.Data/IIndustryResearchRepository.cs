using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.Data
{
    public interface IIndustryResearchRepository : IBaseRepository<IndustryResearch>
    {
        IEnumerable<BLModel.IndustryResearch> GetAllIndustryResearchesByOrganizationID(int OrganizationID, int ClientID);
    }
}
