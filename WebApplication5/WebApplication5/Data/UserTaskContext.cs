using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;

namespace WebApplication5.Data
{
    public partial class UserTaskContext : DbContext
    {
        public UserTaskContext(DbContextOptions<UserTaskContext> options) : base(options)
        {
        }

        public UserTaskContext() { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Models.Task> Tasks { get; set; }
        public virtual DbSet<Log> Log { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Task>()
                .HasOne(p => p.User)
                .WithMany(b => b.Tasks)
                //.HasForeignKey(p => p.User.ID)
                .HasPrincipalKey(b => b.ID); 
               
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
