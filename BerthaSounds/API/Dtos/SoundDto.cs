using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Dtos
{
    public class SoundDto
    {
        //private ICollection<Category> _categories;
        
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

		public decimal Price { get; set; }

		public string FileName { get; set; }

		public List<CategoryDto> Categories { get; set; } 

        //public virtual ICollection<Category> Categories
        //{
        //    get { return _categories ?? (_categories = new Collection<Category>()); }
        //    set { _categories = value; }
        //} 
    }
}
