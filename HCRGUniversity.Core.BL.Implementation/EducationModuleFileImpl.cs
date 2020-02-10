using HCRGUniversity.Core.Data;
using Omu.ValueInjecter;
using System.Collections.Generic;
using System.Linq;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL.Implementation
{
    public class EducationModuleFileImpl : IEducationModuleFile
    {
        private readonly IEducationModuleFileRepository _educationModuleFileRepository;

        public EducationModuleFileImpl(IEducationModuleFileRepository educationModuleFileRepository)
        {
            _educationModuleFileRepository = educationModuleFileRepository;

        }
        public int AddEducationModuleFile(DLModel.EducationModuleFile educationModuleFile)
        {
            return _educationModuleFileRepository.Add((DLModel.EducationModuleFile)new DLModel.EducationModuleFile().InjectFrom(educationModuleFile)).EducationModuleFileID;

        }

        public int UpdateEducationModuleFile(DLModel.EducationModuleFile educationModuleFile)
        {
            return _educationModuleFileRepository.Update((DLModel.EducationModuleFile)new DLModel.EducationModuleFile().InjectFrom(educationModuleFile));
        }

        public void DeleteEducationModuleFile(int educationModuleFileID)
        {
            _educationModuleFileRepository.Delete(_educationModuleFileRepository.GetById(educationModuleFileID));
        }

        public void DeleteEducationModuleFileByEducationModuleFileID(int EducationModuleFileID, int FileTypeID)
        {
            _educationModuleFileRepository.DeleteEducationModuleFile(EducationModuleFileID, FileTypeID);
        }

        public DLModel.EducationModuleFile GetEducationModuleFileByID(int educationModuleFileID)
        {
            return (DLModel.EducationModuleFile)new DLModel.EducationModuleFile().InjectFrom(_educationModuleFileRepository.GetById(educationModuleFileID));
        }

        public DLModel.EducationModuleFile GetEducationModuleFileByModuleID(int educationModuleID)
        {
            return (DLModel.EducationModuleFile)new DLModel.EducationModuleFile().InjectFrom(_educationModuleFileRepository.GetAll(educationModuleFile => educationModuleFile.EducationModuleID == educationModuleID).FirstOrDefault());
         
        }

        public IEnumerable<DLModel.EducationModuleFile> GetAllEducationModuleFile()
        {
            IEnumerable<DLModel.EducationModuleFile> _educationModuleFile = _educationModuleFileRepository.GetAll().Select(educationModuleFile => new DLModel.EducationModuleFile().InjectFrom(educationModuleFile)).Cast<DLModel.EducationModuleFile>().OrderBy(educationModuleFile => educationModuleFile.EducationModuleFileID).ToList();
            return _educationModuleFile;
        }

        public IEnumerable<DLModel.EducationModuleFile> GetMyEducationModulesDetailsByMEID_FileTypeID(int emID, int FileTypeID)
        {
            return _educationModuleFileRepository.GetAll(me => me.EducationModuleID == emID && me.FileTypeID == FileTypeID).ToList();
        }

    }
}
