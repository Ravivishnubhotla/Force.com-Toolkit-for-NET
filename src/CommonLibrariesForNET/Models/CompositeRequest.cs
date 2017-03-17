using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salesforce.Common.Models
{
    public class CompositeRequest
    {
        public string method { get; set; }
        public string url { get; set; }
        public string referenceId { get; set; }
        public object body { get; set; }        
    }
}