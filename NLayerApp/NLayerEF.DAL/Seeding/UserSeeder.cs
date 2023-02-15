using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerEF.DAL.Entities;
using NLayerEF.DAL.Seeding.Interfaces;

namespace TeamworkSystem.DataAccessLayer.Seeding
{
    public class UserSeeder : ISeeder<User>
    {
        private static readonly List<(User, string)> users = new()
        {
            (
                new User
                {/*
                    Id = "43534636",*/
                    //Id = 11,
                    NikName = "Bob",
                    Email = "example@gmail.com",
                    Sex = "Male",
                    AboutMyself = "..."
                },
                "User%password1"
            ),
            (
                new User
                {
                    //Id = 1,
                    NikName = "Bob",
                    Email = "example@gmail.com",
                    Sex = "Male",
                    AboutMyself = "..."
                },
                "User%password2"
            )
        };

        public void Seed(EntityTypeBuilder<User> builder)
        {
            foreach (var user in users)
            {
                builder.HasData(user);
            }
        }
    }
}
