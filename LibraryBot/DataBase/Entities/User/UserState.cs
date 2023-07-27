using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBot.DataBase
{
    internal enum UserState : int
    {
        Initial = 0,
        AddDocument = 1,
        DeleteDocument = 2,
        AddFolder = 3, 
        DeleteFolder = 4
    }
}
