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
    /// Клас, який запаковує папку з файлами і підпапками в один файл
    /// </summary>
   public static class MyReader
    {
        /// <summary>
        /// Метод створює file.dat 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="path2"></param>
        public static void Read(string path, string path2)
        { 
        var files = Directory.EnumerateFiles(path).ToList();
        var folders = Directory.EnumerateDirectories(path).ToList();
        BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path2 + "\\file.dat", FileMode.Append, FileAccess.Write))
            {
                ADirectorie dir = new MyFolder() { path = Path.GetFileName(path) };
                formatter.Serialize(fs, dir);
                myFileReader(path, fs, formatter, path.Length - Path.GetFileName(path).Length);
            }
         }

        static int myFileReader(string path, FileStream fs, BinaryFormatter formatter, int lengthPath)
        {
            var files = Directory.EnumerateFiles(path).ToList();
            var folders = Directory.EnumerateDirectories(path).ToList();
            ADirectorie dir;
            foreach (var a in folders)
            {
                dir = new MyFolder() { path = a.Substring(lengthPath) };
                formatter.Serialize(fs, dir);
            }
            long totalBytesRead = 0;
            int BufferLenght = 1024;
            int bytesRead;
            int numReads = 0;
            foreach (var a in files)
            {
                    using (FileStream sourceStream = new FileStream(a, FileMode.Open, FileAccess.Read))
                    {
                        //Получаем длину исходного файла
                        long sLenght = sourceStream.Length;
                        while (true)
                        {
                            dir = new PiseOfFile();
                            dir.path = a.Substring(lengthPath);
                            //((PiseOfFile)dir).sLenght = sLenght;
                            ((PiseOfFile)dir).buf = new byte[BufferLenght];
                            //Увеличиваем на единицу количество считываний
                            numReads++;
                            bytesRead = sourceStream.Read(((PiseOfFile)dir).buf, 0, BufferLenght);
                            if (bytesRead == 0)
                            {
                                //выходим из цикла
                                break;
                            }
                            //Для статистики запоминаем сколько уже байт записали
                            totalBytesRead += bytesRead;

                            if (bytesRead < BufferLenght)
                            {
                                break;
                            }
                            formatter.Serialize(fs, dir);
                        }
                    }

            }
            //Рекурсія
            if (folders.Count == 0)
            {
                return 1;
            }
            else
            {
                for (int i = 1; i < folders.Count; i++)
                {
                    myFileReader(folders[i], fs, formatter, lengthPath);
                }
                return myFileReader(folders[0], fs, formatter, lengthPath);
            }
        }
    }
}
