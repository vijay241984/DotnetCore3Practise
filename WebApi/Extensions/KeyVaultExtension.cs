using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.KeyVault;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using WebApi.Data;

namespace WebApi.Extensions
{
    public static class KeyVaultExtension
    {
        public static KeyVaultClient GetKeyVault(this ISecrets secrets)
        {
            var keyVault = new KeyVaultClient(
                async (string authority, string resource, string scope) =>
                {
                    var authContext = new AuthenticationContext(authority);
                    var credential = new ClientCredential(secrets.ADApplicationId, secrets.ADSecretKey);
                    var token = await authContext.AcquireTokenAsync(resource, credential);

                    return token.AccessToken;
                });

            return keyVault;
        }
    }
}
