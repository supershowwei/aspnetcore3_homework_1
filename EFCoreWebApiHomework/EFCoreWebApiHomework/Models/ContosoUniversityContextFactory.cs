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
                @"Server=192.168.0.133;Database=ContosoUniversity;User Id=pma$-3a5B2347-7BF6-4506-8E26-7D0FFE1CA91D-$$;Password=$@@~~474FdB67-2AE6-42AF-8ADE-9925D43F0570-wantg00~~-$;");

            return new ContosoUniversityContext(optionsBuilder.Options);
        }
    }
}