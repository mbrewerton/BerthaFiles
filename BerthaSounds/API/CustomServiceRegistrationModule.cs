using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Models.DbContexts;
using Ninject.Modules;

namespace API
{
    public class CustomServiceRegistrationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().ToConstructor(x => new BerthaContext());
        }
    }
}
