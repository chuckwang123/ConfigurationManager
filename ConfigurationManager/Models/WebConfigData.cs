using System.Collections.Generic;

namespace ConfigurationManager.Models
{
    public class WebConfigData
    {
        public List<ConnectionString> ConnectionStrings { get; set; }
        public IPLAuth IPLAuth { get; set; }
    }
}
