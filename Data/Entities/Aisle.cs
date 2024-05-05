namespace Shopping.Data.Entities
{
    public class Aisle
    {
        public int AisleId { get; set; }

        public string AisleName { get; set; } = string.Empty;

        public int Order { get; set; } = 1;

        public List<Item> Items { get; set; } = [];
    }
}