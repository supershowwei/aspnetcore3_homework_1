using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EFCoreWebApiHomework.Models
{
    public class ContosoUniversityContextFactory : IDesignTimeDbContextFactory<ContosoUniversityContext>
    {
        public ContosoUniversityContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ContosoUniversityContext>().UseSqlServer(
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ContosoUniversity;Integrated Security=True");

            return new ContosoUniversityContext(optionsBuilder.Options);
        }
    }
}