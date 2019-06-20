using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpaceFlights.Models
{
    public class FlightsViewModel
    {

        public int FlightId { get; set; }
        public string Name { get; set; }
        [Display(Name = "Departure Date")]
        public DateTime DepartureDate { get; set; }
        [Display(Name = "Arrival Date")]
        public DateTime ArrivalDate { get; set; }
        [Display(Name = "Number of Seats")]
        public int NumberOfSeats { get; set; }
        public double Price { get; set; }
        [Display(Name = "Occupied Seats")]
        public int NumberOfSeatsTaken { get; set; }

        public List<CheckBoxViewModel> Tourists { get; set; }


    }
}