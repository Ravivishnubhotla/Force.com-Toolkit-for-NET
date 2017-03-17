using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salesforce.Common.Models
{
    public class CompositeResponseBody
    {
        public string id { get; set; }
        public bool success { get; set; }
        public List<object> errors { get; set; }
    }
}
