using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;

namespace HCRGUniversity.Core.Data
{
    public interface ICertificationTitleOptionRepository : IBaseRepository<CertificationTitleOption>
    {
        IEnumerable<CourseNameDropDownList> GetCourseNameDropDownList(int organizationID);
    }
}
