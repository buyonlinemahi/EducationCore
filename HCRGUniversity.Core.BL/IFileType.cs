using System.Collections.Generic;
using HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL
{
   public interface IFileType
    {
       IEnumerable<FileType> GetAllFileType();
    }
}
