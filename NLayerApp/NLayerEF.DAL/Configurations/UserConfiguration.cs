using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerEF.DAL.Entities;
using TeamworkSystem.DataAccessLayer.Seeding;

namespace TeamworkSystem.DataAccessLayer.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //builder.HasKey(user => user.Id);

            builder.Property(user => user.NikName)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(user => user.Email)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(user => user.Sex)
                   .HasMaxLength(50);

            builder.Property(user => user.AboutMyself)
                   .HasMaxLength(50);

            builder.Property(user => user.RegistrationDate)
                   .HasMaxLength(50);

            /*builder.HasMany(user => user.Friends)
                   .WithMany(user => user.FriendForUsers)
                   .UsingEntity(entity =>
                   {
                       entity.ToTable("Friends");
                       entity.Property("FriendsId").HasColumnName("FirstId");
                       entity.Property("FriendForUsersId").HasColumnName("SecondId");
                   });*/

            //new UserSeeder().Seed(builder);
        }
    }
}
