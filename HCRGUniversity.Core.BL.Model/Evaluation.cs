
namespace HCRGUniversity.Core.BL.Model
{
   public class Evaluation
    {
        public int EvaluationID { get; set; }
        public string EvaluationName { get; set; }
        public bool EvaluationStatus { get; set; }
        public int ClientID { get; set; }
        public string OrganizationName { get; set; }
    }
}
