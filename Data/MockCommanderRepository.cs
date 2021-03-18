using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiApp.Models;

namespace WebApiApp.Data
{
    public class MockCommanderRepository : ICommanderRepository
    {
        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command {HowTo = "boil an egg", Id = 0, Line = "Boil water", Platform = "Pane"},
                new Command {HowTo = "Bread", Id = 1, Line = "Get knife", Platform = "Board"},
                new Command {HowTo = "Tea", Id = 2, Line = "Teebag in cup", Platform = "Kettle"}
            };

            return commands;
        }

        public Command GetCommandFromId(int id)
        {
            return new Command { HowTo = "boil an egg", Id = 0, Line = "Boil water", Platform = "Pane" };
        }
    }
}
