
namespace HCRGUniversity.Core.Data.Model
{
  public  class Evaluation
  {
      public int EvaluationID { get; set; }
       public string  EvaluationName { get; set; }     
       public bool  EvaluationStatus { get; set; }
       public int ClientID { get; set; }
    }
}
