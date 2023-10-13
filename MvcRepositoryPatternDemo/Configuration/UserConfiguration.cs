using JWTAuthDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace JWTAuthDemo.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");
            builder.HasKey(u => u.UserName);

            builder
                .Property(u => u.UserId)
                .HasColumnName("user_id")
                .HasColumnType("Bigint")
                .IsRequired();

            builder
               .Property(u => u.UserName)
               .HasColumnName("user_name")
               .HasColumnType("varchar(10)")
               .IsRequired();

            builder
               .Property(u => u.Password)
               .HasColumnName("password")
               .HasColumnType("varchar(10)")
               .IsRequired();
        }
    }
}
