using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernateDataProvider;
using AutoMapper;
using Business.Entities;
using ProjectXXX.Models;
using ProjectXXX.Helpers;
using Business;

namespace ProjectXXX.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventDataProvider _data;

        private EventsController(IEventDataProvider data)
        {
            _data = data;
        }
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EventList()
        {
            var eList = _data.GetAllElements();
            var viewModelInstances = new EventMapper<Event, EventViewModel>().MapList(eList);
            return View(viewModelInstances);
        }

        public ActionResult Description(string id)
        {
            var e = _data.GetElementById(id);
            if (e != null)
            {
                var eventViewModel = new EventMapper<Event, EventViewModel>().Map(e);
                return View(eventViewModel);
            }
            return RedirectToRoute("EventNotFound");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new EventViewModel());
        }

        [HttpPost]
        public ActionResult Create(EventViewModel model)
        {
                try
                {   
                    var e = new EventMapper<EventViewModel, Event>().Map(model);
                    _data.AddElement(e);
                    return RedirectToRoute("EventList");
                }
                catch
                {
                    return View();
                }          
        }
    }
}
