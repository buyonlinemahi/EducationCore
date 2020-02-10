using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class NewsPhotoConfiguration : EntityTypeConfiguration<NewsPhoto>
    {
        public NewsPhotoConfiguration()
            : base()
        {
            ToTable("NewsPhotos", Constant.Consts.Schema.DBO);
            HasKey(newsPhoto => newsPhoto.NewsPhotoID);
        }
    }
}
