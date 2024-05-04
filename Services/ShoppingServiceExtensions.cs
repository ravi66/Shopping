using Shopping.Data;
using Shopping.Data.Repos;

namespace Shopping.Services
{
    public static class ShoppingServiceExtensions
    {
        public static IServiceCollection AddShoppingServices(this IServiceCollection services)
        {
            /*
             * Although AddScoped is used as app is entirely client side they are actually Singletons
             */
            services.AddScoped<DbUtils>();
            services.AddScoped<IAisleRepository, AisleRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();

            services.AddSingleton<IMauiDialogSvc, MauiDialogSvc>();

            return services;
        }
    }
}