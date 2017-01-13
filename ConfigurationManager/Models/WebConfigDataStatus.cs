using System.Collections.Generic;

namespace ConfigurationManager.Models
{
    public class WebConfigDataStatus
    {
        public bool ApiKeySecret { get; set; }
        public List<string> ErrConnectionStrings { get; set; }
    }
}
