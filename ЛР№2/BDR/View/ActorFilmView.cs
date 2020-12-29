using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using BDR.Controller;
using BDR.Model;

namespace BDR.View
{
    public class ActorFilmView : IView
    {
        Controller<ActorFilm> controller = new Controller<ActorFilm>(new ActorFilm());
        private object enitty;

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
                Console.WriteLine("Введите поле по которому будете искать:");
                whereCondition += " " + Console.ReadLine();
                Console.WriteLine("Введите искомое значение:");
                whereCondition += " = " + Console.ReadLine();
                Console.WriteLine("Хотите найти по еще одному параметру?(y/n)");
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
            string json = JsonSerializer.Serialize<ActorFilm>(g);
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
                string json = JsonSerializer.Serialize<ActorFilm>(i);
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
