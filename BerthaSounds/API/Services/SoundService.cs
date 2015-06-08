using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Models;
using API.Models.DbContexts;
using API.Models.Dtos;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace API.Services
{
    public class SoundService : ISoundService
    {
        private readonly IRepository<Sound> _soundRepository; 
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMappingEngine _mapper;

        public SoundService(IRepository<Sound> soundRepository, IUnitOfWork unitOfWork, IMappingEngine mapper)
        {
            _soundRepository = soundRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<SoundDto> GetAllSounds()
        {
            if (_soundRepository.GetAll().Any())
            {
                return _mapper.Map<List<Sound>, List<SoundDto>>(_soundRepository.GetAll().ToList());
            }
            

            return null;
        }

        public void UploadSound(List<SoundDto> sound)
        {
            
        }
    }
}
