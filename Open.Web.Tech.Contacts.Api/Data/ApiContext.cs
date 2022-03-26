using Microsoft.EntityFrameworkCore;
using Open.Web.Tech.Contacts.Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Open.Web.Tech.Contacts.Api.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Contact> Contacts { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Skill> Skills { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<ContactSkill> ContactSkills { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().ToTable("Contact");
            modelBuilder.Entity<ContactSkill>().ToTable("Skill_Contact");
            modelBuilder.Entity<Skill>().ToTable("Skill");

            modelBuilder.Entity<ContactSkill>()
                .HasOne(c => c.Contact)
                .WithMany(cs => cs.SkillContact)
                .HasForeignKey(ci => ci.ContactID);

            modelBuilder.Entity<ContactSkill>()
            .HasOne(c => c.Skill)
            .WithMany(cs => cs.SkillContact)
            .HasForeignKey(ci => ci.SkillID);
        }
    }
}
