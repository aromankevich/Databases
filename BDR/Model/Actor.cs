using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDR.Model
{
    public class Actor : BaseModel<Actor>
    {
        public int id { get; set; }
        public string name { get; set; }
        public int agent { get; set; } // nullable

        public override void Update(string sqlString)
        {
            base.Update("update actor " + sqlString);
        }
        public override void Create(Actor entity)
        {
            string sqlInsert = "Insert into actor(name, agent) VALUES(@name, @agent)";
            sqlConnection.Open();

            using var cmd = new NpgsqlCommand(sqlInsert, sqlConnection);
            cmd.Parameters.AddWithValue("name", entity.name);
            cmd.Parameters.AddWithValue("agent", entity.agent);
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
            base.Delete("delete from actor where id = " + id);
        }

        public override Actor Find(int id)
        {
            throw new NotImplementedException();
        }

        public override Actor Find(string findString)
        {
            return Read(findString).FirstOrDefault();
        }

        public override void Generate(int recordsAmount)
        {
            string sqlGenerate = "insert into actor(name, agent)" +
                $"(select {sqlRandomString}, agent.id " +
                $" from generate_series(1, {recordsAmount}), agent limit({recordsAmount}))";

            base.Generate(sqlGenerate);
        }

        public override IEnumerable<Actor> Read()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Actor> Read(string whereCondition)
        {
            sqlConnection.Open();

            string sqlSelect = "select id, name from actor";


            using var cmd = new NpgsqlCommand(sqlSelect + whereCondition, sqlConnection);
            List<Actor> list = new List<Actor>();
            try
            {
                using NpgsqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var entity = new Actor();
                    entity.id = rdr.GetInt32(0);
                    entity.name = rdr.GetString(1);
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
