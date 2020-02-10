
namespace HCRGUniversity.Core.Data.Model
{
    public class ExamQuestionResult
    {
        public int ExamQuestionResultID { get; set; }
        public int ExamQuestionID { get; set; }
        public string ExamAnswer { get; set; }
        public int ExamResultID { get; set; }
        public bool? ExamAnswerTrueFalse { get; set; }
    }
}
