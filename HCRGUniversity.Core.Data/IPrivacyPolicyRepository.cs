using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.Data
{
    public interface IPrivacyPolicyRepository : IBaseRepository<PrivacyPolicy>
    {
        IEnumerable<BLModel.PrivacyPolicy> GetAllPrivacyPolicyAccordingToOrganizationID(int Organization, int ClientID);
    }
}

