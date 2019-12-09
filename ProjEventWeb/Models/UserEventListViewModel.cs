using System.Collections.Generic;
using ProjEventWeb.Models;

namespace ProjEventWeb.Models
{
    public class UserEventListViewModel : Event
    {
        public UserProfile UserProfile { get; set; }
        public IEnumerable<UserEvent> UserEvent { get; set; }
        // public Event Event {get; set;}
        
    }
}