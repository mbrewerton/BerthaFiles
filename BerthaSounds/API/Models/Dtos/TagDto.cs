using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models.Dtos
{
    public class TagDto
    {
        public int Id { get; set; }

		public string Name { get; set; }

		public int NumberOfSoundsAssignedTo { get; set; }
    }
}
