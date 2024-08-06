using Microsoft.EntityFrameworkCore;
using Shopping.Data.Entities;

namespace Shopping.Data.Repos
{
    internal sealed class AisleRepository(IDbContextFactory<ShoppingDbContext> db) : IAisleRepository
    {
        public async Task<IEnumerable<Aisle>> GetAisles()
        {
            using var dbContext = await db.CreateDbContextAsync();

            return [.. dbContext.Aisles
                .Select(a => new Aisle
                {
                    AisleId = a.AisleId,
                    AisleName = a.AisleName,
                    Order = a.Order,
                })
                .OrderBy(b => b.Order)
                .ThenBy(b => b.AisleName)
            ];
        }

        public async Task<Aisle?> GetAisle(int aisleId)
        {
            using var dbContext = await db.CreateDbContextAsync();

            return dbContext.Aisles.FirstOrDefault(a => a.AisleId == aisleId);
        }

        public async Task<Aisle?> AddAisle(Aisle aisle)
        {
            using var dbContext = await db.CreateDbContextAsync();
            var addedEntity = dbContext.Aisles.Add(aisle);
            await dbContext.SaveChangesAsync();
            return addedEntity.Entity;
        }

        public async Task<Aisle?> UpdateAisle(Aisle aisle)
        {
            using var dbContext = await db.CreateDbContextAsync();

            var foundAisle = dbContext.Aisles.FirstOrDefault(b => b.AisleId == aisle.AisleId);

            if (foundAisle != null)
            {
                foundAisle.AisleName = aisle.AisleName;
                foundAisle.Order = aisle.Order;
                await dbContext.SaveChangesAsync();
                return foundAisle;
            }

            return null;
        }

        public async Task UpdateAisles(List<Aisle> aisles)
        {
            foreach(Aisle aisle in aisles)
            {
                _ = await UpdateAisle(aisle);
            }
        }

        public async Task DeleteAisle(int aisleId)
        {
            using var dbContext = await db.CreateDbContextAsync();
            var foundAisle = dbContext.Aisles.FirstOrDefault(a => a.AisleId == aisleId);
            if (foundAisle == null) return;

            dbContext.Aisles.Remove(foundAisle);
            await dbContext.SaveChangesAsync();
        }
    }
}