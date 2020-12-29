using System;
using System.Collections.Generic;
using System.Text;

namespace BDR.View
{
    public static class Menu
    {
        public static void Render()
        {
            Console.WriteLine("Enter table num:");
            Console.WriteLine("1. ActorAgent");
            Console.WriteLine("2. Actor");
            Console.WriteLine("3. Agent");
            Console.WriteLine("4. Director");
            Console.WriteLine("5. Film");

            var table = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter action num:");
            Console.WriteLine("1. Read all");
            Console.WriteLine("2. Add record");
            Console.WriteLine("3. Change");
            Console.WriteLine("4. Delete record");
            Console.WriteLine("5. Find");
            Console.WriteLine("6. Generate random");

            var action = Int32.Parse(Console.ReadLine());


            IView view = null;
            switch (table)
            {
                case 1:
                    view = new ActorFilmView();
                    break;
                case 2:
                    view = new ActorView();
                    break;
                case 3:
                    view = new AgentView();
                    break;
                case 4:
                    view = new DirectorView();
                    break;
                case 5:
                    view = new FilmView();
                    break;
            }

            switch (action)
            {
                case 1:
                    view.Read();
                    break;
                case 2:
                    view.Create();
                    break;
                case 3:
                    view.Update();
                    break;
                case 4:
                    view.Delete();
                    break;
                case 5:
                    view.Find();
                    break;
                case 6:
                    view.Generate();
                    break;
            }
        }
    }
}
