using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Models;
using API.Models.Dtos;
using AutoMapper;

namespace API.Mapping
{
    public class SoundToSoundDtoProfile : Profile
    {
        protected override void Configure()
        {
	        Mapper.CreateMap<Sound, SoundDto>();
        }
    }
}
