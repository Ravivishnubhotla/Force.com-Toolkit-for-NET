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

        public object body {
            get
            {
                return _bodyValue;
            }

            set
            {
                _bodyValue = value;
                //Check object value type
                if (_bodyValue == null) Results = null;
                if (_bodyValue != null && _bodyValue.GetType().Name.Equals("JArray")) Results = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CompositeResponseBody>>(_bodyValue.ToString());
                if (_bodyValue != null && !_bodyValue.GetType().Name.Equals("JArray"))
                {
                    CompositeResponseBody _body1 = Newtonsoft.Json.JsonConvert.DeserializeObject<CompositeResponseBody>(_bodyValue.ToString());
                    Results = new List<CompositeResponseBody>();
                    Results.Add(_body1);                   
                }

            }
        }
        public CompositeResponseHttpHeaders httpHeaders { get; set; }
        public int httpStatusCode { get; set; }
        public string referenceId { get; set; }
        public List<CompositeResponseBody> Results { get; set; }
    }
}
