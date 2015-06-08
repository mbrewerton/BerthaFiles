using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Sound
    {
        //private ICollection<Category> _categories;
            
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string FileName { get; set; }

        public ICollection<Category> Categories { get; set; }

        public ICollection<Tag> Tags { get; set; } 

        //public virtual ICollection<Category> Categories
        //{
        //    get { return _categories ?? (_categories = new Collection<Category>()); }
        //    set { _categories = value; }
        //} 
    }
}
