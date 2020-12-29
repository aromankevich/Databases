using BDR.Controller;
using BDR.Model;
using System;
using System.Text.Json;

namespace BDR.View
{
    public class FilmView : IView
    {
        FilmController controller = new FilmController();
        public void Create()
        {
            var entity = new Film();

            Console.WriteLine("Enter info about film:");
            Console.WriteLine("name:");
            entity.name = Console.ReadLine();
            Console.WriteLine("director:");
            entity.director = Int32.Parse(Console.ReadLine());
            Console.WriteLine("budget:");
            entity.budget = Int32.Parse(Console.ReadLine());

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
                string json = JsonSerializer.Serialize<Film>(i);
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
