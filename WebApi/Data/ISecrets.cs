using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Data
{
    public interface ISecrets
    {
        string ADSecretKey { get; }        
        string ADApplicationId { get; }
        string Value1Endpoint { get; }
        string Value2Endpoint { get; }  
    }
}
