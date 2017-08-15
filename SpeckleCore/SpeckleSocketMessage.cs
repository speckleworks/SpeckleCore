using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeckleCore
{
    [Serializable]
    public class SpeckleSocketMessage
    {
        public string EventName { get; set; }
        public string EventPayload { get; set; }

        public string Message
        {
            get { return JsonConvert.SerializeObject(this); }
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
