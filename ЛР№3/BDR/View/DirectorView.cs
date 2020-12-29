using BDR.Controller;
using BDR.Model;
using System;
using System.Text.Json;

namespace BDR.View
{
    public class DirectorView : IView
    {
        DirectorController controller = new DirectorController();
        public void Create()
        {
            var entity = new Director();

            Console.WriteLine("Enter info about Director:");
            Console.WriteLine("name:");
            entity.name = Console.ReadLine();
            Console.WriteLine("agent:");
            entity.tel_number = Console.ReadLine();

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
                string json = JsonSerializer.Serialize<Director>(i);
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
