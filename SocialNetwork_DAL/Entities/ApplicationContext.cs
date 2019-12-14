using Microsoft.EntityFrameworkCore;
using SocialNetwork_DAL.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork_DAL.Entities
{
    public class ApplicationContext : DbContext
    {
        private string connectionString;
        public ApplicationContext(string conString)
        {
             this.connectionString = conString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(this.connectionString);
        }
        public DbSet<Person> People { get; set; }
        public DbSet<DuoChat> DuoChat { get; set; }
        public DbSet<Invite> Invite { get; set; }
        public DbSet<Friend> Friend { get; set; }

    }
}
