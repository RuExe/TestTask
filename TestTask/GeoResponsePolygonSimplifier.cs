using System;
using System.Collections.Generic;

namespace TestTask
{
    static class GeoResponsePolygonSimplifier
    {
        public static List<IGeoServiceResponse> Simplify(List<IGeoServiceResponse> list, int frequency)
        {
            List<IGeoServiceResponse> result = new List<IGeoServiceResponse>();

            foreach (OsmGeoServiceResponse item in list)
            {
                result.Add(Simplify(item, frequency));
            }

            return result;
        }

        public static IGeoServiceResponse Simplify(IGeoServiceResponse list, int frequency)
        {
            if (frequency <= 1)
            {
                throw new Exception("Frequency must be more then 1");
            }

            float[][][][] coordinatesList = list.geojson.coordinates;

            float[][][][] result = new float[coordinatesList.Length][][][];

            for (int area = 0; area < coordinatesList.Length; area++)
            {
                result[area] = (float[][][])coordinatesList[area].Clone();
                for (int coordinate = 0; coordinate < coordinatesList[area].Length; coordinate++)
                {
                    int length = coordinatesList[area][coordinate].Length;
                    result[area][coordinate] = new float[length / frequency][];
                    for (int i = frequency - 1, found = 0; i < length; i += frequency)
                    {
                        result[area][coordinate][found++] = (float[])coordinatesList[area][coordinate][i].Clone();
                    }
                }
            }

            list.geojson.coordinates = result;
            return list;
        }
    }
}
