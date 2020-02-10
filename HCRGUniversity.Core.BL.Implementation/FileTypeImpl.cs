using HCRGUniversity.Core.Data;
using Omu.ValueInjecter;
using System.Collections.Generic;
using System.Linq;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL.Implementation
{
    public class FileTypeImpl : IFileType
    {
        private readonly IFileTypeRepository _fileTypeRepository;
        public FileTypeImpl(IFileTypeRepository fileTypeRepository)
        {
            _fileTypeRepository = fileTypeRepository;

        }

        public IEnumerable<DLModel.FileType> GetAllFileType()
        {
            IEnumerable<DLModel.FileType> _fileType = _fileTypeRepository.GetAll().Select(fileType => new DLModel.FileType().InjectFrom(fileType)).Cast<DLModel.FileType>().OrderBy(fileType => fileType.FileTypeID).ToList();
            return _fileType;
        }

    }
}
