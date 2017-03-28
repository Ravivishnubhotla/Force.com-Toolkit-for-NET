using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salesforce.Common.Models
{
    public class CompositeResponse
    {
        private object _bodyValue = null;
        private CompositeResponseBody[] _arrCompositeBody = null;

        public object body {
            get
            {
                return _bodyValue;
            }

            set
            {
                _bodyValue = value;
                //Check object value type
                if (_bodyValue == null) _arrCompositeBody = null;
                if (_bodyValue != null && _bodyValue.GetType().Name.Equals("JArray")) _arrCompositeBody = Newtonsoft.Json.JsonConvert.DeserializeObject<CompositeResponseBody[]>(_bodyValue.ToString());
                if (_bodyValue != null && !_bodyValue.GetType().Name.Equals("JArray"))
                {
                    CompositeResponseBody _body1 = Newtonsoft.Json.JsonConvert.DeserializeObject<CompositeResponseBody>(_bodyValue.ToString());
                    _arrCompositeBody = new CompositeResponseBody[] { _body1 };                             
                }

            }
        }
        public CompositeResponseHttpHeaders httpHeaders { get; set; }
        public int httpStatusCode { get; set; }
        public string referenceId { get; set; }
        public CompositeResponseBody[] Results {
            get
            { return _arrCompositeBody; }
        }
    }
}
