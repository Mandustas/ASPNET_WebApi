using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApiApp.DTOs;
using WebApiApp.Models;

namespace WebApiApp.Profiles
{
    public class CommandsProfile:Profile
    {
        public CommandsProfile()
        {
            CreateMap<Command, CommandReadDto>(); 
            CreateMap<CommandCreateDto, Command>(); 
            CreateMap<CommandUpdateDto, Command>(); 
        }
    }
}
