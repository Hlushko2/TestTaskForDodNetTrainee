using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopiLibrary
{
    [Serializable]
    internal abstract class ADirectorie
    {
        internal string path;
        internal abstract void WriteNext(string path);
    }

}
