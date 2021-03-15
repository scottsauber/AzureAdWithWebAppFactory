using AadWebAppFactoryExample.Api;
using AadWebAppFactoryExample.Api.Constants;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

namespace AadWebAppFactoryExample.Tests.Helpers
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>(
                        JwtBearerDefaults.AuthenticationScheme, options => { });
            });
            builder.UseEnvironment(EnvironmentNames.IntegrationTests);
        }
    }
}
