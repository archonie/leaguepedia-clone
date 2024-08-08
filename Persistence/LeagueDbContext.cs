using Domain.Entities;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class LeagueDbContext : DbContext
{
    public LeagueDbContext(DbContextOptions<LeagueDbContext> opt) : base(opt)
    {
        
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.DateCreated = DateTime.UtcNow;
                    entry.Entity.CreatedBy = "Api";
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModified = DateTime.UtcNow;
                    entry.Entity.ModifiedBy = "Api";
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        
        base.OnModelCreating(builder);
        builder.Entity<Region>(entity =>
        {
            entity
                .HasMany(t => t.Countries)
                .WithOne(t =>t.Region)
                .HasForeignKey(b=> b.RegionId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Region_Country");
        });
        builder.Entity<League>(entity =>
        {
            entity
                .HasOne(t => t.Country)
                .WithMany(t=>t.Leagues)
                .HasForeignKey(b => b.CountryId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_League_Country");
            entity
                .HasMany(t => t.Teams)
                .WithOne(t=> t.League)
                .HasForeignKey(b => b.LeagueId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_League_Team");
            entity
                .HasOne(t => t.Region)
                .WithMany()
                .HasForeignKey(b => b.RegionId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_League_Region");
        });
        builder.Entity<Team>(entity =>
        {
            entity
                .HasOne(t => t.League)
                .WithMany(l => l.Teams)
                .HasForeignKey(t => t.LeagueId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Team_League");

            entity
                .HasMany(t => t.Players)
                .WithOne(p => p.Team)
                .HasForeignKey(p => p.TeamId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Team_Person");

            entity
                .HasOne(t => t.FoundedCountry)
                .WithMany(t=>t.NativeTeams)
                .HasForeignKey(t => t.FoundedCountryId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Team_FoundedCountry");

            entity
                .HasOne(t => t.CurrentCountry)
                .WithMany(t=> t.OperatingTeams)
                .HasForeignKey(t => t.CurrentCountryId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Team_CurrentCountry");

            entity
                .HasOne(t => t.Region)
                .WithMany()
                .HasForeignKey(t => t.RegionId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Team_Region");
        });
        builder.Entity<Country>(entity =>
        {
            entity
                .HasOne(t => t.Region)
                .WithMany(t=> t.Countries)
                .HasForeignKey(b => b.RegionId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Country_Region");
            entity
                .HasMany(t => t.Leagues)
                .WithOne(t=> t.Country)
                .HasForeignKey(b => b.CountryId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Country_Leagues");
        });
        builder.Entity<Person>(entity =>
        {
            entity
                .HasOne(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.TeamId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Person_Team");

            entity
                .HasOne(p => p.Region)
                .WithMany()
                .HasForeignKey(p => p.ResidencyId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Person_Region");

            entity
                .HasOne(p => p.Country)
                .WithMany(c=>c.Persons)
                .HasForeignKey(p => p.CountryId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Person_Country");
        });
        
    }

    public DbSet<Team> Teams { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Person> Persons{ get; set; }
    public DbSet<ApplicationUser> Users { get; set; }
    public DbSet<League> Leauges { get; set; }
}
