using Microsoft.Extensions.Configuration;

namespace LogProxyAPI.Infrastructure
{
    public class UserService : IUserService
    {
        private IConfiguration _configuration { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration"></param>
        public UserService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Method to validate credentials
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool ValidateCredentials(string username, string password)
        {
            // Temporary UserName and Password stored in appsettings.json 
            string storedUserName = _configuration["StoredUserName"];
            string storedPassword = _configuration["StoredPassword"];

            return username.Equals(storedUserName) && password.Equals(storedPassword);
        }
    }
}
