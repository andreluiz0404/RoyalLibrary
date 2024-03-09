using RoyalLibrary.Infra.Abstractions;

namespace RoyalLibrary.Helpers
{
    public static class SeedDatabase
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var dbContext = serviceProvider.GetRequiredService<IRoyalLibraryDbContext>();
            BookSeeder.Seed(dbContext);
        }
    }
}