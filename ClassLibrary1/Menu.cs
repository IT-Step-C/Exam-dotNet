using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Menu
    {
        public List<string> Items { get; set; }
        public Menu()
        {
            Items = new List<string>();
        }
        public void AddItems(string[] items)
        {
            Items.AddRange(items);
        }
        public void DisplayMenu()
        {
            int count = 1;
            Console.Clear();
            foreach (string item in Items)
            {
                Console.WriteLine($"{count++}. {item}");
            }
        }
        public int GetChoise()
        {
            Console.WriteLine("==========================");
            Console.Write("\n> Выберите нужное действие: ");
            int choise = int.Parse(Console.ReadLine());
            return choise;
        }
        public bool AllowContinue()
        {
            Console.Write("\n> Продолжить (y/n)? - ");
            string allow = Console.ReadLine();
            return (allow == "y");
        }
    }
}