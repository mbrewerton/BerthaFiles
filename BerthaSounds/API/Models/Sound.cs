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

        public string AzureLocation { get; set; }

		public decimal Price { get; set; }

		private ICollection<Tag> _tags { get; set; }
	    public virtual ICollection<Tag> Tags
	    {
		    get { return _tags ?? (_tags = new Collection<Tag>()); }
		    set { _tags = value; }
	    }

		private ICollection<Category> _categories { get; set; }
	    public virtual ICollection<Category> Categories
	    {
		    get { return _categories ?? (_categories = new Collection<Category>()); }
		    set { _categories = value; }
	    }

	    // Wil be removed when azure is implemented.
		public string FileName { get; set; }
    }
}
