using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EzyShape.Infrastructure.Data.Models;

namespace SportArete.Infrastructure.Data.Configuration
{
    internal class RoleConfigration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(CreateRoles());
        }

        private List<IdentityRole> CreateRoles()
        {
            List<IdentityRole> roles = new List<IdentityRole>()
            {
                new IdentityRole()
                {
                    Id="d9de7285-b674-454c-9889-5210abb8d347",
                    Name="Trainer",
                    NormalizedName="TRAINER"
                },
                new IdentityRole()
                {
                    Id="07358494-247c-421c-8f7f-82c12be55276",
                    Name="Client",
                    NormalizedName="CLIENT"
                },
            };
            return roles;
        }
    }
}
