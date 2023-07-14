using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBot.BotBehaviors.ClientCommandFactories
{
    internal enum UserState : int
    {
        Initial = 0,
        SetNameFolderForCreate = 1,
        SetNameFolderForDelete = 2,
        SetNameDocumentForCreate = 3,
        SetNameDocumentForDelete = 4,
        SetNameDocumentForGet = 5
    }
}
