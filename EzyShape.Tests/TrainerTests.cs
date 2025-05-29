using EzyShape.Infrastructure.Data.Common;
using EzyShape.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using EzyShape.Core.Contracts;
using EzyShape.Core.Services;
using EzyShape.Core.Models.Exercises;
using EzyShape.Infrastructure.Data.Models;
using EzyShape.Web.ViewModels;

namespace EzyShape.Tests
{
    public class TrainerTests
    {
        private IRepository repo;
        private ApplicationDbContext context;
        private ITaskService taskService;
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()) // уникална база за всеки тест
                .Options;

            context = new ApplicationDbContext(options);
            context.Database.EnsureCreated();

            repo = new Repository(context);
            taskService = new TaskService(repo, context);
        }

        [Test]
        public async Task Test_AddTaskAsync_AddsTaskCorrectly()
        {
            var model = new AddTaskViewModel
            {
                Name = "Test Task",
                Description = "Test Description",
                DueDate = DateTime.Today.AddDays(7)
            };
            var trainerId = "trainer-123";

            await taskService.AddTaskAsync(model, trainerId);

            var taskInDb = await repo.AllReadonly<TrainingTask>().FirstOrDefaultAsync();

            Assert.That(taskInDb, Is.Not.Null);
            Assert.That(taskInDb.Name, Is.EqualTo("Test Task"));
            Assert.That(taskInDb.UserId, Is.EqualTo(trainerId));
            Assert.That(taskInDb.Status, Is.False);
            Assert.That(taskInDb.CompletedDate, Is.Null);
        }

        [Test]
        public async Task Test_GetTrainersAllTasks_ReturnsOnlyTrainersTasks()
        {
            var trainerId = "trainer-456";
            var otherTrainerId = "trainer-789";

            await repo.AddAsync(new TrainingTask
            {
                Name = "Task 1",
                Description = "Description 1",
                UserId = trainerId,
                DueDate = DateTime.Today.AddDays(2)
            });

            await repo.AddAsync(new TrainingTask
            {
                Name = "Task 2",
                Description = "Description 2",
                UserId = trainerId,
                DueDate = DateTime.Today.AddDays(3)
            });

            await repo.AddAsync(new TrainingTask
            {
                Name = "Task 3",
                Description = "Other Trainer Task",
                UserId = otherTrainerId,
                DueDate = DateTime.Today.AddDays(4)
            });

            await repo.SaveChangesAsync();

            var tasks = await taskService.GetTrainersAllTasks(trainerId);

            Assert.That(tasks.Count(), Is.EqualTo(2));
            Assert.That(tasks.Any(t => t.Name == "Task 1"), Is.True);
            Assert.That(tasks.Any(t => t.Name == "Task 2"), Is.True);
            Assert.That(tasks.Any(t => t.Name == "Task 3"), Is.False);
        }


        [Test]
        public async Task Test_GetTaskByIdAsync_ReturnsCorrectTask()
        {
            var task = new TrainingTask
            {
                Name = "Specific Task",
                Description = "Test Description",
                UserId = "trainer-xyz",
                DueDate = DateTime.Today
            };

            await repo.AddAsync(task);
            await repo.SaveChangesAsync();

            var retrieved = await taskService.GetTaskByIdAsync(task.Id);

            Assert.That(retrieved, Is.Not.Null);
            Assert.That(retrieved.Name, Is.EqualTo("Specific Task"));
        }


        [Test]
        public async Task Test_UpdateTaskAsync_UpdatesFields()
        {
            var task = new TrainingTask
            {
                Name = "Old Name",
                Description = "Old Description",
                UserId = "trainer-999",
                DueDate = DateTime.Today.AddDays(5)
            };

            await repo.AddAsync(task);
            await repo.SaveChangesAsync();

            // Act: update fields
            task.Name = "Updated Name";
            task.Description = "Updated Description";
            await taskService.UpdateTaskAsync(task);

            // Assert
            var updatedTask = await repo.AllReadonly<TrainingTask>()
                .Where(t => t.Id == task.Id)
                .FirstOrDefaultAsync();

            Assert.That(updatedTask.Name, Is.EqualTo("Updated Name"));
            Assert.That(updatedTask.Description, Is.EqualTo("Updated Description"));
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
            repo.Dispose();
        }
    }
}