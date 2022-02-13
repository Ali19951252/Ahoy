using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectCommons.CosmosCommon.CosmosRepository;

namespace ProjectCommons.CosmosCommon.CosmosRegistration
{
    public static class CosmosDbRegistrations
    {
        public static IServiceCollection AddCosmosDbServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetValue<string>("CosmosDb:ConnectionString");



            services.AddSingleton(_ =>
            {
                var cosmosClient = new CosmosClient(connectionString);
                return cosmosClient;
            });

            services.AddSingleton(p =>
            {
                var cosmosClient = p.GetService<CosmosClient>();
                var SettingContainer = cosmosClient.GetContainer(configuration.GetValue<string>("CosmosDb:DataBaseName"),
                   configuration.GetValue<string>("CosmosDb:Hotel"));
                var systemdefineRepository = new ICosmosRepository(SettingContainer);
                return systemdefineRepository;
            });

            

            return services;
        }
    }
}
