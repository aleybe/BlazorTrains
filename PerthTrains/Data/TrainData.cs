using System;

namespace PerthTrains.Data
{
    public class TrainData
    {
        public string TrainLine { get; set; }
        public string TrainStation { get; set; }
        
        public string StatusDetail { get; set; }
        public string DestinationStation { get; set; }
        public int Platform { get; set; }
        public int NumberOfCars { get; set; }
        public int Status { get; set; }
        
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
    }
}