using System.Collections.Generic;
using HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL
{
  public interface IEducationModuleFile
    {
        int AddEducationModuleFile(EducationModuleFile educationModuleFile);
        int UpdateEducationModuleFile(EducationModuleFile educationModuleFile);
        void DeleteEducationModuleFile(int educationModuleFileID);
        EducationModuleFile GetEducationModuleFileByID(int educationModuleFileID);
        EducationModuleFile GetEducationModuleFileByModuleID(int educationModuleID); 
        IEnumerable<EducationModuleFile> GetAllEducationModuleFile();
        void DeleteEducationModuleFileByEducationModuleFileID(int EducationModuleFileID, int FileTypeID);
        IEnumerable<EducationModuleFile> GetMyEducationModulesDetailsByMEID_FileTypeID(int emID, int FileTypeID);
    }
}
