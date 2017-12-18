using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopiLibrary
{
    [Serializable]
    internal class MyFolder : ADirectorie
    {
        internal override void WriteNext(string path1)
        {
            Directory.CreateDirectory(path1 + "\\" + path);
        }
    }
}
