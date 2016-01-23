using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models.Dtos
{
	public class CouponTypeDto : IIdAndName
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
	}
}
