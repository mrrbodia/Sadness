using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Business;
using NHibernateDataProvider;
using Events.EntityFrameworkDataProvider;

namespace ProjectXXX.App_Start
{
    public class AutofacConfig
    {
        public static void Config()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<NHibernateEventDataProvider>().As<IEventDataProvider>();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}