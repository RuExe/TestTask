using System;

namespace TestTask
{
    interface IGeoServiceResponce
    {
        public Geojson geojson { get; set; }
    }

    public class Geojson
    {
        public string type { get; set; }
        public float[][][][] coordinates { get; set; }
    }
}
