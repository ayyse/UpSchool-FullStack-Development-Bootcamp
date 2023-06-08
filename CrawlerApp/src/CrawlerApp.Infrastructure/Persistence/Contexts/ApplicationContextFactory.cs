using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CrawlerApp.Infrastructure.Persistence.Contexts
{
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));

            optionsBuilder.UseMySql("Server=141.98.112.67;Port=7002;Database=ayse_akisik_crawlerapp;Uid=ayse_akisik;Pwd=ku6ql3Y8S1FWrf311T6r3r7Jf;", serverVersion);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
