using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Salesforce.Common.Models
{ 
    public class CompositeResponseHttpHeaders
    {
        public string Location { get; set; }
        public string ETag { get; set; }
        [JsonProperty(PropertyName = "Last-Modified")]
        public string Last_Modified { get; set; }
}
}
