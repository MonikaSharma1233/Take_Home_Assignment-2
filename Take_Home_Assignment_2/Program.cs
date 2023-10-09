
using System;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
namespace Take_Home_Assignment_2
{
    public class Program
    {
        public static void Main(String[] args)
        {
            CSVHelper.BearProduction();
            System.Console.ReadKey();
        }
    }
    public class Model
    {
        public string Grains { set; get; }
        public string Date { set; get; }
        public string Manager { set; get; }

        public int BearProduction { set; get; }
        

    }
    public class Model1
    {
        public string Grains { set; get; }
        public string Date { set; get; }
        public string Manager { set; get; }

        public int BearProduction { set; get; }
        public double YearMean { get; set; }
        public double YearMedian { get; set; }
        public Boolean Status { get; set; }


    }
    public class CSVHelper
        {

            public static void BearProduction()
            {
                string importpart = "D:\\Monika's Pojects\\Take_Home_Assignment_2\\Utility\\Output_v1.1.csv";
                string exportpath = "D:\\Monika's Pojects\\Take_Home_Assignment_2\\Utility\\Output_v1.0.csv";

                //Reading data from CSV File
                using (var reader = new StreamReader(importpart))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            using (var csv1 = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                    var records = csv.GetRecords<Model>().ToList();
                    Console.WriteLine("Data read from CSV file sucessfully. ");
                    var records1 = csv1.GetRecords<Model1>().ToList();

                    using (var writer = new StreamWriter(exportpath))
                    using (var csv2= new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                  
                        string headerstring = "Grains,Date,Manager,BeerProduction,YearMean,YearMedian,IsBP>YMean";
                    //using linq for find  yearmean and yearmediun of from list.
                    int sum = 0;
                    int counter = 0;
                    string status;

                    foreach (Model model in records)
                    {
                        var bearproductionvalue = from records in model.AsEnumerable() select records.Field<int>("BearProduction") && records.Date.month is same;
                        sum = sum + bearproductionvalue;
                        counter++;
                     }
                    int yearmean = sum / counter;
                    int yearmedian = (counter + 1) / 2;
                    if(sum>yearmean)
                    {
                        status = "Yes";
                    }
                    else
                    {
                        status = "No";
                    }

                    string data = headerstring + yearmean + yearmedian + status;
                    csv2.WriteRecords(data);
                    foreach (Model1 model1 in records)
                    {
                       
                       Console.WriteLine(model1.Grains);
                        Console.WriteLine(model1.Date);
                       Console.WriteLine(model1.Manager);
                       Console.WriteLine(model1.BearProduction);
                        Console.WriteLine(model1.YearMean);
                        Console.WriteLine(model1.YearMedian);
                        Console.WriteLine(model1.Status);

                    }


                }

            }




            }

        }
    



}