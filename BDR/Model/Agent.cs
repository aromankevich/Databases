using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDR.Model
{
    public class Agent
    {
        public int id { get; set; }
        public string name { get; set; }
        public int salary { get; set; }

    }
}
