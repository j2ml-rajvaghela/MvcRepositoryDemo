
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MvcRepositoryPatternDemo.Models;

namespace JWTAuthDemo.Seeder
{
    public class UserSeed : IEntityTypeConfiguration<UserInfo>
    {
        public void Configure(EntityTypeBuilder<UserInfo> builder)
        {
           builder.HasData(new UserInfo { UserId = 1, UserName = "admin", Password = "admin@1234"});
        }
    }
}
