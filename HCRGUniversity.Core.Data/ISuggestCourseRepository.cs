using Core.Base.Data;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;

namespace HCRGUniversity.Core.Data
{
    public interface ISuggestCourseRepository : IBaseRepository<SuggestCourse>
    {
        IEnumerable<SuggestCourse> GetSuggestCourseAll(int skip, int take);
        IEnumerable<HCRGUniversity.Core.BL.Model.SuggestCourse> GetAllSuggestCoursesByOrganizationID(int clientID,int orgID);
    }
}
