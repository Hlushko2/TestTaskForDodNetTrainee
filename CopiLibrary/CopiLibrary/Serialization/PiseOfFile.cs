using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopiLibrary
{
    [Serializable]
    internal class PiseOfFile : ADirectorie
    {
        internal byte[] buf;
        internal override void WriteNext(string path1)
        {
            using (FileStream fs = new FileStream(path1 + "\\" + path, FileMode.Append, FileAccess.Write))
            {
                fs.Write(buf, 0, buf.Count());
            }
        }
    }
}
