﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dtos
{
	public interface IAuditable
	{
		string CreatedBy { get; set; }
		DateTime CreatedOn { get; set; }
		string ModifiedBy { get; set; }
		DateTime ModifiedOn { get; set; }
	}
}
