using API.Models;
using API.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Services
{
    public class TestService : API.Services.ITestService
    {
        /* Test service runs perfectly fine without using a Repository.
         * When a repository is added to the service, the AdminController
         * no longer gets as far as the TestService. */
        //private readonly IRepository<Sound> _repo;

        //public TestService(IRepository<Sound> repo)
        //{
        //    _repo = repo;
        //}
        public void Log()
        {
            Debug.WriteLine(">> Hit service");
            //Debug.WriteLine(_repo.ToString());
        }
    }
}
