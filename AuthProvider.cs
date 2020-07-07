using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Identity.Client;
using Microsoft.Graph;
using System.Net.Http;
using System.Threading.Tasks;

namespace Commsverse.ProvisionTeams
{
    class AppOnlyAuthProvider : IAuthenticationProvider
    {
        public Task AuthenticateRequestAsync(HttpRequestMessage request)
        {

            var appConfidential = ConfidentialClientApplicationBuilder.Create(AppSettings.clientId)
                                  .WithClientSecret(AppSettings.clientSecret)
                                  .WithAuthority(AppSettings.tenantSpecificAuthority)
                                  .Build();

            string[] scopesDefault = new string[] { ".default" };

            var authResult = appConfidential.AcquireTokenForClient(scopesDefault).ExecuteAsync().Result;

            // insert access token into authorization header for each outbound request
            request.Headers.Add("Authorization", "Bearer " + authResult.AccessToken);

            return Task.CompletedTask;

        }
    }
}
