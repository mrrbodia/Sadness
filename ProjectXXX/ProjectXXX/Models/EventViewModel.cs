using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ProjectXXX.Models
{
    [MetadataType(typeof(EventViewModelAttributes))]
    public class EventViewModel
    {
        
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Location { get; set; }
        public EventViewModel()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }

    public class EventViewModelAttributes
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "You must enter the name of your event")]
        [StringLength(50, ErrorMessage = "Name must be less than 50 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "You must enter the description of your event")]
        public string Description { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        [Required(ErrorMessage = "You must specify where this event will occur")]
        public string Location { get; set; }
    }
}