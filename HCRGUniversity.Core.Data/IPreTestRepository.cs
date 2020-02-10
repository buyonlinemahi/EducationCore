using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.Data
{
    public interface IPreTestRepository : IBaseRepository<PreTest>
    {
        IEnumerable<BLModel.PreTest> GetPreTestDetailsByClientID(string name, int clientID,int orgID, int skip, int take);
        int GetPreTestDetailsByClientIDCount(string name, int clientID, int orgID);
        IEnumerable<PreTest> GetAllActivePreTestByClientID(int clientID);

    }
}
