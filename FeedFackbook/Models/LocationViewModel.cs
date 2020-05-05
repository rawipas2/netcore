using System;
namespace FeedFackbook.Models
{
    public class LocationViewModel
    {

        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int Postcode { get; set; }

        public StreetViewModel Street { get; set; }
        public CoordinatesViewModel Coordinates { get; set; }
        public TimezoneViewModel Timezone { get; set; }

        public LocationViewModel()
        {
        }
    }
}
