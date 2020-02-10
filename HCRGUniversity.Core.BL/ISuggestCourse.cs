using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.BL
{
    public interface ISuggestCourse
    {
        int addSuggestCourse(SuggestCourse suggestCourse);
        int updateSuggestCourse(SuggestCourse suggestCourse);
        void deleteSuggestCourse(int id);
        //IEnumerable<SuggestCourse> getSuggestCourseAll();
        SuggestCourse getSuggestCourseByID(int id);
        BLModel.Paged.SuggestCourses GetAllSuggestCourses(int skip, int take);
        IEnumerable<BLModel.SuggestCourse> GetAllSuggestCoursesByOrganizationID(int clientID,int orgID);
    }
}
