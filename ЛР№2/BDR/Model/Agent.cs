using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDR.Model
{
    public class Agent : BaseModel<Agent>
    {
        public int id { get; set; }
        public string name { get; set; }
        public int salary { get; set; }

        public override void Update(string sqlString)
        {
            base.Update("update agent " + sqlString);
        }
        public override void Create(Agent entity)
        {
            string sqlInsert = "Insert into agent(name, salary) VALUES(@name, @salary)";
            sqlConnection.Open();

            using var cmd = new NpgsqlCommand(sqlInsert, sqlConnection);
            cmd.Parameters.AddWithValue("name", entity.name);
            cmd.Parameters.AddWithValue("salary", entity.salary);
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
            base.Delete("delete from agent where id = " + id);
        }

        public override Agent Find(int id)
        {
            throw new NotImplementedException();
        }

        public override Agent Find(string findString)
        {
            return Read(findString).FirstOrDefault();
        }

        public override void Generate(int recordsAmount)
        {
            string sqlGenerate = "insert into agent(name, salary)" +
                $"(select {sqlRandomString}, {sqlRandomInteger} " +
                $" from generate_series(1, {recordsAmount}))";

            base.Generate(sqlGenerate);
        }

        public override IEnumerable<Agent> Read()
        {
            return Read("");
        }

        public IEnumerable<Agent> Read(string whereCondition)
        {
            sqlConnection.Open();

            string sqlSelect = "select id, name, salary from agent";


            using var cmd = new NpgsqlCommand(sqlSelect + whereCondition, sqlConnection);
            List<Agent> list = new List<Agent>();
            try
            {
                using NpgsqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var entity = new Agent();
                    entity.id = rdr.GetInt32(0);
                    entity.name = rdr.GetString(1);
                    entity.salary = rdr.GetInt32(2);
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
