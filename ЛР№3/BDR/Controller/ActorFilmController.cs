using BDR.Model;
using BDR.Model.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BDR.Controller
{
    public class ActorFilmController
    {
        ApplicationContext context = new ApplicationContext();
        DbSet<ActorFilm> entity;
        public ActorFilmController()
        {
            this.entity = context.actor_film;
        }
        public void Create(ActorFilm entity)
        {
            this.entity.Add(entity);
        }

        public void Delete(int id)
        {
            var en = entity.Find(id);
            entity.Remove(en);
        }

        public IEnumerable<ActorFilm> Read()
        {
            return entity;
        }
        public void Update(ActorFilm entity)
        {
            this.entity.Update(entity);
        }
        public ActorFilm Find(int id)
        {
            return entity.Find(id);
        }
    }
}
