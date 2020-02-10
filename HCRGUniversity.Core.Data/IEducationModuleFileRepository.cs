using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;

namespace HCRGUniversity.Core.Data
{
    public interface IEducationModuleFileRepository : IBaseRepository<EducationModuleFile>
    {
        void DeleteEducationModuleFile(int EducationModuleFileID, int FileTypeID);
    }
}
