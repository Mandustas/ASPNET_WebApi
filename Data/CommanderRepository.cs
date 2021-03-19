using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiApp.Models;

namespace WebApiApp.Data
{
    public class CommanderRepository : ICommanderRepository
    {
        private readonly CommanderContext _commanderContext;

        public CommanderRepository(CommanderContext commanderContext)
        {
            _commanderContext = commanderContext;
        }

        public bool SaveChanges()
        {
            return _commanderContext.SaveChanges() >= 0;
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _commanderContext.Commands.ToList();
        }

        public Command GetCommandFromId(int id)
        {
            return _commanderContext.Commands.FirstOrDefault(p => p.Id == id);
        }

        public void CreateCommand(Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            _commanderContext.Add(command);
        }

        public void UpdateCommand(Command command)
        {
            // nothing
        }

        public void DeleteCommand(Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            _commanderContext.Remove(command);
        }
    }
}
