using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
// Stopwatch Test
using System.Diagnostics;
using System.Net.Http;

namespace mvcspa
{
    public class Program
    {
        public static void Main(string[] args)
        {
                // simple benchmark test
                var stopwatch = Stopwatch.StartNew();

                var host = new WebHostBuilder()
                    .UseKestrel()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseIISIntegration()
                    .UseStartup<Startup>()
                    .Build();


                host.Start();

                using (var http = new HttpClient())
                {
                    var home = http.GetStringAsync("http://localhost:5000").Result;
                    var headingLocation = home.IndexOf("Home Page");
                    if (headingLocation < 0)
                    {
                        throw new Exception("Hmmm, can't find home page text");
                    }
                }

                host.Dispose();
                stopwatch.Stop();

                Console.WriteLine($"Time to start-up, retrieve home page, and shutdown: {stopwatch.Elapsed}");

            }
        }
    }

