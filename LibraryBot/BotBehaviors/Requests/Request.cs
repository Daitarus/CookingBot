using LibraryBot.BotBehaviors.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBot.BotBehaviors.Requests
{
    internal class Request : IRequest
    {
        public bool IsExecute { get; protected set; } = false;

        public virtual bool Execute()
        {
            return IsExecute;
        }

        public virtual IResponse CreateResponse()
        {
            return new Response("Sorry, but this request is not defined");
        }
    }
}
