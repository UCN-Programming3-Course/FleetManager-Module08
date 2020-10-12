using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Client.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public int Mileage { get; set; }
        public DateTime? Reserved { get; set; }

        public int SelectedLocationId { get; set; }

        public SelectList Locations { get; set; }
    }
}