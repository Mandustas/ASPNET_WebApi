using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApiApp.Data;
using WebApiApp.DTOs;
using WebApiApp.Models;

namespace WebApiApp.Controllers
{
    //api commands
    [Route("api/commands")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        private readonly ICommanderRepository _commanderRepository;
        private readonly IMapper _mapper;

        public CommandController(
            ICommanderRepository commanderRepository,
            IMapper mapper
            )
        {
            _commanderRepository = commanderRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _commanderRepository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {

            var commandItem = _commanderRepository.GetCommandFromId(id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _commanderRepository.CreateCommand(commandModel);
            _commanderRepository.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new {Id = commandReadDto.Id}, commandReadDto);

        }
        [HttpPut("{id}")]
        public ActionResult<CommandReadDto> UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var command = _commanderRepository.GetCommandFromId(id);
            if (command == null)
            {
                return NotFound();
            }

            _mapper.Map(commandUpdateDto, command);
            _commanderRepository.UpdateCommand(command);
            _commanderRepository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var command = _commanderRepository.GetCommandFromId(id);
            if (command == null)
            {
                return NotFound();
            }
            
            _commanderRepository.DeleteCommand(command);
            _commanderRepository.SaveChanges();
            return NoContent();
        }

    }
}
