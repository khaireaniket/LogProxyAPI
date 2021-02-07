using System;

namespace LogProxyAPI.Infrastructure
{
    public interface IUserService
    {
        bool ValidateCredentials(String username, String password);
    }
}
