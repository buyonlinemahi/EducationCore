using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;

namespace HCRGUniversity.Core.Data
{
    public interface IMyEducationModuleRepository : IBaseRepository<MyEducationModule>
    {
        void AddEducationModuleToMyEducationByEducationID(int meid, int educationID);
        IEnumerable<MyEducationModuleDetail> GetMyEducationModulesDetailsByMEID(int meID, int userID);
        MyEducationModuleDetail GetMyEducationModulesDetailByMEMID(int memID);
        void UpdateMyEducationModuleTimeLeft(int memID, string TimeLeft);
    }
}