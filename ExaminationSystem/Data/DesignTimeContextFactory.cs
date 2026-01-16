using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ExaminationSystem.Data
{
    public class DesignTimeContextFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseSqlServer(@"Data source = (localdb)\MSSQLLocalDB; initial catalog =ExaminationDB ; integrated security = true; trust server certificate = true ");

            return new Context(optionsBuilder.Options);
        }
    }
}