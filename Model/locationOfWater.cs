using System.Threading.Tasks;
using System.Text.Json;

namespace Robot_project.Model
{

    public class locationOfWater
    {
        public int place_id { get; set; }
        public string licence { get; set; }
        public string osm_type { get; set; }
        public double osm_id { get; set; }
        public int lat { get; set; }
        public int lon { get; set; }
        public string display_name { get; set; }
        public Address address { get; set; }
        public string[] boundingbox { get; set; }
    }

    public class Address
    {
        public string locality { get; set; }
        public string municipality { get; set; }
        public string state { get; set; }
        public string ISO31662lvl4 { get; set; }
        public string postcode { get; set; }
        public string country { get; set; }
        public string country_code { get; set; }
    }

}

