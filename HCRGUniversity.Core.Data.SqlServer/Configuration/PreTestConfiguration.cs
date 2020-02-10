using HCRGUniversity.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
  public class PreTestConfiguration: EntityTypeConfiguration<PreTest>
    {
      public PreTestConfiguration()
            : base()
        {
            ToTable("PreTests", Constant.Consts.Schema.DBO);
            HasKey(preTests => preTests.PreTestID);          
        }
    }
}
