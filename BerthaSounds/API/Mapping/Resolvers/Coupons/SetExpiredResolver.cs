using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Models;
using AutoMapper;

namespace API.Mapping.Resolvers.Coupons
{
	public class SetExpiredResolver : ValueResolver<Coupon, bool>
	{
		protected override bool ResolveCore(Coupon source)
		{
			return source.EndDate < DateTime.Now;
		}
	}
}
