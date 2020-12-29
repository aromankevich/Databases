using BDR.Model;
using BDR.Model.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BDR.Controller
{
    public class ActorController
    {
        ApplicationContext context = new ApplicationContext();
        DbSet<Actor> entity;
        public ActorController()
        {
            this.entity = context.actor;
        }
        public void Create(Actor entity)
        {
            this.entity.Add(entity);
        }

        public void Delete(int id)
        {
            var en = entity.Find(id);
            entity.Remove(en);
        }

        public IEnumerable<Actor> Read()
        {
            return entity;
        }
        public void Update(Actor entity)
        {
            this.entity.Update(entity);
        }
        public Actor Find(int id)
        {
            return entity.Find(id);
        }
    }
}
