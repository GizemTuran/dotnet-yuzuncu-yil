using DotnetYuzuncuYil.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetYuzuncuYil.Repo.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder) //Fluent API kullanımı
        {
            //Fluent API ile tablo adlarını, sütun isimlerini ve türlerini, primary key ve foreign keyleri yapılandırabiliriz.
            //Fluent APIleri AppDbContextin OnModelCreating methodu içerisinde çalıştırıyoruz.

            //Fluent key ayarlamaları
            builder.HasKey(x => x.Id); //Id'si tanımlı olmasına rağmen yine de tanımlama yapılır.

            builder.Property(t => t.Id) //Primary key otomatik olarak birer birer artar.
                .UseIdentityColumn();

            //TeamName alanı için max uzunluğu belirleme ve zorunlu bir alan haline getirme
            builder.Property(t => t.TeamName)
                .HasMaxLength(50)
                .IsRequired();
            
            //Tablo ismini belirleme
            builder.ToTable("Teams");
        }
    }
}
