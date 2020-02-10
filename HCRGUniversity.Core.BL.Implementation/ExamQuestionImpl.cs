using HCRGUniversity.Core.Data;
using System.Collections.Generic;
using System.Linq;
using BLModel = HCRGUniversity.Core.BL.Model;
using DLModel = HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.BL.Implementation
{
  public class ExamQuestionImpl:IExamQuestion
    {
      private readonly IExamQuestionRepository _examQuestionRepository;
      private readonly IPreTestQuestionRepository _preTestQuestionRepository;
      private readonly IEducationExamQuestionRepository _educationExamQuestion;
      private readonly IEducationPreTestQuestionRepository _educationPreTestQuestion;
      private readonly IExamRepository _examRepository;
      private readonly IPreTestRepository _preTestRepository;
      private readonly IEvaluationRepository _evaluationRepository;
      private readonly IEvaluationQuestionRepository _evaluationQuestionRepository;
      private readonly IEducationEvaluationRepository _educationEvaluationRepository;
       

      public ExamQuestionImpl(IExamQuestionRepository examQuestionRepository, IPreTestQuestionRepository preTestQuestionRepository, IEducationExamQuestionRepository educationExamQuestion, IEducationPreTestQuestionRepository educationPreTestQuestion, IExamRepository examRepository, IPreTestRepository preTestRepository, IEvaluationRepository evaluationRepository, IEvaluationQuestionRepository evaluationQuestionRepository, IEducationEvaluationRepository educationEvaluationRepository)
        {
            _examQuestionRepository = examQuestionRepository;
            _preTestQuestionRepository = preTestQuestionRepository;
            _educationExamQuestion = educationExamQuestion;
            _educationPreTestQuestion = educationPreTestQuestion;
            _examRepository = examRepository;
            _preTestRepository = preTestRepository;
            _evaluationRepository = evaluationRepository;
            _evaluationQuestionRepository = evaluationQuestionRepository;
            _educationEvaluationRepository = educationEvaluationRepository;
        }

      #region Exam
      public int AddExamQuestion(DLModel.ExamQuestion examQuestion)
      {
          return _examQuestionRepository.Add(examQuestion).ExamQuestionID;

      }

      public int UpdateExamQuestion(DLModel.ExamQuestion examQuestion)
      {
          return _examQuestionRepository.Update(examQuestion);
      }

      public void DeleteExamQuestion(int examQuestionID)
      {
          _examQuestionRepository.Delete(_examQuestionRepository.GetById(examQuestionID));
      }

      public DLModel.ExamQuestion GetExamQuestionByID(int examQuestionID)
      {
          return (_examQuestionRepository.GetById(examQuestionID));
      }

      public BLModel.Paged.ExamQuestion GetAllPagedExamQuestionByExamID(int examID, int skip, int take)
      {
          return new BLModel.Paged.ExamQuestion
          {
              TotalCount = _examQuestionRepository.GetExamQuestionCountByExamID(examQues => examQues.ExamID.Equals(examID)),
              ExamQuestions = _examQuestionRepository.GetAllPagedPreTestQuestionByExamID(examQues => examQues.ExamID.Equals(examID), skip, take).ToList()
          };
      }

      public IEnumerable<DLModel.ExamQuestionDetail> GetAllExamQuestionDetailByEID(int educationID)
      {
          IEnumerable<DLModel.ExamQuestionDetail> _examQuestionDetail = _examQuestionRepository.GetAllExamQuestionDetailByEID(educationID).ToList();
          return _examQuestionDetail;
      }

      public IEnumerable<DLModel.ExamQuestion> GetExamQuestionWrongAnswered(int _meID)
      {
          return _examQuestionRepository.GetExamQuestionWrongAnswered(_meID);
      }

      public int AddEducationExamQuestion(DLModel.EducationExamQuestion educationExamQuestion)
      {
          return _educationExamQuestion.Add(educationExamQuestion).CourseExamID;
      }

      public void UpdateEducationExamQuestion(DLModel.EducationExamQuestion educationExamQuestion)
      {
          _educationExamQuestion.UpdateEducationExamQuestion(educationExamQuestion);
      }

      public void DeleteEducationExamQuestion(int courseExamQuestionID)
      {
          _educationExamQuestion.Delete(_educationExamQuestion.GetById(courseExamQuestionID));
      }

      public DLModel.EducationExamQuestion GetEducationExamQuestionByEducationID(int educationID)
      {
          return _educationExamQuestion.GetAll(educationExamQuestion => educationExamQuestion.EducationID.Equals(educationID) && educationExamQuestion.IsActive == true).ToList().FirstOrDefault();
      }

      public int AddExam(DLModel.Exam exam)
      {
          return _examRepository.Add(exam).ExamID;

      }

      public int UpdateExam(DLModel.Exam exam)
      {
          return _examRepository.Update(exam);
      }

      public void DeleteExam(int examID)
      {
          _examRepository.Delete(_examRepository.GetById(examID));
      }

      public DLModel.Exam GetExamByID(int examID)
      {
          return (_examRepository.GetById(examID));
      }

      public BLModel.Paged.Exam GetAllPagedExam(string name, int skip, int take, int clientID,int orgID)
      {
          return new BLModel.Paged.Exam
          {
              TotalCount = _examRepository.GetExamDetailsByClientIDCount(name, clientID,orgID),
              Exams = _examRepository.GetExamDetailsByClientID(name, clientID,orgID, skip, take).ToList()
          };
      }

      public IEnumerable<DLModel.Exam> GetAllActiveExam(int clientID)
      {
          return _examRepository.GetAllActiveExamByClientID(clientID);
          //return _examRepository.GetAll(exam => (exam.ExamStatus != false)).ToList();
      }
      #endregion

      // Pre test Question

      #region PreTest
      public int AddPreTestQuestion(DLModel.PreTestQuestion preTestQuestion)
      {
          return _preTestQuestionRepository.Add(preTestQuestion).PreTestQuestionID;
      }

      public int UpdatePreTestQuestion(DLModel.PreTestQuestion preTestQuestion)
      {
          return _preTestQuestionRepository.Update(preTestQuestion);
      }

      public void DeletePreTestQuestion(int preTestQuestionID)
      {
          _preTestQuestionRepository.Delete(_preTestQuestionRepository.GetById(preTestQuestionID));
      }

      public DLModel.PreTestQuestion GetPreTestQuestionByID(int preTestQuestionID)
      {
          return (_preTestQuestionRepository.GetById(preTestQuestionID));
      }

      public BLModel.Paged.PreTestQuestion GetAllPagedPreTestQuestionByPreTestID(int pretestid, int skip, int take)
      {
          return new BLModel.Paged.PreTestQuestion
          {
              TotalCount = _preTestQuestionRepository.GetPreTestQuestionCountByPreTestID(preTestQues => preTestQues.PreTestID.Equals(pretestid)),
              PreTestQuestions = _preTestQuestionRepository.GetAllPagedPreTestQuestionByPreTestID(preTestQues => preTestQues.PreTestID.Equals(pretestid), skip, take).ToList()
          };
      }

      public IEnumerable<DLModel.PreTestQuestionDetail> GetAllPreTestQuestionDetailByEID(int educationID)
      {
          IEnumerable<DLModel.PreTestQuestionDetail> _preTestQuestionDetail = _preTestQuestionRepository.GetAllPreTestQuestionDetailByEID(educationID).ToList();
          return _preTestQuestionDetail;
      }

      public int AddEducationPreTestQuestion(DLModel.EducationPreTestQuestion educationPreTestQuestion)
      {
          return _educationPreTestQuestion.Add(educationPreTestQuestion).CoursePreTestID;
      }

      public void UpdateEducationPreTestQuestion(DLModel.EducationPreTestQuestion educationPreTestQuestion)
      {
          _educationPreTestQuestion.UpdateEducationPreTestQuestion(educationPreTestQuestion);
      }

      public void DeleteEducationPreTestQuestion(int coursePreTestQuestionID)
      {
          _educationPreTestQuestion.Delete(_educationPreTestQuestion.GetById(coursePreTestQuestionID));
      }

      public DLModel.EducationPreTestQuestion GetEducationPreTestQuestionByEducationID(int educationID)
      {
          return _educationPreTestQuestion.GetAll(educationPreTestQuestion => educationPreTestQuestion.EducationID.Equals(educationID) && educationPreTestQuestion.IsActive == true).ToList().FirstOrDefault();
      }

      public int AddPreTest(DLModel.PreTest preTest)
      {
          return _preTestRepository.Add(preTest).PreTestID;
      }

      public int UpdatePreTest(DLModel.PreTest preTest)
      {
          return _preTestRepository.Update(preTest);
      }

      public void DeletePreTest(int preTestID)
      {
          _preTestRepository.Delete(_preTestRepository.GetById(preTestID));
      }

      public DLModel.PreTest GetPreTestByID(int preTestID)
      {
          return (_preTestRepository.GetById(preTestID));
      }

      public BLModel.Paged.PreTest GetAllPagedPreTest(string name, int skip, int take, int clientID, int orgID)
      {
          return new BLModel.Paged.PreTest
          {
              TotalCount = _preTestRepository.GetPreTestDetailsByClientIDCount(name, clientID,orgID),
              PreTests = _preTestRepository.GetPreTestDetailsByClientID(name, clientID, orgID,skip, take).ToList()
          };
      }

      public IEnumerable<DLModel.PreTest> GetAllActivePreTest(int clientID)
      {
          return _preTestRepository.GetAllActivePreTestByClientID(clientID);
      }
      #endregion
    
      // Pre test Question

      #region Evaluation
      public int AddEvaluation(DLModel.Evaluation evaluation)
      {
          return _evaluationRepository.Add(evaluation).EvaluationID;

      }

      public int UpdateEvaluation(DLModel.Evaluation evaluation)
      {
          return _evaluationRepository.Update(evaluation);
      }

      public int UpdateEvaluationStatus(DLModel.Evaluation evaluation)
      {
          return _evaluationRepository.Update(evaluation, ev => ev.EvaluationStatus);
      }
      public void DeleteEvaluation(int evaluationID)
      {
          _evaluationRepository.Delete(_evaluationRepository.GetById(evaluationID));
      }

      public DLModel.Evaluation GetEvaluationByID(int evaluationID)
      {
          return (_evaluationRepository.GetById(evaluationID));
      }

      public BLModel.Paged.Evaluation GetAllPagedEvaluation(string name, int skip, int take, int clientID,int orgID)
      {
          return new BLModel.Paged.Evaluation
          {
              TotalCount = _evaluationRepository.GetEvaluationDetailsByClientIDCount(name,clientID,orgID),
              Evaluations = _evaluationRepository.GetEvaluationDetailsByClientID(name, clientID,orgID, skip, take).ToList()
          };
      }

      public IEnumerable<DLModel.Evaluation> GetAllActiveEvaluation(int _cientID)
      {
          return _evaluationRepository.GetAllActiveEvaluationByClientID(_cientID);
      }
      //Evalutionques........
      public int AddEvaluationQuestion(DLModel.EvaluationQuestion evaluationQuestion)
      {
          return _evaluationQuestionRepository.Add(evaluationQuestion).EvaluationQuestionID;
      }

      public int UpdateEvaluationQuestion(DLModel.EvaluationQuestion evaluationQuestion)
      {
          return _evaluationQuestionRepository.Update(evaluationQuestion);
      }

      public int UpdateEvaluationQuestionStatus(DLModel.EvaluationQuestion evaluationQuestion)
      {
          return _evaluationQuestionRepository.Update(evaluationQuestion, ev => ev.IsStatus);
      }

      public void DeleteEvaluationQuestion(int evaluationQuestionID)
      {
          _evaluationQuestionRepository.Delete(_evaluationQuestionRepository.GetById(evaluationQuestionID));
      }

      public DLModel.EvaluationQuestion GetEvaluationQuestionByID(int evaluationQuestionID)
      {
          return (_evaluationQuestionRepository.GetById(evaluationQuestionID));
      }

      public BLModel.Paged.EvaluationQuestion GetAllPagedEvaluationQuestionByEvaluationID(int evaluationnID, int skip, int take)
      {
          return new BLModel.Paged.EvaluationQuestion
          {
              TotalCount = _evaluationQuestionRepository.GetEvaluationQuestionCountByEvaluationID(evaluationQuestion => evaluationQuestion.EvaluationID.Equals(evaluationnID)),
              EvaluationQuestions = _evaluationQuestionRepository.GetAllPagedEvaluationQuestionByPreTestID(evaluationQuestion => evaluationQuestion.EvaluationID.Equals(evaluationnID), skip, take).ToList()
          };
      }

      public IEnumerable<DLModel.EvaluationQuestionDetail> GetAllEvaluationQuestionDetailByEID(int educationID)
      {
          IEnumerable<DLModel.EvaluationQuestionDetail> _evaluationQuestionDetail = _evaluationQuestionRepository.GetAllEvaluationQuestionDetailByEID(educationID).ToList();
          return _evaluationQuestionDetail;
      }

      public int AddEvaluationQuestionsFromEvaluationPredefinedQuestions(int EvaluationID)
      {
          return _evaluationQuestionRepository.AddEvaluationQuestionsFromEvaluationPredefinedQuestions(EvaluationID);
      }

      // EducationEvaluation
      public int AddEducationEvaluation(DLModel.EducationEvaluation educationEvaluation)
      {
          return _educationEvaluationRepository.Add(educationEvaluation).CourseEvaluationID;
      }

      public void UpdateEducationEvaluation(DLModel.EducationEvaluation educationEvaluation)
      {
          _educationEvaluationRepository.UpdateEducationEvaluation(educationEvaluation);
      }

      public void DeleteEducationEvaluation(int courseEvaluationID)
      {
          _educationEvaluationRepository.Delete(_educationEvaluationRepository.GetById(courseEvaluationID));
      }

      public DLModel.EducationEvaluation GetEducationEvaluationByEducationID(int educationID)
      {
          return _educationEvaluationRepository.GetAll(educationEvaluation => educationEvaluation.EducationID.Equals(educationID) && educationEvaluation.IsActive == true).ToList().FirstOrDefault();
      } 
      #endregion

    }
}
