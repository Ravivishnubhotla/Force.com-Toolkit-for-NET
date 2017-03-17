using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salesforce.Common.Models
{
    public class CompositeRequestRoot
    {
        public bool allOrNone { get; set; }
        public List<CompositeRequest> compositeRequest { get; set; }
    }
}
