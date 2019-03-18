﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace CloudWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://*:53296") // <--add urls
                .Build();
    }
}