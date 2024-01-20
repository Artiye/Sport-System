using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sport_System.Domain.Entity;
using Sport_System.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sports_System.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //tournament
            modelBuilder.Entity<Tournament>()
                .HasMany(t => t.Teams)
                .WithMany(t => t.Tournaments);

            modelBuilder.Entity<Tournament>()
                .HasOne(t => t.Sport)
                .WithMany(s => s.Tournaments)
                .HasForeignKey(t => t.SportId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Tournament>()
                .HasOne(t => t.TournamentAdministrator)
                .WithMany(s => s.Tournaments)
                .HasForeignKey(t => t.TournamentAdministratorId)
                .OnDelete(DeleteBehavior.NoAction);


            //player
            modelBuilder.Entity<Player>()
                .HasOne(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.TeamId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Player>()
                .HasOne(p => p.ApplicationUser)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.ApplicationUserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Player>()
                .HasOne(p => p.Sport)
                .WithMany(s => s.Players)
                .HasForeignKey(p => p.SportId)
                .OnDelete(DeleteBehavior.NoAction);


            //team
            modelBuilder.Entity<Team>()
                .HasMany(t => t.Tournaments)
                .WithMany(t => t.Teams);

            modelBuilder.Entity<Team>()
                .HasOne(t => t.TeamOwner)
                .WithMany(t => t.Teams)
                .HasForeignKey(t => t.TeamOwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Team>()
                .HasMany(t => t.Players)
                .WithOne(t => t.Team)
                .HasForeignKey(t => t.TeamId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Team>()
                .HasOne(t => t.Sport)
                .WithMany(t => t.Teams)
                .HasForeignKey(t => t.SportId)
                .OnDelete(DeleteBehavior.NoAction);


            //application user
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Teams)
                .WithOne(t => t.TeamOwner)
                .HasForeignKey(t => t.TeamOwnerId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Players)
                .WithOne(p => p.ApplicationUser)
                .HasForeignKey(p => p.ApplicationUserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Tournaments)
                .WithOne(t => t.TournamentAdministrator)
                .HasForeignKey(t => t.TournamentAdministratorId)
                .OnDelete(DeleteBehavior.Cascade);



            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
