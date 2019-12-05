using System;
using System.Collections.Generic;

namespace ProjEventWeb.Models
{
    public class UserEventViewModel
    {

        public UserEventViewModel()
        {
            UserEvent = new UserEvent();
        }


        public Event Event { get; set; }
        public UserEvent UserEvent { get; set; }
    }
}
