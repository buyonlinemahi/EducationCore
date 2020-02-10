using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class StateConfiguration : EntityTypeConfiguration<State>
    {
        public StateConfiguration()
            : base()
        {
            ToTable("States", Constant.Consts.Schema.LOOKUP);
            HasKey(table => table.StateID);
        }
    }
}
