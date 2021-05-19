using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Encryption.Areas.Identity.IdentityHostingStartup))]
namespace Encryption.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}