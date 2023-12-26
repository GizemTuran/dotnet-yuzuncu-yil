using DotnetYuzuncuYil.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetYuzuncuYil.Repo.Seeds
{
    public class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(

                new User { Id = 1, Email = "buse@gmail.com", Password = "123456", UserName = "buse", TeamId = 1, CreatedDate = DateTime.Now },
                new User { Id = 2, Email = "elnur@gmail.com", Password = "455678", UserName = "elnur", TeamId = 2, CreatedDate = DateTime.Now },
                new User { Id = 3, Email = "seher@gmail.com", Password = "789456", UserName = "seher", TeamId = 3, CreatedDate = DateTime.Now },
                new User { Id = 4, Email = "gizem@gmail.com", Password = "874569", UserName = "gizem", TeamId = 4, CreatedDate = DateTime.Now }

                );
        }
    }
}
