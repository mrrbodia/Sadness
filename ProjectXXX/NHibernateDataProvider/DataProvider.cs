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
        public IList<Event> GetEvents()
        {
            IList<Event> Events;
            using (ISession session = NHibernateHelper.OpenSession())
            {
                IQuery query = session.CreateQuery("from Event");
                Events = query.List<Event>();
            }
            return Events;
        }
        public Event GetEventById(string id)
        {
            Event e = new Event();
            using (ISession session = NHibernateHelper.OpenSession())
            {
                e = session.Get<Event>(id);
            }
            return e;
        }
        public void CreateEvent(Event e)
        {
            using (ISession session = NHibernateHelper.OpenSession())
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
            using (ISession session = NHibernateHelper.OpenSession())
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
            using (ISession session = NHibernateHelper.OpenSession())
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
