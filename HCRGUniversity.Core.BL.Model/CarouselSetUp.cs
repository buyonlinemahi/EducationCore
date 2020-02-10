
namespace HCRGUniversity.Core.BL.Model
{
    public class CarouselSetUp : Base.BaseOrganizationColumn
    {
        public int CarouselID { get; set; }
        public string CarouselTitle { get; set; }
        public string CarouselDescription { get; set; }
        public string CarouselBgColor { get; set; }
        public int NewsID { get; set; }
        public string NewsTitle { get; set; }
        public string NewsDescription { get; set; }
        public string NewsPhotoUrl { get; set; }
        public string NewsType { get; set; }
        public string OrganizationName { get; set; }
    }
}
