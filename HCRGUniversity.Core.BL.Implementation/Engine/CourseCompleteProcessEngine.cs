using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.Model;
using HCRGUniversity.Core.Data.SqlServer.Repository;
using System.Linq;
using BaseCoreSql = Core.Base.Data;

namespace HCRGUniversity.Core.BL.Implementation.Engine
{
    public class CourseCompleteProcessEngine
    {
        public readonly IMyEducationModuleRepository _myEducationModuleRepository;
        private readonly IEducationExamQuestionRepository _educationExamQuestionRepository;
        private readonly IEducationEvaluationRepository _educationEvaluationRepository;
        private readonly IMyEducationRepository _myEducationRepository;
        private readonly IExamResultRepository _examResultRepository;

        public CourseCompleteProcessEngine()
        {
            _myEducationModuleRepository = new MyEducationModuleRepository(new BaseCoreSql.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _educationExamQuestionRepository = new EducationExamQuestionRepository(new BaseCoreSql.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _myEducationRepository = new MyEducationRepository(new BaseCoreSql.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _educationEvaluationRepository = new EducationEvaluationRepository(new BaseCoreSql.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _examResultRepository = new ExamResultRepository(new BaseCoreSql.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
        }

        public void RunEngineAfterModuleCompleted(int _meID)
        {
            int _educationID = _myEducationRepository.GetAll(hp => hp.MEID == _meID).FirstOrDefault().EducationID;
            if (_myEducationModuleRepository.GetAll(hp => (hp.Completed == false) && (hp.MEID == _meID)).Count() == 0)
            {
                if ((_educationExamQuestionRepository.GetDbSet().Where(hp => (hp.EducationID == _educationID) && (hp.IsActive == true)).Count() == 0) && (_educationEvaluationRepository.GetDbSet().Where(hp => (hp.EducationID == _educationID) && (hp.IsActive == true)).Count() == 0))
                {
                    UpdateMyEducation(_meID, true);
                }
            }
        }

        public void RunEngineAfterExamCompleted(int _meID, bool isExamPassed)
        {
            int _educationID = _myEducationRepository.GetAll(hp => hp.MEID == _meID).FirstOrDefault().EducationID;
            if ((isExamPassed) && (_educationEvaluationRepository.GetDbSet().Where(hp => hp.EducationID == _educationID && hp.IsActive == true).Count() == 0))
            {
                UpdateMyEducation(_meID, isExamPassed);
            }
            else if ((!isExamPassed) && (_examResultRepository.GetAll(hp => hp.MEID == _meID).Count() == 3))
            {
                UpdateMyEducation(_meID, isExamPassed);
            }
        }

        public void RunEngineAfterEvalCompleted(int _meID)
        {
            UpdateMyEducation(_meID, true);
        }

        private void UpdateMyEducation(int meID, bool isExamPassed)
        {
            MyEducation _myeducation = new MyEducation
            {
                MEID = meID,
                Completed = true,
                CompletedDate = System.DateTime.Now,
                IsPassed = isExamPassed
            };
            _myEducationRepository.Update(_myeducation, hp => hp.CompletedDate, hp => hp.Completed, hp => hp.IsPassed);
        }
    }
}