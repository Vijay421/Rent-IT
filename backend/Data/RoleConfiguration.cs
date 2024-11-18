
// This code originates from: https://youtu.be/3VkMjpHGfy8?si=xRKe5RbxG7QQG56a&t=288
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Data
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData
            (
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(), // This originates from: https://learn.microsoft.com/en-us/dotnet/api/system.guid.newguid?view=net-8.0
                    Name = "admin",
                    NormalizedName = "ADMIN",
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "backoffice_medewerker",
                    NormalizedName = "BACKOFFICE_MEDEWERKER",
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "frontoffice_medewerker",
                    NormalizedName = "FRONTOFFICE_MEDEWERKER",
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "zakelijke_huurder",
                    NormalizedName = "ZAKELIJKE_HUURDER",
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "particuliere_huurder",
                    NormalizedName = "PARTICULIERE_HUURDER",
                }
            );
        }
    }
}
