using HCRGUniversity.Core.Data.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
  public class EventConfiguration: EntityTypeConfiguration<Event>
    {
      public EventConfiguration()
            : base()
        {
            ToTable("Events", Constant.Consts.Schema.DBO);
            HasKey(events => events.EventID);
            Property(events => events.EventID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();

        }
    }
}
