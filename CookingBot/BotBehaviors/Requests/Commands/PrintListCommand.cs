﻿using CookingBot.BotBehaviors.Responses;
using CookingBot.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace CookingBot.BotBehaviors.Requests.Commands
{
    internal class PrintListCommand : UserRequest
    {
        public const string commandValue = "/list";

        private DirectoryInfo mainDirectoryInfo;

        public PrintListCommand(CookingBotDB db, CookingBot.DataBase.Entities.User user, DirectoryInfo mainDirectoryInfo) : base(db, user) 
        {
            this.mainDirectoryInfo = mainDirectoryInfo;
        }

        public override bool Execute()
        {
            //TODO GetDocumentsList
            IsExecuted = TryChangeUserState();
            return IsExecuted;
        }

        public override IResponse CreateResponse()
        {
            return new Response(CreateResponseText());
        }

        //TODO Get ResponseText from file
        private string CreateResponseText()
        {
            StringBuilder stringBuilder = new StringBuilder();
            //TODO list to string
            return stringBuilder.ToString();
        }
    }
}
