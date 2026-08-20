using AutoMapper;
using Forge.WebApi.Application.Dto.Auth;
using Forge.WebApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forge.WebApi.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserAuthResponseDto>();
        }
    }
}
