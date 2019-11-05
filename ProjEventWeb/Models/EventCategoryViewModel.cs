using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ProjEventWeb.Models
{
    public class EventCategoryViewModel {
        public List<Event> Events {get; set;}
        public SelectList Categories {get; set;}
        public string EventCategory {get; set;}
        public string SearchString {get; set;}
    }
}