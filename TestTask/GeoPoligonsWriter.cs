using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TestTask
{
    class GeoPoligonsWriter
    {
        public void write(string fileName, List<IGeoServiceResponce> responses)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                foreach (IGeoServiceResponce response in responses)
                {
                    sw.Write(JsonConvert.SerializeObject(response.geojson.coordinates));
                }
            }
        }
    }
}
