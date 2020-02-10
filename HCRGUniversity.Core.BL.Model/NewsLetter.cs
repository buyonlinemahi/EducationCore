
namespace HCRGUniversity.Core.BL.Model
{
   public class NewsLetter : Base.BaseOrganizationColumn
    {
        public int NewsLetterID { get; set; }
        public string NewsLetterContent { get; set; }
        public string OrganizationName { get; set; }
    }
}
