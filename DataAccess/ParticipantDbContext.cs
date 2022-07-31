using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ParticipantDbContext : IdentityDbContext<User>
    {
        public ParticipantDbContext(DbContextOptions<ParticipantDbContext> options)
           : base(options)
        {

        }

        public DbSet<Af> Afs { get; set; }
        public DbSet<ItRm> ItRms { get; set; }
        public DbSet<HR> HR { get; set; }
        public DbSet<ItWeb> ItWebs { get; set; }
        public DbSet<Logistic> Logistics { get; set; }
        public DbSet<Count> Counts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");
        }
    }
}
