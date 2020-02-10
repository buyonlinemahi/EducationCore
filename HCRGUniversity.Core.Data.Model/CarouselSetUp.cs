
namespace HCRGUniversity.Core.Data.Model
{
    public class CarouselSetUp: Base.BaseOrganizationColumn
    {
        public int CarouselID {get;set;}
        public string CarouselTitle { get; set; }
        public string CarouselDescription  {get;set;}
        public string CarouselBgColor  {get;set;}
        public int NewsID  {get;set;}
        
    }
}
