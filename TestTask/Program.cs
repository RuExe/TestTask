using System;
using System.IO;
using System.Collections.Generic;

namespace TestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Example*/
            string adress = "Москва ЮВАО";
            string fileName = "test.txt";
            int frequency = 3;

            List<IGeoServiceResponce> list = new OSMGeoService().GetByAdress(adress);
            List<IGeoServiceResponce> responce = GeoResponcePoligonSimplifier.simplify(list, frequency);

            Console.WriteLine(1);
            /* using (StreamWriter sw = new StreamWriter(fileName))
             {
                 foreach (GeoServiceResponce item in list) {
                     string temp = JsonConvert.SerializeObject(item);
                     Console.WriteLine(temp);
                 }
             }*/
        }
    }
}
