using Microsoft.VisualBasic;
using System.Security.AccessControl;
using System;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SwagClassLib
{
    public  static class Constant
    {
        public static string SwagUrl;
        public static string Browser;
        public static string username;
        public static string password;
        public static string Firstname;

        static Constant(){

          var configurationBuilder = new ConfigurationBuilder ();
          configurationBuilder.SetBasePath (Directory.GetCurrentDirectory ());
          configurationBuilder.AddJsonFile ("testdata.json", optional : true, reloadOnChange : true);
          IConfigurationRoot configuration = configurationBuilder.Build ();
          SwagUrl = configuration.GetSection ("ApplicationUnderTest:Url").Value;
          username = configuration.GetSection("ConnectionStrings:username").Value;
          password = configuration.GetSection("ConnectionStrings:password").Value;
        }
    }
}