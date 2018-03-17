using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Assessment.Models;

namespace Assessment.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            //https://docs.microsoft.com/en-us/ef/core/modeling/relationships
            builder.Entity<Case>()
                .HasOne(c => c.Worker)
                .WithMany(x => x.WorkerCases);

            builder.Entity<Case>()
                .HasOne(c => c.Reviewer)
                .WithMany(u => u.ReviewerCases);

            builder.Entity<Case>()
                .HasOne(c => c.Approver)
                .WithMany(u => u.ApproverCases);
        }
        public DbSet<Case> Cases { get; set; }

    }
}
