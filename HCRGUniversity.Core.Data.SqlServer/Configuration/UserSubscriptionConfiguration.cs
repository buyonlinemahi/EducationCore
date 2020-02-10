using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class UserSubscriptionConfiguration : EntityTypeConfiguration<UserSubscription>
    {
        public UserSubscriptionConfiguration()
            : base()
        {
            ToTable(Constant.Tables.dbo.UserSubscription, Constant.Consts.Schema.DBO);
            HasKey(userSub => userSub.UserSubscriptionID);
            Property(userSub => userSub.UserSubscriptionID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).IsRequired();
        }
    }
}
