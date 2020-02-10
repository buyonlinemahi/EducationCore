using HCRGUniversity.Core.Data.Model;
using System.Data.Entity.ModelConfiguration;

namespace HCRGUniversity.Core.Data.SqlServer.Configuration
{
    public class FileTypeConfiguration : EntityTypeConfiguration<FileType>
    {
       public FileTypeConfiguration()
            : base()
        {
            ToTable("FileTypes", Constant.Consts.Schema.DBO);
            HasKey(table => table.FileTypeID);
        }
    }
}
