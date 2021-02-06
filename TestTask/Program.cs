using System;
using System.Collections.Generic;

namespace TestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            // Example
            string address = "Москва ЮВАО";
            string fileName = "test.txt";
            int frequency = 3;

            /*            Console.WriteLine("Enter address: ");
                        string address = Console.ReadLine();
                        Console.WriteLine("Enter file name: ");
                        string fileName = Console.ReadLine();
                        Console.WriteLine("Enter frequency: ");
                        int frequency = Convert.ToInt32(Console.ReadLine());*/

            List<IGeoServiceResponse> list = new OSMGeoService().GetByAddress(address);
            List<IGeoServiceResponse> response = GeoResponsePolygonSimplifier.Simplify(list, frequency);
            new GeoPolygonsWriter().Write(fileName, response);
        }
    }
}