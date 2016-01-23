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
    public class CouponDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

		public bool Expired { get; set; }

		public int Amount { get; set; }

		public long CouponTypeId { get; set; }
		public CouponType CouponType { get; set; }
    }
}
