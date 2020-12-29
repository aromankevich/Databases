using BDR.Model;
using BDR.Model.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BDR.Controller
{
    public class FilmController
    {
        ApplicationContext context = new ApplicationContext();
        DbSet<Film> entity;
        public FilmController()
        {
            this.entity = context.film;
        }
        public void Create(Film entity)
        {
            this.entity.Add(entity);
        }

        public void Delete(int id)
        {
            var en = entity.Find(id);
            entity.Remove(en);
        }

        public IEnumerable<Film> Read()
        {
            return entity;
        }
        public void Update(Film entity)
        {
            this.entity.Update(entity);
        }
        public Film Find(int id)
        {
            return entity.Find(id);
        }
    }
}
