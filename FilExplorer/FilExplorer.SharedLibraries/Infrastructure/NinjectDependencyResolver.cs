using System;
using System.Collections.Generic;
using Ninject;
using System.Web.Mvc;
using FilExplorer.DataLayer.Models;
using FilExplorer.DataLayer.DAL;

namespace FilExplorer.SharedLibraries.Infrastructure
{
    public class NinjectDependencyResolver:IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {


            //Context DB Binding
            kernel.Bind<IFolderContext>().To<FolderContext>();
            kernel.Bind<IFileContext>().To<FileContext>();

            //Controllers binding

        }
    }
}
