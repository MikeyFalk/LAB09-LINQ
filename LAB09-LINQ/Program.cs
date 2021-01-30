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
            ListAllNeighborhoods(places);
            ListAllNamedNeighborhoods(places);
            RemoveDuplicates(places);
            MethodListAllNeighborhoods(places);

            // 1. output all the neighborhoods in the data (should be 147)

            static void ListAllNeighborhoods(Example places)
            {
                var query = from Feature in places.features
                            select Feature.properties.neighborhood;
                int count = 1;
                foreach (var neighborhood in query)
                {
                    Console.WriteLine($"{count}: {neighborhood}");
                    count++;
                }
            }
            
           
        }

        // 2. Filter out all the neighborhoods that do not have any names (Should be 143)

        static void ListAllNamedNeighborhoods(Example places)
        {

            var filteredList = from Feature in places.features
                               where Feature.properties.neighborhood != ""
                               select Feature.properties.neighborhood;

            int count = 1;
            foreach (var neighborhood in filteredList)
            { 
             Console.WriteLine($"{count}: {neighborhood}");
                count++;
            }
                
                
        }

        // 3. Remove the duplicates (Should be 39)

        static void RemoveDuplicates(Example places)
        {
            var deDuped = (from Feature in places.features
                          where (Feature.properties.neighborhood != "")
                          select (Feature.properties.neighborhood)).Distinct();

            int count = 1;
            foreach (var neighborhood in deDuped)
            {
                Console.WriteLine($"{count}: {neighborhood}");
                    count++;
            }

        }
        // 4. Rewrite the queries from above and consolidate into a single query


        // 5. Rewrite at least one of these questions only using the opposing method (LINQ Query Statements instead of method calls)
        static void MethodListAllNeighborhoods(Example places)
        {
            var query = places.features.Select(feature => feature.properties.neighborhood);
            int count = 1;
            foreach (var neighborhood in query)
            {
                Console.WriteLine($"{count}: {neighborhood}");
                count++;
            }
        }




        static void BasicLINQ(Example ex)
        {

            int counter = 0;
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
