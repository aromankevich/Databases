using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDR.Model
{
    public class Director 
    {
        public int id { get; set; }
        public string name { get; set; }
        public string tel_number { get; set; }
    }
}
