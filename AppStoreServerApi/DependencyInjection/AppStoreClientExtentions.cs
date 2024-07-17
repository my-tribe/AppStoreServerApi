using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AppStoreServerApi.DependencyInjection;

public static class AppStoreClientExtentions
{
    public static IServiceCollection AddAppStoreClient(
        this IServiceCollection serviceCollection,
        Action<AppStoreClientOptions> configureOptions)
    {
        return serviceCollection.AddSingleton<IAppStoreClient, AppStoreClient>(sp => {
            var httpClientFactory = sp.GetRequiredService<IHttpClientFactory>();
            var options = new AppStoreClientOptions(() => httpClientFactory.CreateClient());
            configureOptions(options);
            var logger = sp.GetRequiredService<ILoggerFactory>()
                .CreateLogger<AppStoreClient>();
            return new AppStoreClient(logger,
                options.HttpClientFactory,
                options.Environment,
                options.PrivateKey,
                options.KeyId,
                options.IssuerId,
                options.BundleId);
        });
    }
}