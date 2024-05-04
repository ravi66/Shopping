using Shopping.Data.Entities;

namespace Shopping.Data.Repos
{
    interface IAisleRepository
    {
        public Task<IEnumerable<Aisle>> GetAisles();
        public Task<Aisle?> GetAisle(int aisleId);
        public Task<Aisle?> AddAisle(Aisle aisle);
        public Task<Aisle?> UpdateAisle(Aisle aisle);
        public Task UpdateAisles(List<Aisle> aisles);
        public Task DeleteAisle(int aisleId);
    }
}
