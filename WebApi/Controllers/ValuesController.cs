using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/Values")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
