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
    public class SoundCategory
    {
        public int Id { get; set; }
		public int SoundId { get; set; }
		public int CategoryId { get; set; }
}
