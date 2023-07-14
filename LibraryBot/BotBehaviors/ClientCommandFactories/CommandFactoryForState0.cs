using LibraryBot.BotBehaviors.ClientCommandFactories.ClientCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBot.BotBehaviors.ClientCommandFactories
{
    internal class CommandFactoryForState0 : IClientCommandFactory
    {
        public IClientCommand CreateBotCommand(string? commandString)
        {
            IClientCommand botCommand = new UnknownCommand();
            switch (commandString)
            {
                case AddCommand.commandValue:
                    {
                        botCommand = new AddCommand();
                        break;
                    }
                case GetCommand.commandValue:
                    {
                        botCommand = new GetCommand();
                        break;
                    }
                case DeleteCommand.commandValue:
                    {
                        botCommand = new DeleteCommand();
                        break;
                    }
                case CreateFolderCommand.commandValue:
                    {
                        botCommand = new CreateFolderCommand();
                        break;
                    }
                case DeleteFolderCommand.commandValue:
                    {
                        botCommand = new DeleteFolderCommand();
                        break;
                    }
                case PrintListCommand.commandValue:
                    {
                        botCommand = new PrintListCommand();
                        break;
                    }
            }
            return botCommand;
        }
    }
}
