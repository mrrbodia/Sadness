using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernateDataProvider;
using AutoMapper;
using Business.Entities;
using ProjectXXX.Models;
using Business;


namespace ProjectXXX.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventDataProvider _data;

        public EventsController(IEventDataProvider data)
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
            var viewModelInstances = Mapper.Map<IList<EventViewModel>>(eList);
            return View(viewModelInstances);
        }

        public ActionResult Description(string id)
        {
            var e = _data.GetElementById(id);
            if (e != null)
            {
                var model = Mapper.Map<EventViewModel>(e);
                return View(model);
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
                    var e = Mapper.Map<Event>(model);
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
