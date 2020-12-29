using System;
using System.Text.Json;
using BDR.Controller;
using BDR.Model;

namespace BDR.View
{
    public class ActorFilmView : IView
    {
        ActorFilmController controller = new ActorFilmController();
        public void Create()
        {
            var entity = new ActorFilm();

            Console.WriteLine("Enter info about actor_film:");
            Console.WriteLine("film_id:");
            entity.film_id = Int32.Parse(Console.ReadLine());
            Console.WriteLine("actor_id:");
            entity.actor_id = Int32.Parse(Console.ReadLine());

            controller.Create(entity);
        }

        public void Delete()
        {
            Console.WriteLine("Enter id of record you need to delete:");

            var id = Int32.Parse(Console.ReadLine());
            controller.Delete(id);
        }

        public void Read()
        {
            foreach (var i in controller.Read())
            {
                string json = JsonSerializer.Serialize<ActorFilm>(i);
                Console.WriteLine(json);
            }
        }

        public void Update()
        {
            Console.Clear();
            Console.WriteLine("Enter id of record you want to change:");
            var id = Int32.Parse(Console.ReadLine());

            var entity = controller.Find(id);
            controller.Update(entity);
        }
    }
}
