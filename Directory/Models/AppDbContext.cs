using Microsoft.EntityFrameworkCore;

namespace Directory.Models
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<UserModel> Users { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            var datas = ChangeTracker.Entries<UserModel>();
            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.Now,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.Now,
                    EntityState.Unchanged => data.Entity.UpdatedDate = DateTime.Now


                };
            }


            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
