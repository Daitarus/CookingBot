using LibraryBot.BotBehaviors.CommandFactory.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBot.BotBehaviors.CommandFactory
{
    internal class BotCommandFactory : IBotCommandFactory
    {
        public IBotCommand CreateBotCommand(string? commandString)
        {
            IBotCommand botCommand = new UnknownCommand();
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
                default:
                    {
                        break;
                    }
            }
            return botCommand;
        }
    }
}
