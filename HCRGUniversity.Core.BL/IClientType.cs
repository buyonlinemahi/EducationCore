using DLModel = HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;

namespace HCRGUniversity.Core.BL
{
    public interface IClientType
    {
        IEnumerable<DLModel.ClientType> getAllClientType();
    }
}
