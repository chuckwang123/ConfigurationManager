using ConfigurationManager.Interfaces;
using Microsoft.AspNetCore.Hosting.Internal;

namespace ConfigurationManager.Models
{
    public static class ApplicationPhysicalPathProvider : IApplicationPhysicalPathProvider
    {
        public string ApplicationPhysicalPath => HostingEnvironment.WebRootPath;
    }
}
