using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dtos
{
    public class CommandReadDto
    {
        public int id { get; set; }
        public string HowTo { get; set; }
        public string Line { get; set; }
         
    }
}
