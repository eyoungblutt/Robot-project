using System.Threading.Tasks;
using System.Text.Json;

namespace Robot_project.Model
{
    public class locationOfWater
    {

        private double _place_id;
        private string _license;
        private string _0smType;
        private double _latitude;
        private double _longitude;
        private string _displayName;
        private string _osmID;
        private List<string> _address; //may not be right - this is an object with key's and values inside it
        //address: road, town, municipality, state, postcode, country, country code.
        private Array[] _boundingBix;
        public string License { get { return _license; } set { _license = value; } }
        public double Place_id { get { return _place_id; } set { _place_id = value; } }
        public string Osm_type { get { return _0smType; } set { _0smType = value; } }
        public string Display_name { get { return _displayName; } set { _displayName = value; } }

        public double longitude { get { return _longitude; } set { _longitude = value; } }
        public double latitude { get { return _latitude; } set { _latitude = value; } }
        public List<string> Address { get { return _address; } set { _address = value; } }
        public string Osm_id { get { return _osmID; } set { _osmID = value; } }
        public Array[] Boundingbox { get { return _boundingBix; } set { _boundingBix = value; } }

        public locationOfWater(double lon, double lat, List<string> address, string license, double place_id, string display_name, string osm_type, string osm_id, Array[] boundingbox)
        {
            longitude = lon;
            latitude = lat;
            Address = address;
            License = license;
            Place_id = place_id;
            Display_name = display_name;
            Osm_type = osm_type;
            Osm_id = osm_id;
            Boundingbox = boundingbox;

        }
    }
}

