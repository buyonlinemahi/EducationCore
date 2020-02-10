using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using HCRGUniversity.Core.Data.Model;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class MenuConfiguration : EntityTypeConfiguration<Menu>
    {

        public MenuConfiguration()
            : base()
        {
            ToTable("Menus", Constant.Consts.Schema.LOOKUP);
            HasKey(table => table.MenuID);
        }
    }
}
