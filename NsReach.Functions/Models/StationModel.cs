
namespace NsReach.Functions.Models
{
    public class StationModel
    {
        public string Code { get; }

        public string Name { get; }

        public double Latitude { get; }

        public double Longitude { get; }

        public StationModel(string code, string name, double latitude, double longitude)
        {
            Code = code;
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
