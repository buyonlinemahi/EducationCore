using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using System.Linq;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL.Implementation
{
    public class ExamInternalImpl : IExamInternal
    {
        private readonly IPreTestResultRepository _preTestResultRepository;
        private readonly IPreTestQuestionResultRepository _preTestQuestionResultRepository;
        private readonly IExamResultRepository _examResultRepository;
        private readonly IExamQuestionResultRepository _examQuestionResultRepository;
        private readonly IEvaluationResultRepository _evaluationResultRepository;
        private readonly IEvaluationQuestionResultRepository _evaluationQuestionResultRepository;
        private readonly IEvaluationAnswerRepository _evaluationAnswerRepository;

        public ExamInternalImpl(IPreTestResultRepository preTestResultRepository, IPreTestQuestionResultRepository preTestQuestionResultRepository,
        IExamResultRepository examResultRepository, IExamQuestionResultRepository examQuestionResultRepository, IEvaluationResultRepository evaluationResultRepository, IEvaluationQuestionResultRepository evaluationQuestionResultRepository,
            IEvaluationAnswerRepository evaluationAnswerRepository)
        {
            _preTestResultRepository = preTestResultRepository;
            _preTestQuestionResultRepository = preTestQuestionResultRepository;
            _examResultRepository = examResultRepository;
            _examQuestionResultRepository = examQuestionResultRepository;
            _evaluationResultRepository = evaluationResultRepository;
            _evaluationQuestionResultRepository = evaluationQuestionResultRepository;
            _evaluationAnswerRepository = evaluationAnswerRepository;
        }

        //pre-test..hp
        public int AddPreTestResult(PreTestResult preTestResult)
        {
            return _preTestResultRepository.Add(preTestResult).PreTestResultID;

        }

        public int UpdatePreTestResult(PreTestResult preTestResult)
        {
            return _preTestResultRepository.Update(preTestResult);
        }

        public void UpdatePreTestResultIsPass(int preTestResultID, bool isPass)
        {
            PreTestResult preTestResult=new PreTestResult{
                PreTestResultID=preTestResultID,
                IsPass=isPass
            };
            _preTestResultRepository.Update(preTestResult, hp => hp.IsPass);
        }

        public int GetPreTestAttemptByUser(int userID, int MEID)
        {
            return _preTestResultRepository.GetAll(hp => (hp.MEID == MEID) && (hp.UID == userID)).Count();
        }

        public int AddPreTestQuestionResults(PreTestQuestionResult preTestQuestionResult)
        {
            return _preTestQuestionResultRepository.Add(preTestQuestionResult).PreTestQuestionResultID;
        }
        public int UpdatePreTestQuestionResult(PreTestQuestionResult preTestQuestionResult)
        {
            return _preTestQuestionResultRepository.Update(preTestQuestionResult);
        }

        //exam Results...hp
        public int AddExamResult(ExamResult examResult)
        {
            return _examResultRepository.Add(examResult).ExamResultID;
        }
        public int UpdateExamResult(ExamResult examResult)
        {
            return _examResultRepository.Update(examResult);
        }
        public void UpdateExamResultIsPass(int examResultID, int MEID, bool isPass)
        {
            ExamResult examResult = new ExamResult()
            {
                ExamResultID = examResultID,
                IsPass = isPass
            };
            _examResultRepository.Update(examResult, hp => hp.IsPass);

            Engine.CourseCompleteProcessEngine _engine = new Engine.CourseCompleteProcessEngine();
            _engine.RunEngineAfterExamCompleted(MEID, isPass);
        }

        public IEnumerable<ExamResult> GetExamAttempResulttByUser(int userID, int MEID)
        {
            IEnumerable<ExamResult> _examResults = _examResultRepository.GetAll(hp => (hp.MEID == MEID) && (hp.UID == userID)).ToList();
            return _examResults;
        }

        public int AddExamQuestionResults(ExamQuestionResult examQuestionResult)
        {
            return _examQuestionResultRepository.Add(examQuestionResult).ExamQuestionResultID;
        }
        public int UpdateExamQuestionResult(ExamQuestionResult examQuestionResult)
        {
            return _examQuestionResultRepository.Update(examQuestionResult);
        }

        //Evaluation Result
        public int AddEvaluationResult(EvaluationResult evaluationResult)
        {
            var EvalID = _evaluationResultRepository.Add(evaluationResult).EvaluationResultID;
            Engine.CourseCompleteProcessEngine _engine = new Engine.CourseCompleteProcessEngine();
            _engine.RunEngineAfterEvalCompleted(evaluationResult.MEID);
            return EvalID;
        }

        public int UpdateEvaluationResult(EvaluationResult evaluationResult)
        {
            return _evaluationResultRepository.Update(evaluationResult);
        }
        public void UpdateEvaluationResultIsPass(int evaluationResultID, bool isPass)
        {
            EvaluationResult evaluationResult = new EvaluationResult()
            {
                EvaluationResultID = evaluationResultID,
                IsPass = isPass
            };
            _evaluationResultRepository.Update(evaluationResult, hp => hp.IsPass);
        }

        public int GetEvaluationAttemptByUser(int userID)
        {
            return _evaluationResultRepository.GetAll(hp => hp.UID == userID).Count();
        }

        public EvaluationResult GetEvaluationAttemptByUserAndMEID(int userID, int MEID)
        {
            return _evaluationResultRepository.GetAll(tg => (tg.UID == userID ) && (tg.MEID == MEID)).FirstOrDefault();
        }

        public int AddEvaluationQuestionResults(EvaluationQuestionResult evaluationQuestionResult)
        {
            return _evaluationQuestionResultRepository.Add(evaluationQuestionResult).EvaluationQuestionResultID;
        }
        public int UpdateEvaluationQuestionResult(EvaluationQuestionResult evaluationQuestionResult)
        {
            return _evaluationQuestionResultRepository.Update(evaluationQuestionResult);
        }

        public IEnumerable<DLModel.EvaluationAnswer> GetAllEvaluationAnswer()
        {
            IEnumerable<DLModel.EvaluationAnswer> _evaluationAnwser = _evaluationAnswerRepository.GetAll().ToList();
            return _evaluationAnwser;
        }
    }
}