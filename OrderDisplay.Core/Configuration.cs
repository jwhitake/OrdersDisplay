using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace OrderDisplay.Core
{
    public class Configuration 
    {
        public string ConnectionString { get; set; }
        public string ApiUrl { get; set; }
        public Configuration()
        {
            var configurationBuilder = new ConfigurationBuilder()
                 .SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                 .AddJsonFile("settings.json", false, true);

            var configuration = configurationBuilder.Build();

            ConnectionString = configuration["ConnectionString"];
            ApiUrl = configuration["ApiUrl"];
        }
        

    }
}
