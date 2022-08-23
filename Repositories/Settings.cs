using Microsoft.Extensions.Configuration;

namespace apiauth.Repositories
{
    public class Settings : ISettings
    {
        //private readonly IConfiguration _config;

        //public Settings(IConfiguration config) { _config = config; }

        // public Settings() { }

        public string GetSecretKey()
        {
            ///new Configuration().

            return "HeleRsOnT21pZC1NaXJ6YWVpWhithOutStar*";
                //_config.GetSection("AppSettings:Token").Value ?? string.Empty;

        }

    }
}
