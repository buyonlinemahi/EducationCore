using System.Collections.Generic;
using HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL
{
    public interface IEducationFormatAvailable
    {
        int AddEducationFormatAvailable(EducationFormatAvailable educationFormatAvailable);
        int UpdateEducationFormatAvailable(EducationFormatAvailable educationFormatAvailable);
        IEnumerable<EducationFormatDetail> GetEducationFormatsByEducationID(int educationID);
    }
}