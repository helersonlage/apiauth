
namespace apiauth.Repositories
{
    /// <summary>
    /// Secret Key Repositories
    /// </summary>
    public class Settings : ISettings
    {
        protected readonly IConfiguration _configuration;

        /// <summary>
        /// Dependency Injection Construtor
        /// </summary>        
        public Settings(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Get SecretKey from app settings 
        /// </summary>
        /// <returns>Secret Key string</returns>
        public string GetSecretKey()
        {
            string SecretKey = _configuration.GetSection("AppSettings:SecretJWTKey").Value;

            if (string.IsNullOrWhiteSpace(SecretKey)) throw new Exception("JWT Secret Key not found. Please Check App Settings");

            return SecretKey;
        }

    }
}
