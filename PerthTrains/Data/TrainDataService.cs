using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace PerthTrains.Data
{
    public class TrainDataService
    {
        public static async Task<TrainData[]> GetTrainsForAllLines(string trainStation)
        {
            List<string> TrainLines = new List<string> { "Mandurah Line", "Armadale Line", "Thornlie Line", "Fremantle Line", "Joondalup Line", "Midland Line" };

            List<TrainData> returnTrainData = new List<TrainData>();

            foreach (var trainline in TrainLines)
            {
                // Get the trains for this line.
                var currentTrainLineData = await GetTrainDataAsync(trainStation, trainline);
                returnTrainData.AddRange(currentTrainLineData);
            }

            return await Task.FromResult(returnTrainData.ToArray());
        }

        public static async Task<TrainData[]> GetTrainDataAsync(string trainStation, string trainLine)
        {
            HttpClient client = new HttpClient();

            try
            {

                trainStation = trainStation.Replace(" ", "+");
                trainLine = trainLine.Replace(" ", "+");

                var request = new HttpRequestMessage()
                {
                    RequestUri =
                        new Uri(
                            "https://www.transperth.wa.gov.au/DesktopModules/TrainLiveTimes/API/TrainLiveTimes/GetStationLiveStatus"), // TODO: Move this URL to the config pls
                    Method = HttpMethod.Post,
                    Content = new StringContent($"LineName={trainLine}&StationName={trainStation}", Encoding.UTF8,
                        "application/x-www-form-urlencoded")
                };

                request.Headers.Add("ModuleId", "5111");
                request.Headers.Add("TabId", "248");

                HttpResponseMessage response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                var results1 = JsonConvert.DeserializeObject<JObject>(responseBody);

                var returnResults = results1["data"]["StatusDetailList"]
                    .Select(i => new TrainData
                    {
                        DepartureTime = i["Departure"].Value<string>(),
                        DestinationStation = i["Destination"].Value<string>(),
                        Platform = i["Platform"].Value<int>(),
                        TrainLine = i["LineName"].Value<string>(),
                        NumberOfCars = i["Ncar"].Value<int>(),
                        StatusDetail = i["StatusDetail"].Value<string>()
                    }).ToArray();

                return await Task.FromResult(returnResults);
            }
            catch (Exception e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return new TrainData[] { };
            }
        }
    }
}