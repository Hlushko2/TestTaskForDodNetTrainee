using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CopiLibrary
{
    /// <summary>
    /// Клас, який розпаковує файл file.dat
    /// </summary>
    public static class MyWriter
    {
        /// <summary>
        /// Метод який з file.dat робить папки з файлами
        /// </summary>
        /// <param name="path"></param>
        /// <param name="path2"></param>
        public static void Write(string path, string path2)
        {
            using (FileStream fs = new FileStream(path2 + "\\file.dat", FileMode.OpenOrCreate, FileAccess.Read))
            {
                fs.Seek(0, SeekOrigin.Begin);
                BinaryFormatter formatter = new BinaryFormatter();
                while (fs.Length != fs.Position)
                {
                   ((ADirectorie)formatter.Deserialize(fs)).WriteNext(path);
                }
            }
        }

    }
}
