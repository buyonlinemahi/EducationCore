using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class UserCardDetailConfiguration : EntityTypeConfiguration<UserCardDetail>
    {
        public UserCardDetailConfiguration()
            : base()
        {
            ToTable("UserCardDetails", Constant.Consts.Schema.DBO);
            HasKey(userCardDetail => userCardDetail.UserCardDetailID);
        }
    }
}
