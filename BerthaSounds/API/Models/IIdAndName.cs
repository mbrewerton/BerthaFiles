using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
	public interface IIdAndName
	{
		long Id { get; set; }
		string Name { get; set; }
	}
}
