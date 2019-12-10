using System;
using System.Collections.Generic;
using ProjEventWeb.Models;

namespace ProjEventWeb.Models
{
    public class ManagementViewModel
    {
        public string EventName { get; set; }
        public string UserName { get; set; }
        public DateTime EventDate { get; set; }
        public string EventType { get; set; }
        public bool EventCertificate { get; set; }
    }
}
