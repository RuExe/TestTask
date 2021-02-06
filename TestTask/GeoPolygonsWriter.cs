using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TestTask
{
    class GeoPolygonsWriter
    {
        public void Write(string fileName, List<IGeoServiceResponse> responses)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                foreach (IGeoServiceResponse response in responses)
                {
                    sw.Write(JsonConvert.SerializeObject(response.geojson.coordinates));
                }
            }
        }
    }
}
