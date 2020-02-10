using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    class NewsConfiguration : EntityTypeConfiguration<News>
    {
        
       public NewsConfiguration()
            : base()
        {
            ToTable("News", Constant.Consts.Schema.DBO);
            HasKey(news => news.NewsID);
        }
    }
}
