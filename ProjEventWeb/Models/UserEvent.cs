using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjEventWeb.Models {
    public class UserEvent  {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool Payment { get; set;}
        public bool Certificate { get; set;}
        public int UserId {get; set;}
        public int CupomId {get; set;}
        public int EventId {get; set;}
        public int Quantity {get; set;}

        public virtual UserProfile User { get; set; }
        public virtual Event Event { get; set; }     
    }

}