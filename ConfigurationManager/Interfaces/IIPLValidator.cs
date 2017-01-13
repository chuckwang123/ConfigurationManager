using System.Threading.Tasks;
using ConfigurationManager.Models;
using Microsoft.Extensions.Options;

namespace ConfigurationManager.Interfaces
{
    public interface IIPLValidator
    {
        Task ValidateIPLAuthentication(IPLAuth auth, IOptions<IPLAuth> appSettings);
    }
}
