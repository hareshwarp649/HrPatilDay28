using System;
using System.Collections.Generic;
using System.Linq;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace TddAddressBook
{
    public  class CsvHandle
    {
        public static void ImplementCSVDataHandling()
        {
            string importPath = @"C:\Users\ADMIN\source\repos\ThirdPartyLybrary\TddAddressBook\Book1.csv";
            string exportpath = @"C:\Users\ADMIN\source\repos\ThirdPartyLybrary\TddAddressBook\Export.csv";
            StreamReader  reader = new StreamReader(importPath);
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
