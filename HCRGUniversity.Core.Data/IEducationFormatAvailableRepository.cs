using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;

namespace HCRGUniversity.Core.Data
{
    public interface IEducationFormatAvailableRepository : IBaseRepository<EducationFormatAvailable>
    {
        IEnumerable<EducationFormatDetail> GetEducationFormatsByEducationID(int educationID);
    }
}