using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using Business.Entities;

namespace NHibernateDataProvider
{
    public class DataProvider
    {
        private ISessionFactory SessionFactory;
        ISession OpenSession()
        {
            if (SessionFactory == null)
            {
                var cfg = new Configuration();
                var data = cfg.Configure(
                    HttpContext.Current.Server.MapPath(@"~/Web.config"));
                cfg.AddDirectory(new System.IO.DirectoryInfo(HttpContext.Current.Server.MapPath(@"~/NHibernate/Mapping")));
                SessionFactory = data.BuildSessionFactory();
            }
            return SessionFactory.OpenSession();
        }
        public IList<Event> GetEvents()
        {
            IList<Event> Events;
            using (ISession session = OpenSession())
            {
                IQuery query = session.CreateQuery("from Event");
                Events = query.List<Event>();
            }
            return Events;
        }
        public Event GetEventById(string id)
        {
            Event e = new Event();
            using (ISession session = OpenSession())
            {
                e = session.Get<Event>(id);
            }
            return e;
        }
        public void CreateEvent(Event e)
        {
            using (ISession session = OpenSession())
            {
                using (ITransaction tran = session.BeginTransaction())
                {
                    session.Save(e);
                    tran.Commit();
                }
            }        
        }

        public void UpdateEvent(Event e)
        {
            using (ISession session = OpenSession())
            {
                using (ITransaction tran = session.BeginTransaction())
                {
                    session.Update(e);
                    tran.Commit();
                }
            }
        }

        public void DeleteEvent(Event e)
        {
            using (ISession session = OpenSession())
            {
                using (ITransaction tran = session.BeginTransaction())
                {
                    session.Delete(e);
                    tran.Commit();
                }
            }
        }
    }
}
