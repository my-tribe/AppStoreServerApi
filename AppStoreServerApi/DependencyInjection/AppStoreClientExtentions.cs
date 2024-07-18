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
            var jwtProvider = new AppStoreClientJwtProvider(
                options.PrivateKey,
                options.KeyId,
                options.IssuerId,
                options.BundleId);
            return new AppStoreClient(logger,
                options.HttpClientFactory,
                options.Environment,
                jwtProvider);
        });
    }

    public static IServiceCollection AddKeyedAppStoreClient(
        this IServiceCollection serviceCollection,
        string key,
        Action<AppStoreClientOptions> configureOptions)
    {
        return serviceCollection.AddKeyedSingleton<IAppStoreClient, AppStoreClient>(key, (sp, key) => {
            var httpClientFactory = sp.GetRequiredService<IHttpClientFactory>();
            var options = new AppStoreClientOptions(() => httpClientFactory.CreateClient());
            configureOptions(options);
            var logger = sp.GetRequiredService<ILoggerFactory>()
                .CreateLogger<AppStoreClient>();
            var jwtProvider = new AppStoreClientJwtProvider(
                options.PrivateKey,
                options.KeyId,
                options.IssuerId,
                options.BundleId);
            return new AppStoreClient(logger,
                options.HttpClientFactory,
                options.Environment,
                jwtProvider);
        });
    }
}