using p1.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p1.Classes
{
    internal class clEntity
    {
        public static Entities Context { get; } = new Entities();
        public static int IDChange = 0;
        public static bool Change = false;
        public static string LoginNow;
    }
}
