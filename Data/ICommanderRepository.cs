using System.Collections;
using System.Collections.Generic;
using WebApiApp.Models;

namespace WebApiApp.Data
{
    public interface ICommanderRepository
    {
        bool SaveChanges();
        IEnumerable<Command> GetAllCommands();
        Command GetCommandFromId(int id);
        void CreateCommand(Command command);
        void UpdateCommand(Command command);
        void DeleteCommand(Command command);

    }
}