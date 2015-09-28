using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace API.Dtos
{
	public interface ISearchDto
	{
		string Term { get; set; }
	}

	public class SearchDto : ISearchDto
	{
		public string Term { get; set; }
	}
}
