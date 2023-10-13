
using Microsoft.EntityFrameworkCore;
using MvcRepositoryPatternDemo.Models;

namespace JWTAuthDemo.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<UserInfo>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserInfo> builder)
        {
            builder.ToTable("user_info");
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
