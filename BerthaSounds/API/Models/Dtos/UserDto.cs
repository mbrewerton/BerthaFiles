using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace API.Models.Dtos
{
    public class UserDto
    {
		public string Id { get; set; }
	    public string Email { get; set; }
	    public UserProfileDto UserProfileDto { get; set; }
	    public string UserName { get; set; }
    }
}
