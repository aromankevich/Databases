using BDR.Model;
using BDR.Model.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BDR.Controller
{
    public class DirectorController
    {
        ApplicationContext context = new ApplicationContext();
        DbSet<Director> entity;
        public DirectorController()
        {
            this.entity = context.director;
        }
        public void Create(Director entity)
        {
            this.entity.Add(entity);
        }

        public void Delete(int id)
        {
            var en = entity.Find(id);
            entity.Remove(en);
        }

        public IEnumerable<Director> Read()
        {
            return entity;
        }
        public void Update(Director entity)
        {
            this.entity.Update(entity);
        }
        public Director Find(int id)
        {
            return entity.Find(id);
        }
    }
}
