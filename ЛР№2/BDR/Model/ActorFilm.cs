using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDR.Model
{
    public class ActorFilm : BaseModel<ActorFilm>
    {
        public int id { get; set; }
        public int actor_id { get; set;}
        public int film_id { get; set; }


        public override void Update(string sqlString)
        {
            base.Update("update actor_film " + sqlString);
        }
        public override void Create(ActorFilm entity)
        {
            string sqlInsert = "Insert into actor_film(actor_id, film_id) VALUES(@actor_id, @film_id)";
            sqlConnection.Open();

            using var cmd = new NpgsqlCommand(sqlInsert, sqlConnection);
            cmd.Parameters.AddWithValue("actor_id", entity.actor_id);
            cmd.Parameters.AddWithValue("film_id", entity.film_id);
            cmd.Prepare();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public override void Delete(int id)
        {
            base.Delete("delete from actor_film where id = " + id);
        }

        public override ActorFilm Find(int id)
        {
            throw new NotImplementedException();
        }

        public override ActorFilm Find(string findString)
        {
            return Read(findString).FirstOrDefault();
        }

        public override void Generate(int recordsAmount)
        {
            string sqlGenerate = "insert into actor_film(actor_id, film_id)" +
                $"(select actor.id, film.id " +
                $" from actor, film limit({recordsAmount}))";

            base.Generate(sqlGenerate);
        }

        public override IEnumerable<ActorFilm> Read()
        {
            return Read("");
        }

        private IEnumerable<ActorFilm> Read(string whereCondition)
        {
            sqlConnection.Open();

            string sqlSelect = "select id, actor_id, film_id from actor_film ";


            using var cmd = new NpgsqlCommand(sqlSelect + whereCondition, sqlConnection);
            List<ActorFilm> list = new List<ActorFilm>();
            try
            {
                using NpgsqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var entity = new ActorFilm();
                    entity.id = rdr.GetInt32(0);
                    entity.actor_id = rdr.GetInt32(1);
                    entity.film_id = rdr.GetInt32(2);
                    list.Add(entity);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            finally
            {
                sqlConnection.Close();
            }

            return list;
        }
    }
}
