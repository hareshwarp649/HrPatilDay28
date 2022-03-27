using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Threading.Tasks;

namespace TddAddBookJson15
{
    public class CsvJsonHandler
    {
        public static void ImplementCSVDataHandling()
        {
            string importPath =@"";
            string exportpath = @"C:\Users\91936\source\repos\ThirdPartyAccess\ThirdPartyAccess\ExportCSV.csv";
            StreamReader reader = new StreamReader(importPath);
            //using var reader = new StreamReader(importPath);
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
                Console.WriteLine(("\n Now reading from csv file and write to csv file"));
                using (var writer = new StreamWriter(exportpath))
                using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(records);
                }

            }
        }
    }
}
