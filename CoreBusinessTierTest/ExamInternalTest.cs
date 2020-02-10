using HCRGUniversity.Core.BL;
using HCRGUniversity.Core.BL.Implementation;
using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.Model;
using HCRGUniversity.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace CoreBusinessTierTest
{
    [TestClass]
    public class ExamInternalTest
    {
        private IPreTestResultRepository _preTestResultRepository;
        private IPreTestQuestionResultRepository _preTestQuestionResultRepository;
        
        private IExamResultRepository _examResultRepository;
        private IExamQuestionResultRepository _examQuestionResultRepository;
        
        private IEvaluationResultRepository _evaluationResultRepository;
        private IEvaluationQuestionResultRepository _evaluationQuestionResultRepository;
        private IEvaluationAnswerRepository _evaluationAnswerRepository;

        private IExamInternal _examInternalBL;

        [TestInitialize]
        public void ExamInternalInitialize()
        {
            _preTestResultRepository = new PreTestResultRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _preTestQuestionResultRepository = new PreTestQuestionResultRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _examResultRepository = new ExamResultRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _examQuestionResultRepository = new ExamQuestionResultRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _evaluationResultRepository = new EvaluationResultRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _evaluationQuestionResultRepository = new EvaluationQuestionResultRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _evaluationAnswerRepository = new EvaluationAnswerRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            
            _examInternalBL = new ExamInternalImpl(_preTestResultRepository, _preTestQuestionResultRepository, _examResultRepository,
                   _examQuestionResultRepository, _evaluationResultRepository, _evaluationQuestionResultRepository, _evaluationAnswerRepository);
        }
        //pretest..hp
        [TestMethod]
        public void AddPreTestResults()
        {
            PreTestResult BLModel = new PreTestResult()
            {
                UID = 150,
                IsPass = true
            };
            int result = _examInternalBL.AddPreTestResult(BLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }

        [TestMethod]
        public void UpdatePreTestResults()
        {
            PreTestResult BLModel = new PreTestResult()
            {
                PreTestResultID = 1,
                UID = 150,
                IsPass = false
            };
            int result = _examInternalBL.UpdatePreTestResult(BLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }

        [TestMethod]
        public void UpdatePreTestResultIsPass()
        {
            _examInternalBL.UpdatePreTestResultIsPass(1, true);
        }

        [TestMethod]
        public void AddPreTestQuestionResults()
        {
            PreTestQuestionResult BLModel = new PreTestQuestionResult()
            {
                PreTestQuestionID = 7,
                PreTestAnswer = "A",
                PreTestResultID = 1
            };
            int result = _examInternalBL.AddPreTestQuestionResults(BLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }

        [TestMethod]
        public void UpdatePreTestQuestionResults()
        {
            PreTestQuestionResult BLModel = new PreTestQuestionResult()
            {
                PreTestQuestionResultID = 1,
                PreTestQuestionID = 8,
                PreTestAnswer = "B",
                PreTestResultID = 1
            };
            int result = _examInternalBL.UpdatePreTestQuestionResult(BLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }

        [TestMethod]
        public void UpdateExamResultIsPass()
        {
            _examInternalBL.UpdateExamResultIsPass(213, 242, true);
        }

        [TestMethod]
        public void GetPreTestAttemptByUser()
        {
            int result = _examInternalBL.GetPreTestAttemptByUser(150, 67);
            Assert.IsTrue(result > 0, "Unable to Add");
        }

        //exam results..hp
        [TestMethod]
        public void AddExamResults()
        {
            ExamResult BLModel = new ExamResult()
            {
                UID = 150,
                MEID=217,
                ExamID=20
            };
            int result = _examInternalBL.AddExamResult(BLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }
        [TestMethod]
        public void UpdateExamResults()
        {
            ExamResult BLModel = new ExamResult()
            {
                ExamResultID = 1,
                UID = 150,
                IsPass = false
            };
            int result = _examInternalBL.UpdateExamResult(BLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }
        [TestMethod]
        public void AddExamQuestionResults()
        {
            ExamQuestionResult BLModel = new ExamQuestionResult()
            {
                ExamQuestionID = 83,
               ExamAnswerTrueFalse=true,
                ExamResultID = 190
            };
            int result = _examInternalBL.AddExamQuestionResults(BLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }

        [TestMethod]
        public void UpdateExamQuestionResults()
        {
            ExamQuestionResult BLModel = new ExamQuestionResult()
            {
                ExamQuestionResultID = 1,
                ExamQuestionID = 8,
                ExamAnswer = "B",
                ExamResultID = 1
            };
            int result = _examInternalBL.UpdateExamQuestionResult(BLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }

        //Evaluation
        [TestMethod]
        public void AddEvalutionResults()
        {
            EvaluationResult BLModel = new EvaluationResult()
            {
                UID = 150,
                IsPass = true,
                MEID = 141
            };
            int result = _examInternalBL.AddEvaluationResult(BLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }

        [TestMethod]
        public void UpdateEvaluationtResults()
        {
            EvaluationResult BLModel = new EvaluationResult()
            {
                EvaluationResultID = 1,
                UID = 150,
                IsPass = false
            };
            int result = _examInternalBL.UpdateEvaluationResult(BLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }

        [TestMethod]
        public void UpdateEvaluationtResultIsPass()
        {
            _examInternalBL.UpdateEvaluationResultIsPass(1, true);
        
        }

        [TestMethod]
        public void GetExamAttempResulttByUserTest()
        {
            var result = _examInternalBL.GetExamAttempResulttByUser(227, 1144);
        }

        [TestMethod]
        public void GetEvaluationAttemptByUserAndMEID()
        {
            var result = _examInternalBL.GetEvaluationAttemptByUserAndMEID(177, 936);
            Assert.IsTrue(result == null, "Unable to Add");
        }

        [TestMethod]
        public void AddEvaluationtQuestionResults()
        {
            EvaluationQuestionResult BLModel = new EvaluationQuestionResult();
            BLModel.EvaluationAnswerID = 1;
            BLModel.EvaluationQuestionID = 1;
            BLModel.EvaluationResultID  = 1;      
            int result = _examInternalBL.AddEvaluationQuestionResults(BLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }

        [TestMethod]
        public void UpdateEvaluationtQuestionResults()
        {
            EvaluationQuestionResult BLModel = new EvaluationQuestionResult()
            {
                EvaluationQuestionResultID = 1,
                EvaluationQuestionID = 8,
                EvaluationAnswerID = 1,
                EvaluationResultID = 1
            };
            int result = _examInternalBL.UpdateEvaluationQuestionResult(BLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }

        [TestMethod]
        public void UpdateEvaluationResultIsPass()
        {
            _examInternalBL.UpdateEvaluationResultIsPass(1, true);
        }

        [TestMethod]
        public void GetEvaluationtAttemptByUser()
        {
            int result = _examInternalBL.GetEvaluationAttemptByUser(150);
            Assert.IsTrue(result > 0, "Unable to Add");
        }

        [TestMethod]
        public void GetAllEvaluationAnswer()
        {
            var result = _examInternalBL.GetAllEvaluationAnswer();
          
        }
    }
}