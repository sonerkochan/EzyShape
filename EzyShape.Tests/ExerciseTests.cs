using EzyShape.Infrastructure.Data.Common;
using EzyShape.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using EzyShape.Core.Contracts;
using EzyShape.Core.Services;
using EzyShape.Core.Models.Exercises;
using EzyShape.Infrastructure.Data.Models;

namespace EzyShape.Tests
{
    public class ExerciseTests
    {
        private IRepository repo;
        private ApplicationDbContext context;

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("EzyShapeMemoryDb")
                .Options;

            context = new ApplicationDbContext(contextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        [Test]
        public async Task Test_AddExerciseAsync()
        {
            var repo = new Repository(context);

            IExerciseService exerciseService = new ExerciseService(repo);

            var model = new AddExerciseViewModel()
            {
                Name = "Bench Press",
                MuscleId = 1,
                CategoryId = 1,
                LevelId = 1,
                EquipmentId = 1
            };

            string trainerId = "123";

            await exerciseService.AddExerciseAsync(model, trainerId);

            var exercises = await repo.AllReadonly<Exercise>().ToListAsync();
            var lastExercise = await repo.AllReadonly<Exercise>().LastOrDefaultAsync();

            Assert.That(exercises.Count(), Is.EqualTo(1));
            Assert.That(lastExercise.Name, Is.EqualTo("Bench Press"));
        }


        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}