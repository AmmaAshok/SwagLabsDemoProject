using OpenQA.Selenium;
using SwagClassLib;
using System.Text;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using SwagClassLib;
using System.Configuration;

namespace SwagClassLib
{
    public  class CrossBrowser
   {
      private static IWebDriver _driver;
      private static string baseURL = ConfigurationManager.AppSettings["url"];
      private static string browser = ConfigurationManager.AppSettings["browser"].ToString();
        public static void Init()
        {
          switch (browser)
           {
             case "Chrome":
                 _driver = new ChromeDriver();
              break;
             case "IE":
                 _driver = new InternetExplorerDriver();
             break;
             case "Firefox":
                 _driver = new FirefoxDriver();
             break;
            }
          _driver.Manage().Window.Maximize();
        }
        public static void Goto(string url)
          {
             _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
          }
         
          public static string Title
          {
             get { return _driver.Title; }
           }
            public static IWebDriver getDriver
          {
           get { return _driver; }
          }
    
           public static void Close()
           {
           _driver.Quit();

          }
   }
}