﻿using CookingBot.BotBehaviors.Requests.Interfaces;
using CookingBot.BotBehaviors.Responses;

namespace CookingBot.BotBehaviors.Requests.Undefined
{
    public class Request : IRequest
    {
        public void Execute() { }

        public IResponse CreateResponse()
        {
            return new Response("Sorry, but this request is not defined.");
        }
    }
}