using System.Collections.Generic;

namespace PerthTrains.Data
{
    public static class TrainConstants
    {
        public static readonly Dictionary<string, List<string>> TrainStationsAndLines = new Dictionary<string, List<string>>
        {
            { "Mandurah Stn", new List<string>{"Mandurah Line"} },
            { "Warnbro Stn", new List<string>{"Mandurah Line"} },
            { "Rockingham Stn", new List<string>{"Mandurah Line"} },
            { "Wellard Stn", new List<string>{"Mandurah Line"} },
            { "Kwinana Stn", new List<string>{"Mandurah Line"} },
            { "Murdoch Stn", new List<string>{"Mandurah Line"} },
            { "Cockburn Central Stn", new List<string>{"Mandurah Line"} },
            { "Aubin Grove Stn", new List<string>{"Mandurah Line"} },
            { "Perth Underground Stn", new List<string>{"Mandurah Line"} },
            { "Bull Creek Stn", new List<string>{"Mandurah Line"} },
            { "Canning Bridge Stn", new List<string>{"Mandurah Line"} }
        };
    }
}