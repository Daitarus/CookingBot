﻿using LibraryBot.BotBehaviors.Responses;
using LibraryBot.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace LibraryBot.BotBehaviors.Requests.Commands
{
    internal class StartCommand : Request
    {
        public const string commandValue = "/start";

        public StartCommand(LibraryBotDB db, Message message, DataBase.User user) : base(db, message, user) { }

        public override bool Execute()
        {
            if(user.State!=UserState.Initial)
            {
                UserRepository userRepository = new UserRepository(db);
                user.State = UserState.Initial;
                userRepository.SaveChanges();
            }
            IsExecute = true;
            return IsExecute;
        }

        public override IResponse CreateResponse()
        {
            return new Response(CreateResponseText());
        }

        //TODO Get ResponseText from file
        private string CreateResponseText()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Hello ");

            if (user.UserName != null)
                stringBuilder.Append(user.UserName);
            else
                stringBuilder.Append(user.FirstName);

            stringBuilder.Append("! ! Wellcome to bot.");
            return stringBuilder.ToString();
        }
    }
}
