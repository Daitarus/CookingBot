﻿using CookingBot.DataBase.Entities;
using CookingBot.BotBehaviors.Responses;
using CookingBot.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace CookingBot.BotBehaviors.Requests.Commands
{
    internal class DeleteFolderCommand : UserRequest
    {
        public const string commandValue = "/dfolder";

        public DeleteFolderCommand(CookingBotDB db, CookingBot.DataBase.Entities.User user) : base(db, user)
        {
            _assignableUserState = UserState.DeleteFolder;
        }

        public override IResponse CreateResponse()
        {
            return new Response(CreateResponseText());
        }

        //TODO Get ResponseText from file
        private string CreateResponseText()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Send the path to the folder you are deleting.\n");
            stringBuilder.Append("(All folders and documents in deleting folder will be deleted)\n");
            return stringBuilder.ToString();
        }
    }
}
