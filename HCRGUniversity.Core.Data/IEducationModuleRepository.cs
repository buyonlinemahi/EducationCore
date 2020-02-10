using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System;
using System.Collections.Generic;

namespace HCRGUniversity.Core.Data
{
    public interface IEducationModuleRepository : IBaseRepository<EducationModule>
    {
        int AddEducationModule(EducationModule educationModule);
        int UpdateEducationModule(EducationModule educationModule);
        int UpdateEducationModuleTime(EducationModule educationModule);
        void DeleteEducationModule(int educationModuleID);
        IEnumerable<EducationModule> GetAllPagedEducationModuleByEid(int educationid, int skip, int take);
        int GetEducationModuleCountByeid(System.Linq.Expressions.Expression<Func<EducationModule, bool>> where);
        Client GetOrganizationClientByEducationModuleID(int educationModuleID);
    }
}
