using BDR.Model;
using BDR.Model.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BDR.Controller
{
    public class AgentController
    {
        ApplicationContext context = new ApplicationContext();
        DbSet<Agent> entity;
        public AgentController()
        {
            this.entity = context.agent;
        }
        public void Create(Agent entity)
        {
            this.entity.Add(entity);
        }

        public void Delete(int id)
        {
            var en = entity.Find(id);
            entity.Remove(en);
        }

        public IEnumerable<Agent> Read()
        {
            return entity;
        }
        public void Update(Agent entity)
        {
            this.entity.Update(entity);
        }
        public Agent Find(int id)
        {
            return entity.Find(id);
        }
    }
}
