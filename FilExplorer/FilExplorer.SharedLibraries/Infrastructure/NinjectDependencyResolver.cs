using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Web;
using Ninject;
using System.Web.Mvc;
using FilExplorer.DataLayer.Models;
using FilExplorer.DataLayer.DAL;
using FilExplorer.Controllers;
using FilExplorer.Controllers.AWS;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

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
            kernel.Bind<IFolderController>().To<FolderController>();
            kernel.Bind<IS3Controller>().To<S3Controller>();

            //For the builtin IUserStore
            //Check this website: http://stackoverflow.com/questions/21939051/what-ninject-binding-should-i-use
            kernel.Bind<IUserStore<ApplicationUser>>().To<UserStore<ApplicationUser>>();
            //kernel.Bind<IIdentity>().ToMethod(c => HttpContext.Current.User.Identity);
            kernel.Bind<IPrincipal>().ToMethod(c => HttpContext.Current.User);

        }
    }
}
