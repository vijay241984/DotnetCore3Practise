using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Data
{
    public class Secrets : ISecrets
    {
        public string ADSecretKey   {get; private set;} 
        public string ADApplicationId { get; private set; }
        public string Value1Endpoint { get; private set; }
        public string Value2Endpoint { get; private set; }

        public Secrets(string adSecretKey, string adApplicationId, string value1Endpoint, string value2Endpoint)
        {
            ADSecretKey = adSecretKey;
            ADApplicationId = adApplicationId;
            Value1Endpoint = value1Endpoint;
            Value2Endpoint = value2Endpoint;
        }
    }
}
