
namespace HCRGUniversity.Core.Data.Model
{
    public class PreTestQuestionResult
    {
        public int PreTestQuestionResultID { get; set; }
        public int PreTestQuestionID { get; set; }
        public string PreTestAnswer { get; set; }
        public int PreTestResultID { get; set; }
        public bool? PreTestAnswerTrueFalse { get; set; }
    }
}
