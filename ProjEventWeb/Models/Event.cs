using System;
using System.Collections.Generic;

namespace ProjEventWeb.Models {
    public class Event {
        public int Id { get; set;}
        public string Description {get; set;}
        public decimal Price {get;set;}
        public DateTime Date {get; set;}
        public string Category {get; set;}
        public string Details {get; set;}    
        public int Quantity {get; set;}    

        public IEnumerable<UserEvent> UserEvents { get; set; }
    }
}