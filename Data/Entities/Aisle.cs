using FluentValidation;
using System.Xml.Linq;

namespace Shopping.Data.Entities
{
    public class Aisle
    {
        public int AisleId { get; set; }

        public string AisleName { get; set; } = string.Empty;

        public int Order { get; set; } = 1;

        public List<Item> Items { get; set; } = [];
    }

    public class AisleValidator : AbstractValidator<Aisle>
    {
        public AisleValidator()
        {
            RuleFor(x => x.AisleName).NotEmpty().MaximumLength(25);
            RuleFor(x => x.Order).GreaterThan(0);
        }

        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<Aisle>.CreateWithOptions((Aisle)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid) return [];
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
