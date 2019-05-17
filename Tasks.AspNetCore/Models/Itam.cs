using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tasks.AspNetCore.Models
{
    public class Itam
    {
        public Guid Id { get; set; } 
        public string Title { get; set; }
        public bool Compleated { get; set; } 
    }
}
