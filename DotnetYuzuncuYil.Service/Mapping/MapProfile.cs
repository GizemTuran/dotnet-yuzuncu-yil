using AutoMapper;
using DotnetYuzuncuYil.Core.DTOs;
using DotnetYuzuncuYil.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetYuzuncuYil.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Team, TeamDto>().ReverseMap(); //reversemap entityden dtoya çevirme işlemini üstlenir.
            CreateMap<User,UserDto>().ReverseMap();
            CreateMap<UserProfile,UserProfileDto>().ReverseMap();

            //dtodan entitye çevirmek istersem,
            CreateMap<TeamDto, Team>();
        }
    }
}
