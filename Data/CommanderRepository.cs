using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiApp.Models;

namespace WebApiApp.Data
{
    public class CommanderRepository:ICommanderRepository
    {
        private readonly CommanderContext _commanderContext;

        public CommanderRepository(CommanderContext commanderContext)
        {
            _commanderContext = commanderContext;
        }
        public IEnumerable<Command> GetAllCommands()
        {
            return _commanderContext.Commands.ToList();
        }

        public Command GetCommandFromId(int id)
        {
            return _commanderContext.Commands.FirstOrDefault(p => p.Id == id);
        }
    }
}
