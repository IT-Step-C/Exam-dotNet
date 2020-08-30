using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vocabulary
{
    [Serializable]
    class Dicts
    {
        public List<Dict> StoreDicts { get; set; }
        public Dicts()
        {
            StoreDicts = new List<Dict>();
        }
        public void DisplayDicts()
        {
            int N = StoreDicts.Count;
            if (N == 0)
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine(" Созданные словари отсутствуют!");
                Console.WriteLine("--------------------------------");
            }
            else
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine($" Имеются следующие созданные словари:");
                int k = 1;
                foreach (Dict d in StoreDicts)
                {
                    Console.WriteLine($"{k++,3}. {d.TypeDict}");
                }
                Console.WriteLine("--------------------------------------");
            }
        }
        public void AddDict(Dict dict)
        {
            StoreDicts.Add(dict);
        }
        public void DelDict(int k)
        {
            int n = StoreDicts.Count();
            if (n == 0)
            {
                Console.WriteLine(" Словари для удаления отсутствуют!");
            }
            else
            {
                StoreDicts.RemoveAt(k);
            }
        }
    }
}