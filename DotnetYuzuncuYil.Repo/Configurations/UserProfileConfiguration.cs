using DotnetYuzuncuYil.Core.DTOs;
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
    public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            //Primary key
            builder.HasKey(x => x.Id);

            //1'er 1'er artması
            builder.Property(x => x.Id)
                .UseIdentityColumn();

            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(250);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(250);
            builder.Property(x => x.NickName).HasMaxLength(100);

            //Tablo ismi için
            builder.ToTable("UserProfiles");
            //Eğer burada isim belirtmeseydim, appdbcontext içerisindeki userprofilesı almış olacaktı.
        }
    }
}
