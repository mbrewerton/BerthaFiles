using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models.Dtos
{
    public class SoundPackDto
    {
        //private ICollection<Sound> _sounds;
        
        public int Id { get; set; }

        public List<Sound> Sounds { get; set; } 

        //public virtual ICollection<Sound> Sounds
        //{
        //    get { return _sounds ?? (_sounds = new Collection<Sound>()); }
        //    set { _sounds = value; }
        //} 
    }
}