using DotnetYuzuncuYil.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DotnetYuzuncuYil.Repo
{
    public class AppDbContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configurationlar yapılır
            //Tüm fluent api sınıflarını toplar ve bunları model yapılandırması için kullanır. Yani otomatik bütün configaritonlar aktif hale gelir.
            //Burada yapılan işlemlere örnek team name 50 karakterden fazla olmasın vb.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
