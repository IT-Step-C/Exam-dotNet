using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vocabulary
{
    class OperationManager
    {
        public DataManager DM { get; set; }
        public OperationManager()
        {
            DM = new DataManager();
            DM.LoadData();
        }
        public void AddDictToStore()
        {
            Console.Write("\n> Введите тип словаря, который хотите создать (1 - англо-русский, 2 - русско-английский): ");
            int td = int.Parse(Console.ReadLine());
            DM.Dicts.AddDict(new Dict(td));
            Console.WriteLine(" Словарь успешно создан!");
            DM.SaveData();
        }
        public void DisplayAllDicts()
        {
            DM.Dicts.DisplayDicts();
        }
        public void DelDictFromStore()
        {
            Console.Write("\n> Введите номер словаря, который хотите удалить: ");
            int choise = int.Parse(Console.ReadLine());
            DM.Dicts.DelDict(choise - 1);
            Console.WriteLine(" Словарь успешно удален!");
            DM.SaveData();
        }
        public void AddWordToDict()
        {
            Console.Write("\n> Выберите номер словаря, в который хотите добавить слово: ");
            int choise = int.Parse(Console.ReadLine());
            Console.Write(" Введите слово: ");
            string word = Console.ReadLine();
            Console.Write(" Введите перевод слова: ");
            string translate = Console.ReadLine();
            DM.Dicts.StoreDicts[choise - 1].AddWord(new Word(word, translate));
            Console.WriteLine(" Слово успешно добавлено!");
            DM.SaveData();
        }
        public void DisplayAllWordsInDict()
        {
            Console.Write("\n> Выберите номер словаря: ");
            int choise = int.Parse(Console.ReadLine());
            DM.Dicts.StoreDicts[choise - 1].DisplayDict();
        }
        public void SearchTranslateOfWord()
        {
            Console.Write(" Введите слово для перевода: ");
            string word = Console.ReadLine();
            int count = 0;
            foreach (Dict d in DM.Dicts.StoreDicts)
            {
                foreach (Word w in d.Words)
                {
                    if (w.Name == word)
                    {
                        count++;
                        w.Display();
                        break;
                    }
                }
            }
            if (count == 0)
            {
                Console.WriteLine(" Такого слова нет в имеющихся словорях!");
            }
        }
        public void AddTranslateForWord()
        {
            Console.Write(" Введите слово, ещё один перевод которого вы хотите добавить: ");
            string word = Console.ReadLine();
            Console.Write(" Введите ещё один перевод слова: ");
            string translate = Console.ReadLine();
            int count = 0;
            foreach (Dict d in DM.Dicts.StoreDicts)
            {
                foreach (Word w in d.Words)
                {
                    if (w.Name == word)
                    {
                        count++;
                        w.AddTranslate(translate);
                        Console.WriteLine(" Ещё один перевод слова успешно добавлен!");
                        break;
                    }
                }
            }
            if (count == 0)
            {
                Console.WriteLine(" Такого слова нет в имеющихся словорях!");
            }
            DM.SaveData();
        }
        public void ReplaceWordInDict()
        {
            Console.Write(" Введите слово, которе хотите заменить: ");
            string oldWord = Console.ReadLine();
            Console.Write(" Введите новое слово: ");
            string newWord = Console.ReadLine();
            int count = 0;
            foreach (Dict d in DM.Dicts.StoreDicts)
            {
                foreach (Word w in d.Words)
                {
                    if (w.Name == oldWord)
                    {
                        count++;
                        w.Name = newWord;
                        Console.WriteLine(" Слово успешно заменено!");
                        break;
                    }
                }
            }
            if (count == 0)
            {
                Console.WriteLine(" Такого слова нет в имеющихся словорях!");
            }
            DM.SaveData();
        }
        public void ReplaceTranslateOfWord()
        {
            Console.Write(" Введите слово, перевод которого хотите заменить: ");
            string word = Console.ReadLine();
            Console.Write(" Введите порядковый номер перевода, который хотите заменить: ");
            int choice = int.Parse(Console.ReadLine());
            Console.Write(" Введите новый перевод слова: ");
            string newTranslate = Console.ReadLine();
            int count = 0;
            foreach (Dict d in DM.Dicts.StoreDicts)
            {
                foreach (Word w in d.Words)
                {
                    if (w.Name == word)
                    {
                        count++;
                        if (choice > w.Translations.Count)
                        {
                            Console.WriteLine(" У данного слова нет перевода с таким порядковым номером!");
                            break;
                        }
                        else
                        {
                            w.Translations[choice - 1] = newTranslate;
                            Console.WriteLine(" Перевод слова успешно заменен!");
                            break;
                        }
                    }
                }
            }
            if (count == 0)
            {
                Console.WriteLine(" Такого слова нет в имеющихся словорях!");
            }
            DM.SaveData();
        }
        public void DelWordFromDict()
        {
            Console.Write(" Введите слово, которое хотите удалить: ");
            string word = Console.ReadLine();
            int count = 0;
            foreach (Dict d in DM.Dicts.StoreDicts)
            {
                int k = 0;
                foreach (Word w in d.Words)
                {
                    if (w.Name == word)
                    {
                        count++;
                        d.DelWord(k);
                        Console.WriteLine(" Слово успешно удалено!");
                        break;
                    }
                    k++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine(" Такого слова нет в имеющихся словорях!");
            }
            DM.SaveData();
        }
        public void DelTranslateOfWord()
        {
            Console.Write(" Введите слово, перевод которого вы хотите удалить: ");
            string word = Console.ReadLine();
            Console.Write(" Введите порядковый номер перевода, который хотите удалить: ");
            int k = int.Parse(Console.ReadLine());
            int count = 0;
            foreach (Dict d in DM.Dicts.StoreDicts)
            {
                foreach (Word w in d.Words)
                {
                    if (w.Name == word)
                    {
                        count++;
                        w.DelTranslate(k);
                        Console.WriteLine(" Перевод слова успешно удален!");
                        break;
                    }
                }
            }
            if (count == 0)
            {
                Console.WriteLine(" Такого слова нет в имеющихся словорях!");
            }
            DM.SaveData();
        }
        public void ResultExport()
        {
            Console.Write(" Введите слово для экспорта: ");
            string word = Console.ReadLine();
            int count = 0;
            foreach (Dict d in DM.Dicts.StoreDicts)
            {
                foreach (Word w in d.Words)
                {
                    if (w.Name == word)
                    {
                        count++;
                        w.SaveResult();
                        Console.WriteLine(" Слово и его перевод успешно экспортированы!");
                        break;
                    }
                }
            }
            if (count == 0)
            {
                Console.WriteLine(" Такого слова нет в имеющихся словорях!");
            }
        }
    }
}