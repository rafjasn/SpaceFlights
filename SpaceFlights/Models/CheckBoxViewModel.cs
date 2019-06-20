using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceFlights.Models
{
    public class CheckBoxViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Checked { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}