using System.Collections.Generic;
using HCRGUniversity.Core.Data.Model;
using BLModel = HCRGUniversity.Core.BL.Model;
namespace HCRGUniversity.Core.BL
{
    public interface IEducationModule
    {
        int AddEducationModule(EducationModule educationModule);
        int UpdateEducationModule(EducationModule educationModule);
        int UpdateEducationModuleTime(EducationModule educationModule);
        void DeleteEducationModule(int educationModuleID);
        EducationModule GetEducationModuleByID(int educationModuleID);
        IEnumerable<EducationModule> GetAllEducationModule();
        IEnumerable<EducationModule> GetAllEducationModuleByEducationID(int educationID);
        BLModel.Paged.EducationModule GetAllPagedEducationModuleByEid(int educationID, int skip, int take);
        Client GetOrganizationClientByEducationModuleID(int educationModuleID);
    }
}
