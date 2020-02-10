
namespace HCRGUniversity.Core.Data.Model
{
  public  class Accreditor
    {
      public int AccreditorID { get; set; }
      public string AccreditorName { get; set; }
      public bool IsActive { get; set; }
      public int OrganizationID { get; set; }
    }
}
