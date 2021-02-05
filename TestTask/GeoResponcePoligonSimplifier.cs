using System;
using System.Collections.Generic;

namespace TestTask
{
    static class GeoResponcePoligonSimplifier
    {
        public static List<IGeoServiceResponce> simplify(List<IGeoServiceResponce> list, int frequency)
        {
            List<IGeoServiceResponce> result = new List<IGeoServiceResponce>();

            foreach (OSMGeoServiceResponce item in list)
                result.Add(simplify(item, frequency));

            return result;
        }

        public static OSMGeoServiceResponce simplify(OSMGeoServiceResponce list, int frequency)
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
                    for (int i = frequency - 1, finded = 0; i < length; i += frequency)
                    {
                        result[area][coordinate][finded++] = (float[])coordinatesList[area][coordinate][i].Clone();
                    }
                }
            }

            list.geojson.coordinates = result;
            return list;
        }
    }
}
