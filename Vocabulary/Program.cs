using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace Vocabulary
{
    class Program
    {
        static void Main(string[] args)
        {
            //Word a = new Word("hello", "привет");
            //Word b = new Word("world", "мир");
            //a.Display();
            //a.AddTranslate("здравствуйте");
            //a.Display();
            //a.DelTranslate(1);
            //a.DelTranslate(0);
            //a.Display();
            //Dict d = new Dict(1);
            //d.DisplayDict();
            //d.AddWord(a);
            //d.AddWord(b);
            //d.DisplayDict();
            //d.DelWord(0);
            //d.DisplayDict();
            //d.DelWord(0);
            //Dicts sd = new Dicts();
            //sd.AddDict(d);
            //sd.DisplayDicts();

            OperationManager OM = new OperationManager();
            Menu M = new Menu();
            M.AddItems(new string[]
            {
                "Создать словарь",
                "Показать имеющиеся словари",
                "Удалить словарь",
                "Добавить слово и его перевод",
                "Показать все слова в словаре",
                "Искать перевод слова",
                "Добавить ещё один перевод слова",
                "Заменить слово",
                "Заменить перевод",
                "Удалить слово",
                "Удалить перевод",
                "Экспортировать результат перевода",
                "Завершить работу"
            });
            bool exit = false;
            do
            {
                M.DisplayMenu();
                switch (M.GetChoise())
                {
                    case 1:
                        OM.AddDictToStore();
                        break;
                    case 2:
                        OM.DisplayAllDicts();
                        break;
                    case 3:
                        OM.DelDictFromStore();
                        break;
                    case 4:
                        OM.AddWordToDict();
                        break;
                    case 5:
                        OM.DisplayAllWordsInDict();
                        break;
                    case 6:
                        OM.SearchTranslateOfWord();
                        break;
                    case 7:
                        OM.AddTranslateForWord();
                        break;
                    case 8:
                        OM.ReplaceWordInDict();
                        break;
                    case 9:
                        OM.ReplaceTranslateOfWord();
                        break;
                    case 10:
                        OM.DelWordFromDict();
                        break;
                    case 11:
                        OM.DelTranslateOfWord();
                        break;
                    case 12:
                        OM.ResultExport();
                        break;
                    case 13:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine(" Вы ввели несуществующее значение!");
                        break;
                }
                if (exit)
                {
                    break;
                }
            } while (M.AllowContinue());
            Console.WriteLine("\nПрограмма завершена.");
        }
    }
}