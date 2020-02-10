using HCRGUniversity.Core.BL;
using HCRGUniversity.Core.BL.Implementation;
using HCRGUniversity.Core.Data;
using HCRGUniversity.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreBusinessTierTest
{
    [TestClass]
   public class ExamQuestionTest
    {
        private IExamQuestionRepository _examQuestionRepository;
        private IExamQuestion _examQuestionBL;
        private HCRGUniversity.Core.Data.Model.ExamQuestion BLModel = new HCRGUniversity.Core.Data.Model.ExamQuestion();
        private IPreTestQuestionRepository _preTestQuestionRepository;       
        private HCRGUniversity.Core.Data.Model.PreTestQuestion DLModel = new HCRGUniversity.Core.Data.Model.PreTestQuestion();

        private IEducationPreTestQuestionRepository _educationPreTestQuestionRepository;
        private HCRGUniversity.Core.Data.Model.EducationPreTestQuestion DLModel1 = new HCRGUniversity.Core.Data.Model.EducationPreTestQuestion();
        private IEducationExamQuestionRepository _educationExamQuestionRepository;
        private HCRGUniversity.Core.Data.Model.EducationExamQuestion DLModel2 = new HCRGUniversity.Core.Data.Model.EducationExamQuestion();
        private IPreTestRepository _preTestRepository;
        private HCRGUniversity.Core.Data.Model.PreTest DLModel3 = new HCRGUniversity.Core.Data.Model.PreTest();
        private IExamRepository _examRepository;
        private HCRGUniversity.Core.Data.Model.Exam DLModel4 = new HCRGUniversity.Core.Data.Model.Exam();
        private IEvaluationRepository _evaluationRepository;
        private HCRGUniversity.Core.Data.Model.Evaluation DLModel5 = new HCRGUniversity.Core.Data.Model.Evaluation();
        private IEvaluationQuestionRepository _evaluationQuestionRepository;
        private HCRGUniversity.Core.Data.Model.EvaluationQuestion DLModel6 = new HCRGUniversity.Core.Data.Model.EvaluationQuestion();
        private IEducationEvaluationRepository _educationEvaluationRepository;
        private HCRGUniversity.Core.Data.Model.EducationEvaluation DLModel7 = new HCRGUniversity.Core.Data.Model.EducationEvaluation();
        [TestInitialize]
        public void ExamQuestionInitialize()
        {
            _examQuestionRepository = new ExamQuestionRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _preTestQuestionRepository = new PreTestQuestionRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _educationPreTestQuestionRepository = new EducationPreTestQuestionRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _educationExamQuestionRepository = new EducationExamQuestionRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _examRepository = new ExamRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _preTestRepository = new PreTestRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _evaluationRepository = new EvaluationRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _evaluationQuestionRepository = new EvaluationQuestionRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());
            _educationEvaluationRepository = new EducationEvaluationRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<HCRGUniversity.Core.Data.SqlServer.HCRGUniversityDBContext>());

            _examQuestionBL = new ExamQuestionImpl(_examQuestionRepository, _preTestQuestionRepository, _educationExamQuestionRepository, _educationPreTestQuestionRepository, _examRepository, _preTestRepository, _evaluationRepository, _evaluationQuestionRepository, _educationEvaluationRepository);
        }

        [TestMethod]
        public void AddExamQuestion()
        {
            // test = 'B';
            BLModel.ExamQues = "testing tesing";
            //BLModel.ExamOptionA = "testing tesing";
            //BLModel.ExamOptionB = "sda";
            //BLModel.ExamOptionC = "testing tesing";
            //BLModel.ExamOptionD = "sda";
            //BLModel.ExamAnswer = "A";
            BLModel.ExamAnswerType = "Options";
            BLModel.ExamAnswerTrueFalse = true;
            BLModel.ExamID = 2;
            int result = _examQuestionBL.AddExamQuestion(BLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }
        [TestMethod]
        public void UpdateExamQuestion()
        {
            BLModel.ExamQuestionID = 1;
            BLModel.ExamQues = "testing tesing";
            BLModel.ExamOptionA = "testing tesing";
            BLModel.ExamOptionB = "sda";
            BLModel.ExamOptionC = "testing tesing";
            BLModel.ExamOptionD = "sda";
            BLModel.ExamAnswer ="A";
            int result = _examQuestionBL.UpdateExamQuestion(BLModel);
            Assert.IsTrue(result > 0, "Unable to update");
        }

        [TestMethod]
        public void DeleteExamQuestion()
        {
            _examQuestionBL.DeleteExamQuestion(1);
        }

        [TestMethod]
        public void GetAllPagedExamQuestion()
        {
            var result = _examQuestionBL.GetAllPagedExamQuestionByExamID(2,0, 10);
            Assert.IsTrue(result != null, "Unable to find");
        }

        //Pre Test Question
        [TestMethod]
        public void AddPreTestQuestion()
        {
            DLModel.PreTestQues = "testing tesing";
            DLModel.PreTestOptionA = "testing tesing";
            DLModel.PreTestOptionB = "sda";
            DLModel.PreTestOptionC = "testing tesing";
            DLModel.PreTestOptionD = "sda";
            DLModel.PreTestAnswer = "A";
            int result = _examQuestionBL.AddPreTestQuestion(DLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }
        [TestMethod]
        public void UpdatePreTestQuestion()
        {
            DLModel.PreTestQuestionID = 1;
            DLModel.PreTestQues = "testing tesing";
            DLModel.PreTestOptionA = "testing tesing";
            DLModel.PreTestOptionB = "sda";
            DLModel.PreTestOptionC = "testing tesing";
            DLModel.PreTestOptionD = "sda";
            DLModel.PreTestAnswer = "B";
            int result = _examQuestionBL.UpdatePreTestQuestion(DLModel);
            Assert.IsTrue(result > 0, "Unable to update");
        }

        [TestMethod]
        public void DeletePreTestQuestion()
        {
            _examQuestionBL.DeletePreTestQuestion(1);
        }

        [TestMethod]
        public void GetAllPagedPreTestQuestionByPreTestID()
        {
            var result = _examQuestionBL.GetAllPagedPreTestQuestionByPreTestID(35,0, 10);
            Assert.IsTrue(result != null, "Unable to find");
        }

        [TestMethod]
        public void GetEducationPreTestQuestionByEducationID()
        {
            var result = _examQuestionBL.GetEducationPreTestQuestionByEducationID(490);
            Assert.IsTrue(result != null, "Unable to find");
        }
        

        //EducationExamQuestion
        [TestMethod]
        public void AddEducationExamQuestion()
        {
            DLModel2.EducationID = 1;
            DLModel2.ExamID = 9;
            int result = _examQuestionBL.AddEducationExamQuestion(DLModel2);
            Assert.IsTrue(result > 0, "Unable to Add");
        }
        [TestMethod]
        public void UpdateEducationExamQuestion()
        {
            DLModel2.EducationID = 1;
            DLModel2.ExamID = 9;
          
            _examQuestionBL.UpdateEducationExamQuestion(DLModel2);
            //Assert.IsTrue(result > 0, "Unable to update");
        }

        [TestMethod]
        public void DeleteEducationExamQuestion()
        {
            _examQuestionBL.DeleteEducationExamQuestion(1);
        }

        //EducationPreTestQuestions
        [TestMethod]
        public void AddEducationPreTestQuestion()
        {
            DLModel1.EducationID = 1;
            DLModel1.PreTestID = 2;
            int result = _examQuestionBL.AddEducationPreTestQuestion(DLModel1);
            Assert.IsTrue(result > 0, "Unable to Add");
        }
        [TestMethod]
        public void UpdateEducationPreTestQuestion()
        {
            DLModel1.CoursePreTestID = 1;
            DLModel1.EducationID = 1;
            DLModel1.PreTestID = 8;
            _examQuestionBL.UpdateEducationPreTestQuestion(DLModel1);
          //  Assert.IsTrue(result > 0, "Unable to update");
        }

        [TestMethod]
        public void DeleteEducationPreTestQuestion()
        {
            _examQuestionBL.DeleteEducationPreTestQuestion(1);
        }


        //..................
        [TestMethod]
        public void AddExam()
        {
            // test = 'B';
            DLModel4.ExamName = "testing tesing";
            int result = _examQuestionBL.AddExam(DLModel4);
            Assert.IsTrue(result > 0, "Unable to Add");
        }
        [TestMethod]
        public void UpdateExam()
        {
            DLModel4.ExamID = 1;
            DLModel4.ExamName = "testing tesinggfdgdfgdfgdfgdfg";
            int result = _examQuestionBL.UpdateExam(DLModel4);
            Assert.IsTrue(result > 0, "Unable to update");
        }

        [TestMethod]
        public void DeleteExam()
        {
            _examQuestionBL.DeleteExam(1);
        }

        [TestMethod]
        public void GetAllPagedExam()
        {
            var result = _examQuestionBL.GetAllPagedExam("t",0, 10,1,1);
            Assert.IsTrue(result != null, "Unable to find");
        }
        [TestMethod]
        public void GetAllActiveExam()
        {
            var result = _examQuestionBL.GetAllActiveExam(1);
            Assert.IsTrue(result != null, "Unable to find");
        }
        

        [TestMethod]
        public void AddPreTest()
        {
            // test = 'B';
            DLModel3.PreTestName = "testing tesing";
            int result = _examQuestionBL.AddPreTest(DLModel3);
            Assert.IsTrue(result > 0, "Unable to Add");
        }
        [TestMethod]
        public void UpdatePreTest()
        {
            DLModel3.PreTestID = 1;
            DLModel3.PreTestName = "testing tesinggfdgdfgdfgdfgdfg";
            int result = _examQuestionBL.UpdatePreTest(DLModel3);
            Assert.IsTrue(result > 0, "Unable to update");
        }

        [TestMethod]
        public void DeletePreTest()
        {
            _examQuestionBL.DeletePreTest(1);
        }

        [TestMethod]
        public void GetAllPagedPreTest()
        {
            var result = _examQuestionBL.GetAllPagedPreTest("t", 0, 10,1,1);
            Assert.IsTrue(result != null, "Unable to find");
        }
//........
        [TestMethod]
        public void AddEvaluation()
        {
            // test = 'B';
            DLModel5.EvaluationName = "testing tesing";
            int result = _examQuestionBL.AddEvaluation(DLModel5);
            Assert.IsTrue(result > 0, "Unable to Add");
        }
        [TestMethod]
        public void UpdateEvaluation()
        {
            DLModel5.EvaluationID = 1;
            DLModel5.EvaluationName = "testing tesinggfdgdfgdfgdfgdfg";
            int result = _examQuestionBL.UpdateEvaluation(DLModel5);
            Assert.IsTrue(result > 0, "Unable to update");
        }
        [TestMethod]
        public void UpdateEvaluationStatus()
        {
            DLModel5.EvaluationID = 216;
            DLModel5.EvaluationStatus = false;
            DLModel5.EvaluationName = "m";
            int result = _examQuestionBL.UpdateEvaluation(DLModel5);
            Assert.IsTrue(result > 0, "Unable to update");
        }

        [TestMethod]
        public void DeleteEvaluation()
        {
            _examQuestionBL.DeleteEvaluation(1);
        }

        [TestMethod]
        public void GetAllPagedEvaluation()
        {
            var result = _examQuestionBL.GetAllPagedEvaluation("", 0, 100,1,1);
            Assert.IsTrue(result != null, "Unable to find");
        }

        [TestMethod]
        public void AddEvaluationQuestion()
        {
            // test = 'B';
            DLModel6.EvaluationID = 1;
            DLModel6.EvaluationQues = "fsdfsdf";
            int result = _examQuestionBL.AddEvaluationQuestion(DLModel6);
            Assert.IsTrue(result > 0, "Unable to Add");
        }
        [TestMethod]
        public void AddEvaluationPredefinedQuestion()
        {
            int result = _examQuestionBL.AddEvaluationQuestionsFromEvaluationPredefinedQuestions(216);
            Assert.IsTrue(result > 0, "Unable to Add");
        }
        [TestMethod]
        public void UpdateEvaluationQuestion()
        {
            DLModel6.EvaluationID = 1;
            DLModel6.EvaluationQues = "fsdfssfdfsdfsdf";
            DLModel6.EvaluationQuestionID = 1;
            int result = _examQuestionBL.UpdateEvaluationQuestion(DLModel6);
            Assert.IsTrue(result > 0, "Unable to update");
        }

        [TestMethod]
        public void UpdateEvaluationQuestionState()
        {
            DLModel6.EvaluationID = 215;
            DLModel6.EvaluationQues = "The information provided in course was well researched";
            DLModel6.EvaluationQuestionID = 73;
            DLModel6.IsStatus = true;
            int result = _examQuestionBL.UpdateEvaluationQuestionStatus(DLModel6);
            Assert.IsTrue(result > 0, "Unable to update");
        }

        [TestMethod]
        public void DeleteEvaluationQuestion()
        {
            _examQuestionBL.DeleteEvaluationQuestion(1);
        }

        [TestMethod]
        public void GetAllPagedEvaluationQuestion()
        {
            var result = _examQuestionBL.GetAllPagedEvaluationQuestionByEvaluationID(1, 0, 10);
            Assert.IsTrue(result != null, "Unable to find");
        }


        //EducationExamQuestion
        [TestMethod]
        public void AddEducationEvaluation()
        {
            DLModel7.EducationID = 1;
            DLModel7.EvaluationID = 1;
            int result = _examQuestionBL.AddEducationEvaluation(DLModel7);
            Assert.IsTrue(result > 0, "Unable to Add");
        }
        [TestMethod]
        public void UpdateEducationEvaluation()
        {
            DLModel7.CourseEvaluationID = 1;
            DLModel7.EducationID = 1;
            DLModel7.EvaluationID = 8;
            _examQuestionBL.UpdateEducationEvaluation(DLModel7);
         //   Assert.IsTrue(result > 0, "Unable to update");
        }

        [TestMethod]
        public void DeleteEducationEvaluation()
        {
            _examQuestionBL.DeleteEducationExamQuestion(1);
        }
        [TestMethod]
        public void GetEducationEvaluationByEducationID()
        {
            var result = _examQuestionBL.GetEducationEvaluationByEducationID(424);
        }


        [TestMethod]
        public void GetAllPreTestQuestionDetailByEID()
        {
            var result = _examQuestionBL.GetAllPreTestQuestionDetailByEID(423);
        }

        [TestMethod]
        public void GetAllExamQuestionDetailByEID()
        {
            var result = _examQuestionBL.GetAllExamQuestionDetailByEID(435);
        }

        [TestMethod]
        public void GetAllEvaluationQuestionDetailByEID()
        {
            var result = _examQuestionBL.GetAllEvaluationQuestionDetailByEID(435);
        }

        [TestMethod]
        public void GetExamQuestionWrongAnswered()
        {
            var result = _examQuestionBL.GetExamQuestionWrongAnswered(228);
        }

        [TestMethod]
        public void GetEducationExamQuestionByEducationID()
        {
            var result = _examQuestionBL.GetEducationExamQuestionByEducationID(559);
        }
    }
}
