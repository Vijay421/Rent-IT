
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
                    Name = "admin",
                    NormalizedName = "ADMIN",
                },
                new IdentityRole
                {
                    Name = "backoffice_medewerker",
                    NormalizedName = "BACKOFFICE_MEDEWERKER",
                },
                new IdentityRole
                {
                    Name = "frontoffice_medewerker",
                    NormalizedName = "FRONTOFFICE_MEDEWERKER",
                },
                new IdentityRole
                {
                    Name = "zakelijke_beheerder",
                    NormalizedName = "ZAKELIJKE_BEHEERDER",
                },
                new IdentityRole
                {
                    Name = "zakelijke_huurder",
                    NormalizedName = "ZAKELIJKE_HUURDER",
                },
                new IdentityRole
                {
                    Name = "particuliere_huurder",
                    NormalizedName = "PARTICULIERE_HUURDER",
                }
            );
        }
    }
}
