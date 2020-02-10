using HCRGUniversity.Core.Data.Model;
using System.Collections.Generic;
using BLModel = HCRGUniversity.Core.BL.Model;
namespace HCRGUniversity.Core.BL
{
  public interface IExamQuestion
    {
      int AddExamQuestion(ExamQuestion examQuestion);
      int UpdateExamQuestion(ExamQuestion examQuestion);
      void DeleteExamQuestion(int examQuestionID);
      ExamQuestion GetExamQuestionByID(int examQuestionID);
      BLModel.Paged.ExamQuestion GetAllPagedExamQuestionByExamID(int examID,int skip, int take);
      IEnumerable<ExamQuestionDetail> GetAllExamQuestionDetailByEID(int educationID);
      IEnumerable<ExamQuestion> GetExamQuestionWrongAnswered(int _meID);

      //Pre Test Question
      int AddPreTestQuestion(PreTestQuestion preTestQuestion);
      int UpdatePreTestQuestion(PreTestQuestion preTestQuestion);
      void DeletePreTestQuestion(int preTestQuestionID);
      PreTestQuestion GetPreTestQuestionByID(int preTestQuestionID);
      BLModel.Paged.PreTestQuestion GetAllPagedPreTestQuestionByPreTestID(int preTestID,int skip, int take);
      IEnumerable<PreTestQuestionDetail> GetAllPreTestQuestionDetailByEID(int educationID);


      //EducationExamQuestions
      int AddEducationExamQuestion(EducationExamQuestion educationExamQuestion);
      void UpdateEducationExamQuestion(EducationExamQuestion educationExamQuestion);
      void DeleteEducationExamQuestion(int courseExamQuestionID);
      EducationExamQuestion GetEducationExamQuestionByEducationID(int educationID);

      //EducationPreTestQuestion
      int AddEducationPreTestQuestion(EducationPreTestQuestion educationPreTestQuestions);
      void UpdateEducationPreTestQuestion(EducationPreTestQuestion educationPreTestQuestions);
      void DeleteEducationPreTestQuestion(int coursePreTestQuestionID);
      EducationPreTestQuestion GetEducationPreTestQuestionByEducationID(int educationID);

      //Exam...................
      int AddExam(Exam exam);
      int UpdateExam(Exam exam);
      void DeleteExam(int examID);
      Exam GetExamByID(int examID);
      IEnumerable<Exam> GetAllActiveExam(int clientID);
      BLModel.Paged.Exam GetAllPagedExam(string name, int skip, int take, int clientID,int orgID);

      //Pre Test Question
      int AddPreTest(PreTest preTest);
      int UpdatePreTest(PreTest preTest);
      void DeletePreTest(int preTestID);
      PreTest GetPreTestByID(int preTestID);
      BLModel.Paged.PreTest GetAllPagedPreTest(string name, int skip, int take, int clientID,int orgID);
      IEnumerable<PreTest> GetAllActivePreTest(int clientID);
      //EvaluationQuestion
      int AddEvaluationQuestion(EvaluationQuestion evaluationQuestion);
      int UpdateEvaluationQuestion(EvaluationQuestion evaluationQuestion);
      void DeleteEvaluationQuestion(int evaluationQuestionID);
      EvaluationQuestion GetEvaluationQuestionByID(int evaluationQuestionID);
      BLModel.Paged.EvaluationQuestion GetAllPagedEvaluationQuestionByEvaluationID(int evaluationID, int skip, int take);
      IEnumerable<EvaluationQuestionDetail> GetAllEvaluationQuestionDetailByEID(int educationID);
      int AddEvaluationQuestionsFromEvaluationPredefinedQuestions(int EvaluationID);
      int UpdateEvaluationQuestionStatus(EvaluationQuestion evaluationQuestion);

      //Evaluation...................
      int AddEvaluation(Evaluation evaluation);
      int UpdateEvaluation(Evaluation evaluation);
      int UpdateEvaluationStatus(Evaluation evaluation);
      void DeleteEvaluation(int evaluationID);
      Evaluation GetEvaluationByID(int evaluationID);
      BLModel.Paged.Evaluation GetAllPagedEvaluation(string name, int skip, int take, int clientID,int orgID);
      IEnumerable<Evaluation> GetAllActiveEvaluation(int clientID);

      //EducationEvaluation
      int AddEducationEvaluation(EducationEvaluation educationEvaluation);
      void UpdateEducationEvaluation(EducationEvaluation educationEvaluation);
      void DeleteEducationEvaluation(int courseEvaluationID);
      EducationEvaluation GetEducationEvaluationByEducationID(int educationID);

     

    }
}
