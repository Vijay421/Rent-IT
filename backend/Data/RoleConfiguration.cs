
// This code originates from: https://youtu.be/3VkMjpHGfy8?si=xRKe5RbxG7QQG56a&t=288
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Data
{
    public enum RoleName
    {
        ADMIN,
    }

    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public Dictionary<RoleName, string> RoleIds { get; set; }

        public RoleConfiguration()
        {
            RoleIds = new Dictionary<RoleName, string>();
        }

        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            IdentityRole adminRole = new IdentityRole
            {
                //Id = "admin-id",
                Id = Guid.NewGuid().ToString(), // TODO: figure out how this works.
                Name = "admin",
                NormalizedName = "ADMIN",
            };

            builder.HasData
            (
                /*new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "ADMIN",
                },*/
                adminRole
                /*new IdentityRole
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
                    Name = "zakelijke_huurder",
                    NormalizedName = "ZAKELIJKE_HUURDER",
                },
                new IdentityRole
                {
                    Name = "particuliere_huurder",
                    NormalizedName = "PARTICULIERE_HUURDER",
                }*/
            );

            RoleIds.Add(RoleName.ADMIN, adminRole.Id);
        }
    }
}
