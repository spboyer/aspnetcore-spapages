using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
// Startup test
using System.Net.Http;
using System.Diagnostics;

namespace spapages
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var stopwatch = Stopwatch.StartNew();

      var host = BuildWebHost(args);

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

    public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .Build();
  }
}
