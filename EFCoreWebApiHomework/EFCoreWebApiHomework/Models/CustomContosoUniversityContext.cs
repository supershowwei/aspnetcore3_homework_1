using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFCoreWebApiHomework.Models
{
    public partial class ContosoUniversityContext
    {
        public override int SaveChanges()
        {
            this.SetDateModified();

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            this.SetDateModified();

            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            this.SetDateModified();

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void SetDateModified()
        {
            var entries = this.ChangeTracker.Entries();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Modified)
                {
                    entry.CurrentValues.SetValues(new { DateModified = DateTime.Now });
                }
            }
        }
    }
}