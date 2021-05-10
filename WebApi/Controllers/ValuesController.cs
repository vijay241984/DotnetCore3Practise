using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.KeyVault;
using WebApi.Data;
using WebApi.Extensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/Values")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        //private readonly ISecrets _secrets;
        //public ValuesController(ISecrets secrets)
        //{
        //    _secrets = secrets;
        //}
        //// GET: api/<ValuesController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { _secrets.ADApplicationId, _secrets.ADSecretKey, _secrets.Value1Endpoint, _secrets.Value2Endpoint };
        //}

        string secret1;
        string secret2;
        
        public ValuesController(ISecrets secrets)
        {
            var keyvault = secrets.GetKeyVault();
            secret1 = KeyVaultClientExtensions.GetSecretAsync(keyvault, secrets.Value1Endpoint).Result.Value;
            secret2 = KeyVaultClientExtensions.GetSecretAsync(keyvault, secrets.Value2Endpoint).Result.Value;
        }
         
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { secret1, secret2 };
        }


        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            // 1st Task
            //if (Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["TestConfigKey"]) != null && Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["TestConfigKey"]) != "")

            //    return System.Configuration.ConfigurationManager.AppSettings["TestConfigKey"];
            //else
            //    return "TestConfigKey not exist";

            // 2nd Task
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://10.0.0.4/vijay.txt");

            WebResponse response = request.GetResponse();

            Stream dataStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(dataStream);

            string textFileContent = reader.ReadToEnd();

            return textFileContent;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
