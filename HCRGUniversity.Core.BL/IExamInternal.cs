using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;

namespace HCRGUniversity.Core.BL
{
    public interface IExamInternal
    {
        //pre-test..hp
        int AddPreTestResult(PreTestResult preTestResult);
        int UpdatePreTestResult(PreTestResult preTestResult);
        void UpdatePreTestResultIsPass(int preTestResultID, bool isPass);
        int GetPreTestAttemptByUser(int userID, int MEID);

        int AddPreTestQuestionResults(PreTestQuestionResult preTestQuestionResult);
        int UpdatePreTestQuestionResult(PreTestQuestionResult preTestQuestionResult);

        //exam Results...hp
        int AddExamResult(ExamResult examResult);
        int UpdateExamResult(ExamResult examResult);
        void UpdateExamResultIsPass(int examResultID,int MEID, bool isPass);
        IEnumerable<ExamResult> GetExamAttempResulttByUser(int userID, int MEID);

        int AddExamQuestionResults(ExamQuestionResult examQuestionResult);
        int UpdateExamQuestionResult(ExamQuestionResult examQuestionResult);

        //Evaluation 
        int AddEvaluationResult(EvaluationResult evaluationResult);
        int UpdateEvaluationResult(EvaluationResult examResult);
        void UpdateEvaluationResultIsPass(int evaluationResultID, bool isPass);
        int GetEvaluationAttemptByUser(int userID);
        EvaluationResult GetEvaluationAttemptByUserAndMEID(int userID, int MEID);
        int AddEvaluationQuestionResults(EvaluationQuestionResult evaluationQuestionResult);
        int UpdateEvaluationQuestionResult(EvaluationQuestionResult evaluationQuestionResult);
        IEnumerable<EvaluationAnswer> GetAllEvaluationAnswer();
    }
}