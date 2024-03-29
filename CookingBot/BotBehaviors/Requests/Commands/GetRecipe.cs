﻿using CookingBot.BotBehaviors.Requests.Undefined;
using CookingBot.BotBehaviors.Responses;
using CookingBotDB.Contexts;
using CookingBotDB.Entities;
using Microsoft.Extensions.Logging;

namespace CookingBot.BotBehaviors.Requests.Commands
{
    public class GetRecipe : UserRequest
    {
        public const string CommandValue = "/get_recipe";

        public GetRecipe(DbContextFactory dbContextFacoty, User user, ILogger? logger = null) : base(dbContextFacoty, user, logger)
        {
            _assignableUserState = UserState.GetRecipe;
        }

        //TODO Get ResponseText from file
        public override IResponse CreateResponse()
        {
            if (_isExecuted)
            {
                return new Response("Отправте номер рецепта для его получения.");
            }
            else
            {
                return new Response("Sorry, but this request is not executed.");
            }
        }
    }
}
