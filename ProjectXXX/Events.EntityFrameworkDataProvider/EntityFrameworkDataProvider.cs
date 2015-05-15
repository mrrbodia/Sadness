using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;
using Business.Entities;


namespace Events.EntityFrameworkDataProvider
{
    public class EntityFrameworkDataProvider : IEventDataProvider
    {
        public IList<Event> GetAllElements()
        {
            throw new NotImplementedException();
        }

        public Event GetElementById(string id)
        {
            throw new NotImplementedException();
        }

        public void AddElement(Event element)
        {
            throw new NotImplementedException();
        }

        public void DeleteElement(Event element)
        {
            throw new NotImplementedException();
        }

        public void UpdateElement(Event element)
        {
            throw new NotImplementedException();
        }
    }
}
