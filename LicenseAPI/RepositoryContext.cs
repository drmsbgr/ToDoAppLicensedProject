using Microsoft.EntityFrameworkCore;

namespace LicenseAPI;

public class RepositoryContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<License> Licenses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<License>(o =>
        {
            o.HasKey(x => x.MachineID);
        });
    }
}