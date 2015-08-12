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
    public class Coupon
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, MaxLength(10)]
        public string Code { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
    }
}
