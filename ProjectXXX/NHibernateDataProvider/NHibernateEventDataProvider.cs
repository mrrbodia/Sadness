using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using Business.Entities;
using Business;

namespace NHibernateDataProvider
{
    public class NHibernateEventDataProvider : IEventDataProvider
    {
        public IList<Event> GetAllElements()
        {
            IList<Event> Events;
            using (ISession session = NHibernateHelper.OpenSession())
            {
                IQuery query = session.CreateQuery("from Event");
                Events = query.List<Event>();
            }
            return Events;
        }
        public Event GetElementById(string id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                return session.Get<Event>(id);
            }
        }
        public void AddElement(Event e)
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

        public void UpdateElement(Event e)
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

        public void DeleteElement(Event e)
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
