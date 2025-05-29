using EzyShape.Infrastructure.Data.Common;
using EzyShape.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EzyShape.Tests
{
    public class BlankTests
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


        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}