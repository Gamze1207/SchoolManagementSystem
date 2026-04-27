using SchoolManagementSystem.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.ConsoleUI
{
    public class SchoolUI
    {
        private readonly SchoolService schoolService;
        public SchoolUI(SchoolService schoolService)
        {
            this.schoolService = schoolService;
        }
        public void Run()
        {
            bool running = true;

            while (running)
            {
                Menu();

                Console.Write("Choose: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        
                        break;
                    case "2":
                        
                        break;
                    case "3":
                        
                        break;
                    case "4":
                        
                        break;
                    case "5":
                        
                        break;
                    case "6":

                        break;
                    case "7":
                        break;
                    case "8":
                        break;
                    case "9":
                        break;
                    case "10":
                        break;
                    case "11":
                        break;
                    case "12":
                        break;
                    case "13":
                        break;
                    case "14":
                        break;
                    case "15":
                        break;
                    case "16":
                        break;
                    case "17":
                        break;
                    case "18":
                        break;
                    case "19":
                        break;
                    case "20":
                        break;
                    case "x":
                        running = false;
                        break;
                }
            }
        }

        private void Menu()
        {
            Console.Clear();
            Console.WriteLine("==== School Management System ====");
            Console.WriteLine("x. Exit");
        }
    }
}
