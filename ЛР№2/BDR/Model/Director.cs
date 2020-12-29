using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDR.Model
{
    public class Director : BaseModel<Director>
    {
        public int id { get; set; }
        public string name { get; set; }
        public string tel_number { get; set; }

        public override void Update(string sqlString)
        {
            base.Update("update director " + sqlString);
        }
        public override void Create(Director entity)
        {
            string sqlInsert = "Insert into director(name, tel_number) VALUES(@name, @tel_number)";
            sqlConnection.Open();

            using var cmd = new NpgsqlCommand(sqlInsert, sqlConnection);
            cmd.Parameters.AddWithValue("name", entity.name);
            cmd.Parameters.AddWithValue("tel_number", entity.tel_number);
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
            base.Delete("delete from director where id = " + id);
        }

        public override Director Find(int id)
        {
            throw new NotImplementedException();
        }

        public override Director Find(string findString)
        {
            return Read(findString).FirstOrDefault();
        }

        public override void Generate(int recordsAmount)
        {
            string sqlGenerate = "insert into director(name, tel_number)" +
                $"(select {sqlRandomString}, {sqlRandomString} " +
                $" from generate_series(1, {recordsAmount}))";

            base.Generate(sqlGenerate);
        }

        public override IEnumerable<Director> Read()
        {
            return Read("");
        }

        public IEnumerable<Director> Read(string whereCondition)
        {
            sqlConnection.Open();

            string sqlSelect = "select id, name, tel_number from director";


            using var cmd = new NpgsqlCommand(sqlSelect + whereCondition, sqlConnection);
            List<Director> list = new List<Director>();
            try
            {
                using NpgsqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var entity = new Director();
                    entity.id = rdr.GetInt32(0);
                    entity.name = rdr.GetString(1);
                    entity.tel_number = rdr.GetString(2);
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
