using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salesforce.Common.Models
{
    public class CompositeResponse
    {
        public CompositeResponseBody body { get; set; }
        public CompositeResponseHttpHeaders httpHeaders { get; set; }
        public int httpStatusCode { get; set; }
        public string referenceId { get; set; }
    }
}
