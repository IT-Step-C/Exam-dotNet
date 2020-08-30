using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Vocabulary
{
    [Serializable]
    class Word
    {
        public string Name { get; set; }
        public List<string> Translations { get; set; }
        public Word(string name, string translation)
        {
            Name = name;
            Translations = new List<string> { translation };
        }
        public void Display()
        {
            Console.Write($"> {Name} -");
            foreach (string tr in Translations)
            {
                Console.Write($" {tr};");
            }
            Console.WriteLine();
        }
        public void AddTranslate(string translation)
        {
            Translations.Add(translation);
        }
        public void DelTranslate(int k)
        {
            int n = Translations.Count;
            if (k >= n || k < 0)
            {
                Console.WriteLine(" Перевода с таким индексом нет!");
            }
            else if (n == 1)
            {
                Console.WriteLine(" У слова должен быть хоть один перевод!");
            }
            else
            {
                Translations.RemoveAt(k);
            }
        }
        public void SaveResult()
        {
            string filePath = @"..\..\result.txt";
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write($"> {Name} - ");
                    foreach (string tr in Translations)
                    {
                        sw.Write($" {tr};");
                    }
                    sw.WriteLine();
                }
            }
        }
    }
}