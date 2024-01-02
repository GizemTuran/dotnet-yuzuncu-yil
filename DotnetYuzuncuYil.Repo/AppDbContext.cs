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

        //db contextin save change olmadan dbye gitmiyor sade db context tarafında kalıyor.Burada dbye gitme işlemleri yapılır.
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries()) //veri tabanına gitmeye hazır sorguları entitylerin içinde topluyor
            {
                if (item.Entity is BaseEntity entityReference) //ön yüze created,updated date gelmemesi için eğer ki ön yüzden gelen saat utcye uymazsa gibi olaylara karşı önlem almak için 
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                entityReference.CreatedDate = DateTime.Now;
                                entityReference.UpdatedDate = null;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                entityReference.UpdatedDate = DateTime.Now;
                                break;
                            }
                    }
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        public override int SaveChanges()
        {
            foreach (var item in ChangeTracker.Entries()) //veri tabanına gitmeye hazır sorguları entitylerin içinde topluyor
            {
                if (item.Entity is BaseEntity entityReference) //ön yüze created,updated date gelmemesi için eğer ki ön yüzden gelen saat utcye uymazsa gibi olaylara karşı önlem almak için 
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                entityReference.CreatedDate = DateTime.Now;
                                entityReference.UpdatedDate = null;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                entityReference.UpdatedDate = DateTime.Now;
                                break;
                            }
                    }
                }
            }
            return base.SaveChanges();
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configurationlar yapılır
            //Tüm fluent api sınıflarını toplar ve bunları model yapılandırması için kullanır. Yani otomatik bütün configaritonlar aktif hale gelir.
            //Burada yapılan işlemlere örnek team name 50 karakterden fazla olmasın vb.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
