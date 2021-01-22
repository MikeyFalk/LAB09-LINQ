using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;




namespace LAB09_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../data.json";
                string readFile = File.ReadAllText(path);
            List<Feature> newYork = new List<Feature>();

            Example places = JsonConvert.DeserializeObject<Example>(readFile);
            Console.WriteLine("Hello World!");
            
            BasicLINQ();
        }

        static void BasicLINQ(Example ex)
        {

            counter = 0;
            var query = from Feature in ex.features
                         where Feature.properties.neighborhood != ""
                         select Feature.properties.neighborhood;

            
            foreach(var item in query)
            {
                counter++;
                Console.WriteLine(item);
            }
        }
    }
}
