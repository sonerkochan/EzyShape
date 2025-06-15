using EzyShape.Infrastructure.Data.Common;
using EzyShape.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Moq;
using EzyShape.Core.Contracts;
using Microsoft.AspNetCore.Identity;
using EzyShape.Infrastructure.Data.Models;
using EzyShape.Core.Models.WeightLog;
using EzyShape.Core.Services;

namespace EzyShape.Tests
{
    public class ClientTests
    {
        private IRepository repo;
        private ApplicationDbContext context;
        private IClientService clientService;
        private IUtilityService utilityService;
        private Mock<UserManager<User>> userManagerMock;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("ClientDb")
                .Options;

            context = new ApplicationDbContext(options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            repo = new Repository(context);

            var userStoreMock = new Mock<IUserStore<User>>();
            userManagerMock = new Mock<UserManager<User>>(
                userStoreMock.Object, null, null, null, null, null, null, null, null);

            clientService = new ClientService(repo, userManagerMock.Object);
        }

        [Test]
        public async Task Test_GetClientById_ReturnsCorrectClient()
        {
            var user = new User
            {
                Id = "client123",
                UserName = "testuser",
                Email = "johnjohnson@example.com",
                FirstName = "John",
                LastName = "Johnson",
                // any other required properties, e.g. ColorCode, etc.
            };
            await repo.AddAsync(user);
            await repo.SaveChangesAsync();

            var result = await clientService.GetClientById("client123");

            Assert.IsNotNull(result);
            Assert.That(result.FirstName, Is.EqualTo("John"));
            Assert.That(result.LastName, Is.EqualTo("Johnson"));
            Assert.That(result.Email, Is.EqualTo("johnjohnson@example.com"));
        }

        [Test]
        public async Task Test_AddWeightAsync_AddsEntrySuccessfully()
        {
            var userId = "client456";

            var user = new User
            {
                Id = userId,
                UserName = "testuser",
                Email = "testuser@example.com",
                FirstName = "Test",
                LastName = "User",
                // any other required properties, e.g. ColorCode, etc.
            };
            await repo.AddAsync(user);
            await repo.SaveChangesAsync();
            var model = new AddWeightLogViewModel
            {
                UserId = userId,
                Weight = 70,
                LogDate = DateTime.Today
            };

            await clientService.AddWeightAsync(model, userId);

            var weightLogs = await repo.AllReadonly<WeightLog>().ToListAsync();
            Assert.That(weightLogs.Count, Is.EqualTo(1));
            Assert.That(weightLogs[0].Weight, Is.EqualTo(70));
        }

        [Test]
        public async Task Test_AddPhotoAsync_SavesPhotoCorrectly()
        {
            var clientId = "client789";

            await clientService.AddPhotoAsync("photo1.jpg", clientId);

            var photos = await repo.AllReadonly<Photo>().ToListAsync();
            Assert.That(photos.Count, Is.EqualTo(1));
            Assert.That(photos[0].FileName, Is.EqualTo("photo1.jpg"));
        }

        [Test]
        public async Task Test_ChangePreferredLanguageAsync_ChangesLanguage()
        {
            var user = new User
            {
                Id = "langClient",
                UserName = "testuser",
                Email = "testuser@example.com",
                FirstName = "Test",
                LastName = "User",
            };

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            await utilityService.ChangePreferredLanguageAsync(user.Id, "bg");

            var updatedUser = await repo.AllReadonly<User>()
                .FirstOrDefaultAsync(u => u.Id == "langClient");

            Assert.That(updatedUser.PreferredLanguage, Is.EqualTo("bg"));
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
            repo.Dispose();
        }
    }
}