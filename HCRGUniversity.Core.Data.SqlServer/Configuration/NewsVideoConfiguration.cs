using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class NewsVideoConfiguration : EntityTypeConfiguration<NewsVideo>
    {
        public NewsVideoConfiguration()
            : base()
        {
            ToTable("NewsVideos", Constant.Consts.Schema.DBO);
            HasKey(newsVideo => newsVideo.NewsVideoID);
        }
    }
}
