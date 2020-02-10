
namespace HCRGUniversity.Core.BL.Model
{
  public class Exam
    {
        public int ExamID { get; set; }
        public string ExamName { get; set; }
        public bool ExamStatus { get; set; }
        public int ClientID { get; set; }
        public string OrganizationName { get; set; }
    }
}
