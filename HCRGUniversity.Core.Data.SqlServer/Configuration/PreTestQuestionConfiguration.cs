
using HCRGUniversity.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;
namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class PreTestQuestionConfiguration : EntityTypeConfiguration<PreTestQuestion>
    {
        public PreTestQuestionConfiguration()
            : base()
        {
            ToTable("PreTestQuestions", Constant.Consts.Schema.DBO);
        }
    }
}
