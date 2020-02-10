using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;

namespace HCRGUniversity.Core.Data
{
    public interface IReturnPolicyRepository : IBaseRepository<ReturnPolicy>
    {
        IEnumerable<ReturnPolicy> GetAllReturnPolicysAccordingToClientID(int ClientID);
    }
}
