using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkTutorial.Data
{
    public class ApplicationDbContext : DbContext
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        public DbSet<SettingsDataModel> Settings { get; set; }

        /// <summary>
        /// Default constructor, expecting database options passed in
        /// </summary>
        /// <param name="options">Database options</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // use fluent api to model relationships and configure model constraints

            modelBuilder.Entity<SettingsDataModel>().HasIndex(a => a.Name);
        }
    }
}
