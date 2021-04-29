using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RedSocial.Services.Db
{
    public class RsDbContextFactory : IDesignTimeDbContextFactory<RsDbContext>
    {
        public RsDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RsDbContext>();
            optionsBuilder.UseSqlServer("Data Source=mopc-srv-dev01;Initial Catalog=RedSocialDb;Persist Security Info=True;User ID=evaluacion;Password=123456");

            return new RsDbContext(optionsBuilder.Options);
        }
    }
}
