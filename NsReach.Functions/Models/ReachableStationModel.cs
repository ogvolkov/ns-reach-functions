namespace NsReach.Functions.Models
{
    public class ReachableStationModel
    {
        public string Code { get; }

        /// <summary>
        /// Time in minutes
        /// </summary>
        public int Time { get; }

        public ReachableStationModel(string code, int time)
        {
            Code = code;
            Time = time;
        }
    }
}
