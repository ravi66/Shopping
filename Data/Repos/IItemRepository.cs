using Shopping.Data.Entities;

namespace Shopping.Data.Repos
{
    interface IItemRepository
    {
        public Task<IEnumerable<Item>> GetListedItems();
        public Task<IEnumerable<Item>> GetUnlistedItems();
        public Task<Item?> GetItem(int itemId);
        public Task<Item?> AddItem(Item item);
        public Task<Item?> UpdateItem(Item item);
        public Task UnsetAisle(int aisleId);
        public Task DeleteItem(int itemId);
    }
}