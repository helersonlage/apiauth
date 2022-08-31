namespace apiauth.Repositories
{
    public class Settings : ISettings
    {
       /// <summary>
       /// private readonly IConfiguration _config;
       /// </summary>
       /// <returns></returns>
       // public Settings(IConfiguration config) { _config = config; }
       // public Settings() { }

        public string GetSecretKey()
        {
            // Secret Key 
            return "HeleRsOnT21pZC1NaXJ6YWVpWhithOutStar*";
        }

    }
}
