using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vocabulary
{
    [Serializable]
    class Dict
    {
        public string TypeDict { get; set; }
        public List<Word> Words { get; set; }
        public Dict(int td)
        {
            if (td == 1)
            {
                TypeDict = "англо-русский";
            }
            else if (td == 2)
            {
                TypeDict = "русско-английский";
            }
            else
            {
                Console.WriteLine("  Такой словарь не предусмотрен!");
            }
            Words = new List<Word>();
        }
        public void DisplayDict()
        {
            Console.WriteLine($"\n Словарь: {TypeDict}");
            Console.WriteLine("============================");
            int n = Words.Count;
            if (n == 0)
            {
                Console.WriteLine(" Этот словарь пуст!");
            }
            else
            {
                if (n == 1)
                {
                    Console.WriteLine(" Этот словарь содержит 1 слово:");
                }
                else
                {
                    Console.WriteLine($" Этот словарь содержит {n} слов:");
                }
                int k = 1;
                foreach (Word w in Words)
                {
                    Console.WriteLine($"{k++,3}. {w.Name}");
                }
            }
        }
        public void AddWord(Word word)
        {
            Words.Add(word);
        }
        public void DelWord(int k)
        {
            int n = Words.Count();
            if (n == 0)
            {
                Console.WriteLine(" В этом словаре нечего удалять!");
            }
            else
            {
                Words.RemoveAt(k);
            }
        }
    }
}