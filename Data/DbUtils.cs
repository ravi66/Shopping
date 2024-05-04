using Microsoft.EntityFrameworkCore;

namespace Shopping.Data
{
    internal class DbUtils(IDbContextFactory<ShoppingDbContext> db)
    {
        internal async Task EnsureDbCreated()
        {
            using var dbContext = await db.CreateDbContextAsync();
            await dbContext.Database.EnsureCreatedAsync();
            await dbContext.SaveChangesAsync();
        }

        internal async Task EnsureDbDeleted()
        {
            using var dbContext = await db.CreateDbContextAsync();
            await dbContext.Database.EnsureDeletedAsync();
            await dbContext.SaveChangesAsync();
        }
    }
}