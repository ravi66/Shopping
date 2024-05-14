using Microsoft.EntityFrameworkCore;
using Shopping.Data.Entities;

namespace Shopping.Data.Repos
{
    internal sealed class ItemRepository(IDbContextFactory<ShoppingDbContext> db) : IItemRepository
    {
        public async Task<IEnumerable<Item>> GetListedItems()
        {
            using var dbContext = await db.CreateDbContextAsync();

            return [.. dbContext.Items
                .Where(i => i.Listed == true)
                .Select(i => new Item
                {
                    ItemId = i.ItemId,
                    AisleId = i.AisleId,
                    Listed = i.Listed,
                    Name = i.Name,
                    Quantity = i.Quantity,
                    Label = i.Quantity > 1 ? $"{i.Name} ({i.Quantity})" : i.Name,
                    Order = i.Aisle.Order,
                })
                .OrderBy(i => i.Order)
                .ThenBy(i => i.Name)
            ];
        }

        public async Task<IEnumerable<Item>> GetUnlistedItems()
        {
            using var dbContext = await db.CreateDbContextAsync();

            return [.. dbContext.Items
                .Where(i => i.Listed == false)
                .Select(i => new Item
                {
                    ItemId = i.ItemId,
                    AisleId = i.AisleId,
                    Name = i.Name,
                    Listed = i.Listed,
                    Quantity = i.Quantity,
                    Label = i.Quantity > 1 ? $"{i.Name} ({i.Quantity})" : i.Name,
                })
                .OrderBy(i => i.Name)
            ];
        }

        public async Task<Item?> GetItem(int itemId)
        {
            using var dbContext = await db.CreateDbContextAsync();

            return dbContext.Items.FirstOrDefault(i => i.ItemId == itemId);
        }

        public async Task<Item?> AddItem(Item item)
        {
            using var dbContext = await db.CreateDbContextAsync();
            var addedEntity = dbContext.Items.Add(item);
            await dbContext.SaveChangesAsync();
            return addedEntity.Entity;
        }

        public async Task<Item?> UpdateItem(Item item)
        {
            using var dbContext = await db.CreateDbContextAsync();

            var foundItem = dbContext.Items.FirstOrDefault(b => b.ItemId == item.ItemId);

            if (foundItem != null)
            {
                foundItem.AisleId = item.AisleId;
                foundItem.Name = item.Name;
                foundItem.Quantity = item.Quantity;
                foundItem.Listed = item.Listed;
                await dbContext.SaveChangesAsync();
                return foundItem;
            }

            return null;
        }

        public async Task UnsetAisle(int aisleId)
        {
            using var dbContext = await db.CreateDbContextAsync();

            foreach (Item item in dbContext.Items.Where(i => i.AisleId == aisleId))
            {
                item.AisleId = -1;
            }

            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteItem(int itemId)
        {
            using var dbContext = await db.CreateDbContextAsync();
            var foundItem = dbContext.Items.FirstOrDefault(i => i.ItemId == itemId);
            if (foundItem == null) return;

            dbContext.Items.Remove(foundItem);
            await dbContext.SaveChangesAsync();
        }
    }
}