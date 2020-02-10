using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HCRGUniversity.Core.Data.Model;


namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class NewsLetterConfiguration : EntityTypeConfiguration<NewsLetter>
    {
       public NewsLetterConfiguration()
            : base()
        {
            ToTable("NewsLetters", Constant.Consts.Schema.DBO);
            HasKey(newsLetter => newsLetter.NewsLetterID);
            Property(newsLetter => newsLetter.NewsLetterID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(newsLetter => newsLetter.NewsLetterID).IsRequired();
            Property(newsLetter => newsLetter.NewsLetterContent);        
        }
    }
}
