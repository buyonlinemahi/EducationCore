using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.Model;
using Omu.ValueInjecter;
using System.Collections.Generic;
using System.Linq;
using BLModel = HCRGUniversity.Core.BL.Model;

namespace HCRGUniversity.Core.BL.Implementation
{
    public class SuggestCourseImpl : ISuggestCourse
    {
        private readonly ISuggestCourseRepository _suggestCourseRepository;

        public SuggestCourseImpl(ISuggestCourseRepository suggestCourseRepository)
        {
            _suggestCourseRepository = suggestCourseRepository;
        }

        public int addSuggestCourse(SuggestCourse suggestCourse)
        {
            suggestCourse.SCCreatedDate = System.DateTime.Now;
            return _suggestCourseRepository.Add(suggestCourse).SuggestCourseID;
        }

        public int updateSuggestCourse(SuggestCourse suggestCourse)
        {
            return _suggestCourseRepository.Update(suggestCourse);
        }
        public SuggestCourse getSuggestCourseByID(int id)
        {
            return (_suggestCourseRepository.GetById(id));
        }

        public void deleteSuggestCourse(int id)
        {
            _suggestCourseRepository.Delete(getSuggestCourseByID(id));
        }

        public IEnumerable<BLModel.SuggestCourse> GetAllSuggestCoursesByOrganizationID(int clientID, int orgID)
        {
            return _suggestCourseRepository.GetAllSuggestCoursesByOrganizationID(clientID,orgID);
        }

        public BLModel.Paged.SuggestCourses GetAllSuggestCourses(int skip, int take)
        {
            return new BLModel.Paged.SuggestCourses
            {
                SuggestCourseDetails = _suggestCourseRepository.GetSuggestCourseAll(skip, take).Select(SuggestCourseSearchResult => new SuggestCourse().InjectFrom(SuggestCourseSearchResult)).Cast<SuggestCourse>().ToList(),
                TotalCount = _suggestCourseRepository.GetAll().Count()
            };
        }

    }
}
