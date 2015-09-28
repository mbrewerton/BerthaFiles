using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class SoundPack
    {
        //private ICollection<Sound> _sounds;
            
        [Required]
        public long Id { get; set; }

        [Required]
        public List<Sound> Sounds { get; set; } 

        //public virtual ICollection<Sound> Sounds
        //{
        //    get { return _sounds ?? (_sounds = new Collection<Sound>()); }
        //    set { _sounds = value; }
        //} 
    }
}