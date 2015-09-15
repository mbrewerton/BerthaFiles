using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
	        Mapper.CreateMap<Sound, SoundDto>()
				.ForMember(x => x.Price, opt => opt.MapFrom(src => src.Price.ToString("N2")));
        }
    }
}
