using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiApp.Data;
using WebApiApp.Models;

namespace WebApiApp.Controllers
{
    //api commands
    [Route("api/commands")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        private readonly ICommanderRepository _commanderRepository;

        public CommandController(
            ICommanderRepository commanderRepository
            )
        {
            _commanderRepository = commanderRepository;
        }
        //private readonly MockCommanderRepository _commanderRepository = new MockCommanderRepository();

        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _commanderRepository.GetAllCommands();
            return Ok(commandItems);
        }
        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandById(int id)
        {
            var commandItem = _commanderRepository.GetCommandFromId(id);
            return Ok(commandItem);
        }
    }
}
