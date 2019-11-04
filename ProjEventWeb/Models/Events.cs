using System;

namespace ProjEventWeb.Models {
    public class Events {
        public int Id { get; set;}
        public string Description {get; set;}
        public string Price {get;set;}
        public DateTime Date {get; set;}
        public string Details {get; set;}        
    }
}