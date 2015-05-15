﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

using Business;
using ProjectXXX.Models;
using Business.Entities;
using ProjectXXX.App_Start;

namespace ProjectXXX
{
    // Примечание: Инструкции по включению классического режима IIS6 или IIS7 
    // см. по ссылке http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            AutofacConfig.Config();

            AutoMapper.Mapper.CreateMap<Event, EventViewModel>();

            AutoMapper.Mapper.CreateMap<EventViewModel, Event>();

            WebApiConfig.Register(GlobalConfiguration.Configuration);

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            RouteConfig.RegisterRoutes(RouteTable.Routes);

        }
    }
}