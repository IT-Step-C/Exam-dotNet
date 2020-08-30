using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Security.Policy;

namespace Vocabulary
{
    class DataManager
    {
        public Dicts Dicts { get; set; }
        public string Path { get; set; }
        public BinaryFormatter BF { get; set; }
        public DataManager()
        {
            Dicts = new Dicts();
            Path = @"..\..\Dictionary.dat";
            BF = new BinaryFormatter();
        }
        public void SaveData()
        {
            using (FileStream fs = new FileStream(Path, FileMode.OpenOrCreate))
            {
                BF.Serialize(fs, Dicts);
            }
        }
        public void LoadData()
        {
            using (FileStream fs = new FileStream(Path, FileMode.Open))
            {
                Dicts = BF.Deserialize(fs) as Dicts;
            }
        }
    }
}