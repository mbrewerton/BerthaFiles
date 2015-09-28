using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
	public class CouponType : IIdAndName
	{
		public long Id { get; set; }
		public string Name { get; set; }
	}
}
