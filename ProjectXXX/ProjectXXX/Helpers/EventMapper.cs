using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Business.Entities;
using ProjectXXX.Models;

namespace ProjectXXX.Helpers
{
    public class EventMapper<Sourse, Destination>
    {
        public EventMapper()
        {
            Mapper.CreateMap<Sourse, Destination>();
        }

        public Destination Map(Sourse e)
        {
            return Mapper.Map<Destination>(e);
        }
        

        public IEnumerable<Destination> MapList(IEnumerable<Sourse> eList)
        {
            return eList.Select(x => Mapper.Map<Destination>(x));
        }
    }
}