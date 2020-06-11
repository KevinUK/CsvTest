using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CsvTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //could have a similar method to read from DB instead
            var addresses = ConvertCsvToObject();

            //Newtonsoft library can handle converting to and from XML too
            ConvertToJson(addresses);

            //Could create a method that converts XML/JSON back to CSV
        }

        private static List<NameAddress> ConvertCsvToObject()
        {
            var addresses = new List<NameAddress>();

            string filePath = Console.ReadLine();

            List<string> lines = System.IO.File.ReadAllLines(filePath).ToList();

            //could check lines[0] has the correct column names and return error to show the CSV is incorrect

            //remove header row
            lines.RemoveAt(0);

            foreach (string line in lines)
            {
                string[] column = line.Split(',');

                //could use AutoMapper to do this mapping automically
                addresses.Add(new NameAddress
                {
                    Address = new Address
                    {
                        Line1 = column[1],
                        Line2 = column[2]
                    },
                    Name = column[0]
                });
            }

            return addresses;
        }

        private static void ConvertToJson(List<NameAddress> addresses)
        {
            string json = JsonConvert.SerializeObject(addresses);

            Console.WriteLine(json);

        }
    }

    public class NameAddress
    {
        public string Name { get; set; }
        public Address Address {get; set; }
    }

    public class Address
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
    }
}
