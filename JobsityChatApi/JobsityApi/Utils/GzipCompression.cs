using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;

namespace JobsityApi.Utils;

public static class GzipCompression
{
    public static IServiceCollection RegisterGzipCompression(this IServiceCollection services)
    {
        services
            .Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Optimal)
            .AddResponseCompression();

        return services;
    }
}
