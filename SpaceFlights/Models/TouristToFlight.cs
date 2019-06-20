using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace SpaceFlights.Models
{
    public class TouristToFlight
    {
        public int TouristToFLightId { get; set; }
        public int TouristId { get; set; }
        public int FlightId { get; set; }

        public virtual Tourist Tourist { get; set; }
        public virtual Flight Flight { get; set; }
    }
}