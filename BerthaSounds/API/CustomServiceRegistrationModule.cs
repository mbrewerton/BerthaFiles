using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Models.DbContexts;
using Ninject.Modules;
using API.Repositories;
using AutoMapper;
using Ninject.Web.Common;

namespace API
{
    public class CustomServiceRegistrationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().ToConstructor(x => new BerthaContext()).InRequestScope();
            Bind<IObjectContext>().To<ObjectContext>().InRequestScope();
            Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();

            Bind<IMappingEngine>().To<MappingEngine>();
        }
    }
}
