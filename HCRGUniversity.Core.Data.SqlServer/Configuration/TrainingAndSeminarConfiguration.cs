using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class TrainingAndSeminarConfiguration : EntityTypeConfiguration<TrainingAndSeminar>
    {
        public TrainingAndSeminarConfiguration()
            : base()
        {
            ToTable("TrainingAndSeminars", Constant.Consts.Schema.DBO);
            HasKey(tns => tns.TrainingAndSeminarID);
            Property(tns => tns.TrainingAndSeminarID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
            Property(tns => tns.TrainingAndSeminarDesc).IsRequired();
        }
    }
}
