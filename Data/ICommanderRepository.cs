using System.Collections;
using System.Collections.Generic;
using WebApiApp.Models;

namespace WebApiApp.Data
{
    public interface ICommanderRepository
    {
        IEnumerable<Command> GetAllCommands();
        Command GetCommandFromId(int id);

    }
}