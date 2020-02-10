using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;

namespace HCRGUniversity.Core.Data
{
    public interface ITermsConditionRepository :IBaseRepository<TermsCondition>
    {
        IEnumerable<TermsCondition> GetAllTermAndConditionsAccordingToClientID(int ClientID);
    }
}
