using Microsoft.EntityFrameworkCore;
using Fluent.Net;

namespace VehicleFleet.Api.Models;

public class ApiContext : DbContext
{
    public ApiContext(DbContextOptions<ApiContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasKey(b => b.IDNumber)
            .HasName("PrimaryKey_IDNumber");

        modelBuilder.Entity<User>()
            .HasOne(b => b.Account)
            .WithOne(i => i.User)
            .HasForeignKey<Account>(b => b.UserForeignKey);

        modelBuilder.Entity<Account>()
            .HasMany(s => s.Vehicles)
            .WithOne(s => s.Account)
            .HasForeignKey(s => s.AccountForeignKey);

        modelBuilder.Entity<Vehicle>()
            .HasKey(b => b.VIN)
            .HasName("PrimaryKey_VIN");
    }
}