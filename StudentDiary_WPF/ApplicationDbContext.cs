using StudentDiary_WPF.Models.Configurations;
using StudentDiary_WPF.Models.Domains;
using StudentDiary_WPF.Properties;
using StudentDiary_WPF.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Reflection;

namespace StudentDiary_WPF
{
    public class ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext()
        : base(Settings.Default.ConnetionString)
        //:base()
        {

        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new StudentConfiguration());
            modelBuilder.Configurations.Add(new GroupConfiguration());
            modelBuilder.Configurations.Add(new RatingConfiguration());
        }



    }

   
}