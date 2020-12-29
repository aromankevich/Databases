using BDR.Controller;
using BDR.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace BDR.View
{
    public class ActorView : IView
    {
        Controller<Actor> controller = new Controller<Actor>(new Actor());
        public void Create()
        {
            var entity = new Actor();

            Console.WriteLine("Enter info about actor:");
            Console.WriteLine("name:");
            entity.name = Console.ReadLine();
            Console.WriteLine("agent:");
            entity.agent = Int32.Parse(Console.ReadLine());

            controller.Create(entity);
        }

        public void Delete()
        {
            Console.WriteLine("Enter id of record you need to delete:");

            var id = Int32.Parse(Console.ReadLine());
            controller.Delete(id);
        }

        public void Find()
        {
            string whereCondition = " where ";
            int i = 0;
            while (true)
            {
                if (i != 0)
                {
                    whereCondition += " and ";
                }
                Console.WriteLine("Enter find field:");
                whereCondition += " " + Console.ReadLine();
                Console.WriteLine("Enter find value:");
                whereCondition += " = " + Console.ReadLine();
                Console.WriteLine("Do you need one more parameter?(y/n)");
                var input = Console.ReadLine();
                if (input == "n" || input == "н")
                {
                    break;
                }
                else
                {
                    i++;
                }
            }
            var g = controller.Find(whereCondition);
            string json = JsonSerializer.Serialize<Actor>(g);
            Console.WriteLine(json);
        }

        public void Generate()
        {
            Console.WriteLine("How many records to generate?");

            var recordsAmount = Int32.Parse(Console.ReadLine());

            controller.Generate(recordsAmount);
        }

        public void Read()
        {
            foreach (var i in controller.Read())
            {
                string json = JsonSerializer.Serialize<Actor>(i);
                Console.WriteLine(json);
            }
        }

        public void Update()
        {
            string fieldToSet, valueToSet;
            Console.Clear();
            Console.WriteLine("Enter id of record you want to change:");
            var id = Int32.Parse(Console.ReadLine());


            Console.WriteLine("Enter name of field you want to change:");
            fieldToSet = Console.ReadLine();
            Console.WriteLine("Enter new value");
            valueToSet = Console.ReadLine();

            int ParseInt = 0;
            if (Int32.TryParse(valueToSet, out ParseInt) == false)
            {
                valueToSet = "'" + valueToSet + "'";
            }
            string updateString = "set " + fieldToSet + " = " + valueToSet + " where id = " + id;
            controller.Update(updateString);
        }
    }
}
