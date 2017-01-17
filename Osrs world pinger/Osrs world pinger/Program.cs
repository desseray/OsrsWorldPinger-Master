using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Osrs_world_pinger
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 1;
            string filename = @"PingLog.csv";
            {
                using (var writer = new StreamWriter(filename, false))
                {
                    writer.WriteLine("Status, Time, Address");
                    Console.WriteLine("Pinging servers");
                    pingMethod(writer, count);
              
                }
            }
        }
        public static void pingMethod(StreamWriter writer, int count)
        {
            try
            {
                Ping myPing = new Ping();
                
                while (count < 96)
                {
                    string server = "oldschool" + count + ".runescape.com";
                    Console.WriteLine("Pinging world " + count);
                    PingReply reply = myPing.Send(server, 1000);
                    
                    if (reply != null)
                    {
                        writer.WriteLine("{0}, {1}, {2}", reply.Status, reply.RoundtripTime, "world " + count );
                    }
                    count++;
                }
                Console.WriteLine("Success");
            }
            catch
            {
                Console.WriteLine("World doesn't exist");
                count++;
                pingMethod(writer, count);
            }
        }
    }
}
