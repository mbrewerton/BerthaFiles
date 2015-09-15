using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using API.Dtos;

namespace API.Models.Dtos
{
    public class UploadDto : IAuditable
    {
        public string FileName { get; set; }
		public long FileSize { get; set; }
		public string Url { get; set; }

	    public string CreatedBy { get; set; }
	    public DateTime CreatedOn { get; set; }
	    public string ModifiedBy { get; set; }
	    public DateTime ModifiedOn { get; set; }
    }
}
