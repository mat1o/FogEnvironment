using Microsoft.Extensions.Configuration;

namespace FogEnvironment.Utilities
{
    public class AppSettings
    {
        public AppSettings()
        {
            var builder = new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("appsettings.json", optional: false);

            IConfiguration config = builder.Build();

            FogEnvironmentModel = config.GetSection("FogEnvironment").Get<FogEnvironmentModel>();

        }

        public FogEnvironmentModel FogEnvironmentModel { get; private set; }
    }
}
