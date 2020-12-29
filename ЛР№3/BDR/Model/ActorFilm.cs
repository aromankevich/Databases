using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDR.Model
{
    public class ActorFilm
    {
        public int id { get; set; }
        public int actor_id { get; set;}
        public int film_id { get; set; }


    }
}
