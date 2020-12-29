using BDR.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BDR.Controller
{
    public class Controller<T> where T: BaseModel<T>
    {
        T entity;
        public Controller(T entity)
        {
            this.entity = entity;
        }
        public void Create(T entity)
        {
            entity.Create(entity);
        }

        public void Delete(int id)
        {
            entity.Delete(id);
        }

        public T Find(string whereString)
        {
            return entity.Find(whereString);
        }
        public T Find(int id)
        {
            return entity.Find(id);
        }
        public void Generate(int recordsAmount)
        {
            entity.Generate(recordsAmount);
        }

        public IEnumerable<T> Read()
        {
            return entity.Read();
        }
        public void Update(string updateString)
        {
            entity.Update(updateString);
        }
        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
