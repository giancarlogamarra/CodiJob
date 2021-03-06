﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace CodiJobServices
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseStartup<Startup>()
                .UseIISIntegration()
                .UseDefaultServiceProvider(options =>
                options.ValidateScopes = false)
                .Build();
    }
}
