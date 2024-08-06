using FluentValidation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Data.Entities
{
    public class Item
    {
        public int ItemId { get; set; }

        public int AisleId { get; set; } = -1;

        public string Name { get; set; } = string.Empty;

        public bool Listed { get; set; } = true;

        public int Quantity { get; set; } = 1;

        public Aisle Aisle { get; set; } = default!;

        [NotMapped]
        public string Label { get; set; } = string.Empty;

        [NotMapped]
        public int Order { get; set; }
    }

    public class ItemValidator : AbstractValidator<Item>
    {
        public ItemValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(25);
            RuleFor(x => x.Quantity).GreaterThan(0);
        }

        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<Item>.CreateWithOptions((Item)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid) return [];
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }

}
