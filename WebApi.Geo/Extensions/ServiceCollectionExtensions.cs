using WebApi.Geo.Services;
using WebApi.Geo.Storage;


namespace WebApi.Geo.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGeoServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<CountryService>();
            serviceCollection.AddTransient<CityService>();
            serviceCollection.AddDbContext<GeoDbContext, GeoDbContext>();
            return serviceCollection;
        }
    }
}
