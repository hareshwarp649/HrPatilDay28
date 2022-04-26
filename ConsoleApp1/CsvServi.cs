using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
     class CsvServi
    {
        public static void CSVServi(Dictionary<string, List<AddressBook>> addressbooknames)
        {
            // Csv File path in a string
            string csvFilePath = @"C:\Users\ADMIN\source\repos\ThirdPartyLybrary\TddAddressBook\Book1.csv";
            File.WriteAllText(csvFilePath, string.Empty);
            // over Dictionary Values
            foreach (KeyValuePair<string, List<AddressBook>> kvp in addressbooknames)
            {
                //Open file in Append Mode for adding List elements
                using (var stream = File.Open(csvFilePath, FileMode.Append))
                using (var writer = new StreamWriter(stream))
                using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
                    //Iterate over each value
                    foreach (var value in kvp.Value)
                    {
                        //Create List to add Records
                        List<AddressBook> list = new List<AddressBook>();
                        list.Add(value);
                        //Write List to CSV File
                        csvWriter.WriteRecords(list);
                    }
                //Print a newline
                csvWriter.NextRecord();
            }
            //Reading a Csv File
            Console.WriteLine("Reading A Csv File And Contents Of AddressBook");
            Console.WriteLine("-----------------------------------------------------------------");
            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                //Get all records from Csv File
                var records = csv.GetRecords<AddressBook>().ToList();

                foreach (AddressBook member in records)
                {
                    //skip Headers in Csv File
                    if (member.firstName == "firstName")
                    {
                        Console.WriteLine("\n");
                        continue;
                    }
                    //Convert each Value to string and Print to Console
                    Console.WriteLine(member.ToString());
                }

            }
        }
    }
}
