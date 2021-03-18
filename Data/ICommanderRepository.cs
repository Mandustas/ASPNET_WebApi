using System.Collections;
using System.Collections.Generic;
using WebApiApp.Models;

namespace WebApiApp.Data
{
    public interface ICommanderRepository
    {
        IEnumerable<Command> GetAppCommands();
        Command GetCommandFromId(int id);

    }
}