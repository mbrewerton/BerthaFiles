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
        public IEnumerable<Sound> GetAllSounds()
        {
            var sounds = new List<Sound>();
            using (var db = new BerthaContext())
            {
                if (db.Sound.Any())
                {
                    sounds = db.Sound.ToList();
                }
            }

            return sounds;
        }

        public void UploadSound(List<SoundDto> sound)
        {
            
        }
    }
}
