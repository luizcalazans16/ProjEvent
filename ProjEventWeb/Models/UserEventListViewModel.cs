using System;
using System.Collections.Generic;
using ProjEventWeb.Models;

namespace ProjEventWeb.Models
{
    public class UserEventListViewModel
    {
        public UserProfile UserProfile { get; set; }
        public IEnumerable<UserEvent> UserEvent { get; set; }


    }
   

}