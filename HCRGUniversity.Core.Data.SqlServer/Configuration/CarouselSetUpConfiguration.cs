using HCRGUniversity.Core.Data.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class CarouselSetUpConfiguration : EntityTypeConfiguration<CarouselSetUp>
    {
        public CarouselSetUpConfiguration()
            : base()
        {
            ToTable("CarouselSetUps", Constant.Consts.Schema.DBO);
            HasKey(carouselSetup => carouselSetup.CarouselID);
            Property(carouselSetup => carouselSetup.CarouselID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(carouselSetup => carouselSetup.CarouselTitle);
            Property(carouselSetup => carouselSetup.CarouselDescription);
            Property(carouselSetup => carouselSetup.CarouselBgColor);
            Property(carouselSetup => carouselSetup.NewsID);
        }

    }
}
