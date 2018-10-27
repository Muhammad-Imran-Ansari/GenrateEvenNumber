using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortCSVData
{
    public class Record
    {
        public int Device_ID { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public DateTime? Date
        {
            get;
            set;
        }
        public override string ToString()
        {
            return string.Format("{0},{1},{2},{3},{4},{5}", Device_ID, A, B, C, D, Date);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.Write("Please provide input and out put file. for example SortCSVData input.csv output.csv");
                Console.ReadLine();
                return;
            }
            string inFile = args[0];
            string outFile = args[1];

            var data = from l in File.ReadAllLines(inFile).Skip(1)                     
                        let f = l.Split(new[] { ','})
                        select new Record
                        {
                            Device_ID = int.Parse( f[0]),
                            A = f[1],
                            B = f[2],
                            C = f[3],
                            D = f[4],
                            Date = ParseDate ( f[5]),
                        };
            //Sort by ID  and date.
            data = data.OrderBy(p => p.Device_ID).ThenBy(p=>p.Date);
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(outFile))
            {
                file.WriteLine("Device_ID,A,B,C,D,Date");
                foreach (Record a in data)
                {
                    file.WriteLine(a.ToString());
                }
            }  
        }

        private static DateTime? ParseDate(string p)
        {
            if (string.IsNullOrEmpty(p)) return null;
            return DateTime.Parse(p);
        }
    }
}
