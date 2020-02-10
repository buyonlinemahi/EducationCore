
namespace HCRGUniversity.Core.Data.Model
{
   public  class NewsSection : Base.BaseOrganizationColumn
    {
         public int  NewsSectionID { get; set; }
         public string  NewsSectionTitle { get; set; }
         public string NewsSectionType { get; set; }              
    }
}
