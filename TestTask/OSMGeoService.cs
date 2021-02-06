using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace TestTask
{
    class OSMGeoService : IGeoService
    {
        private readonly HttpClient client;

        public OSMGeoService()
        {
            client = new HttpClient();
            SetDefaultHeaders();
        }

        public List<IGeoServiceResponse> GetByAddress(string address)
        {
            Uri uri = new Uri($"https://nominatim.openstreetmap.org/search?q={address}&format=json&polygon_geojson=1");

            HttpResponseMessage response = client.GetAsync(uri).Result;
            List<OsmGeoServiceResponse> responses = JsonConvert.DeserializeObject<List<OsmGeoServiceResponse>>(response.Content.ReadAsStringAsync().Result);

            List<IGeoServiceResponse> result = new List<IGeoServiceResponse>(responses);
            return result;
        }

        private void SetDefaultHeaders()
        {
            client.DefaultRequestHeaders.Add("User-Agent", "C# console program");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}


