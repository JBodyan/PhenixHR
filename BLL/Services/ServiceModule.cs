using DAL.Repositories;
using DAL.Repositories.Interfaces;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class ServiceModule : NinjectModule
    {
        private readonly string _connectionString;
        public ServiceModule(string connectionString)
        {
            _connectionString = connectionString;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(_connectionString);
        }
    }
}
