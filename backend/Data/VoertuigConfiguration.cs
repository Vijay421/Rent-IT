using backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Data
{
    public class VoertuigConfiguration : IEntityTypeConfiguration<Voertuig>
    {
        public void Configure(EntityTypeBuilder<Voertuig> builder)
        {
            builder.HasData
            (

            );
        }
    }
}