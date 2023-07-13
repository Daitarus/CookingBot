﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBot.BotBehaviors.CommandFactory.Commands
{
    internal interface IBotCommand
    {
        public Task Execute();
    }
}