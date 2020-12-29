using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDR.Model
{
    public class Film : BaseModel<Film>
    {
        public int id { get; set; }
        public string name { get; set; }
        public int director { get; set; }
        public int budget { get; set; }

        public override void Update(string sqlString)
        {
            base.Update("update film " + sqlString);
        }
        public override void Create(Film entity)
        {
            string sqlInsert = "Insert into film(name, director, budget) VALUES(@name, @director, @budget)";
            sqlConnection.Open();

            using var cmd = new NpgsqlCommand(sqlInsert, sqlConnection);
            cmd.Parameters.AddWithValue("name", entity.name);
            cmd.Parameters.AddWithValue("director", entity.director);
            cmd.Parameters.AddWithValue("budget", entity.budget);
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
            base.Delete("delete from film where id = " + id);
        }

        public override Film Find(int id)
        {
            throw new NotImplementedException();
        }

        public override Film Find(string findString)
        {
            return Read(findString).FirstOrDefault();
        }

        public override void Generate(int recordsAmount)
        {
            string sqlGenerate = "insert into film(name, director, budget)" +
                $"(select {sqlRandomString}, director.id, {sqlRandomInteger} " +
                $" from generate_series(1, {recordsAmount}), director limit({recordsAmount}))";

            base.Generate(sqlGenerate);
        }

        public override IEnumerable<Film> Read()
        {
            return Read("");
        }

        public IEnumerable<Film> Read(string whereCondition)
        {
            sqlConnection.Open();

            string sqlSelect = "select id, name, director, budget from film";


            using var cmd = new NpgsqlCommand(sqlSelect + whereCondition, sqlConnection);
            List<Film> list = new List<Film>();
            try
            {
                using NpgsqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var entity = new Film();
                    entity.id = rdr.GetInt32(0);
                    entity.name = rdr.GetString(1);
                    entity.director = rdr.GetInt32(2);
                    entity.budget = rdr.GetInt32(3);
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
