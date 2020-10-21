using VetPet.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace VetPet.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Animal> Animals { get; set; }

        public override int SaveChanges()
        {
            SetUpdated();
            SetCreated();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            SetUpdated();
            SetCreated();
            return await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        private void SetUpdated()
        {
            var updatedEntities = ChangeTracker.Entries()
                .Where(i => i.State == EntityState.Modified
                            && i.Entity is BaseIDModel);

            foreach (var entity in updatedEntities)
            {
                ((BaseIDModel)entity.Entity).Updated = DateTime.UtcNow;
            }
        }

        private void SetCreated()
        {
            var addedEntities = ChangeTracker.Entries()
                .Where(i => i.State == EntityState.Added
                            && i.Entity is BaseIDModel);

            foreach (var entity in addedEntities)
            {
                ((BaseIDModel)entity.Entity).Created = DateTime.UtcNow;
            }
        }
    }
}
