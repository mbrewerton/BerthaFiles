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
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace API.Services
{
    public class SoundService : ISoundService
    {
        private readonly IRepository<Sound> _soundRepository; 
        private readonly IUnitOfWork _unitOfWork;

        public SoundService(IRepository<Sound> soundRepository, IUnitOfWork unitOfWork)
        {
            _soundRepository = soundRepository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Sound> GetAllSounds()
        {
            if (_soundRepository.GetAll().Any())
                return _soundRepository.GetAll();
            else
                return null;
        }

        public void UploadSound(List<SoundDto> sound)
        {
            
        }
    }
}
