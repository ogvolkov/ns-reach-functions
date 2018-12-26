
namespace NsReach.Functions.Models
{
    public class StationModel
    {
        public string Code { get; }

        public string Name { get; }

        public float Latitude { get; }

        public float Longitude { get; }

        public StationModel(string code, string name, float latitude, float longitude)
        {
            Code = code;
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
