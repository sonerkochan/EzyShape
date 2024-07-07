using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EzyShape.Infrastructure.Data.Models;

namespace EzyShape.Infrastructure.Data.Configuration
{
    internal class EquipmentConfiguration : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.HasData(CreateEquipment());
        }

        private List<Equipment> CreateEquipment()
        {
            return new List<Equipment>
            {
                new Equipment { Id = 1, Name = "No Equipment" },
                new Equipment { Id = 2, Name = "Dumbbells" },
                new Equipment { Id = 3, Name = "Barbell" },
                new Equipment { Id = 4, Name = "Kettlebells" },
                new Equipment { Id = 5, Name = "Treadmill" },
                new Equipment { Id = 6, Name = "Elliptical" },
                new Equipment { Id = 7, Name = "Rowing Machine" },
                new Equipment { Id = 8, Name = "Resistance Bands" },
                new Equipment { Id = 9, Name = "Bench Press" },
                new Equipment { Id = 10, Name = "Pull-up Bar" },
                new Equipment { Id = 11, Name = "Medicine Ball" },
                new Equipment { Id = 12, Name = "Foam Roller" },
                new Equipment { Id = 13, Name = "Exercise Mat" },
                new Equipment { Id = 14, Name = "Stationary Bike" },
                new Equipment { Id = 15, Name = "Leg Press Machine" },
                new Equipment { Id = 16, Name = "Cable Machine" },
                new Equipment { Id = 17, Name = "Smith Machine" },
                new Equipment { Id = 18, Name = "Stability Ball" },
                new Equipment { Id = 19, Name = "Jump Rope" }
            };
        }
    }
}