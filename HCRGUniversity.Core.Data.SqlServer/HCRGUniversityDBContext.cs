using HCRGUniversity.Core.Data.SqlServer.Configuration;
using System.Data.Entity;

namespace HCRGUniversity.Core.Data.SqlServer
{
    public class HCRGUniversityDBContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(typeof(UserConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public virtual void Save()
        {
            base.SaveChanges();
        }
    }
}
