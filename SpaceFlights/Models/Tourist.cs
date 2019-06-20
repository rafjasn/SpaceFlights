using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SpaceFlights.Models
{
    public class Tourist
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public string Remarks { get; set; }
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]

        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<TouristToFlight> TouristsToFlights { get; set; }
    }
}