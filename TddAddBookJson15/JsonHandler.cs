using System;
using System.Collections.Generic;
using System.Linq;
using CsvHelper;
using System.Globalization;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TddAddBookJson15
{
    public class JsonHandler
    {
        public static void ImplementJSON()
        {
            string importPath = @"C:\Users\ADMIN\source\repos\ThirdPartyLybrary\TddAddBookJson15\Export.csv";
            string exportpath = @"C:\Users\ADMIN\source\repos\ThirdPartyLybrary\TddAddBookJson15\JsonTdd";
            StreamReader reader = new StreamReader(importPath);
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressBook>().ToList();
                Console.WriteLine(" Read data successfully from address.csv");
                foreach (AddressBook addressData in records)
                {
                    Console.WriteLine(" " + addressData.firstname);
                    Console.WriteLine(" " + addressData.lastname);
                    Console.WriteLine(" " + addressData.address);
                    Console.WriteLine(" " + addressData.state);
                    Console.WriteLine(" " + addressData.city);
                    Console.WriteLine(" " + addressData.code);



                }
                Console.WriteLine(("\n Now reading from csv file and write to Json file"));

                JsonSerializer serializer = new JsonSerializer();
                using (StreamWriter sw = new StreamWriter(exportpath))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, records);
                }
            }
        }
    }
}

  
    

