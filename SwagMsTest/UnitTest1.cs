using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SwagClassLib;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


namespace SwagMstest
{
    [TestClass]
    public class UnitTest1
    {
    
        IWebDriver driver;

        [TestInitialize]
        public void start_Browser()

        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            Thread.Sleep(2000);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(10);
            //LogInPage log =new LogInPage(driver);
            //log.username("standard_user");
            //log.password("secret_sauce");
            //log.loginbutton();
            
        }
        
        [DataTestMethod]
        [Ignore]
        
        [DataRow("standard_user","secret_sauce")]
        [DataRow("locked_out_user","secret_sauce")]
        [DataRow("problem_user","secret_sauce")]
        [DataRow("performance_glitch_user","secret_sauce")]
        
        public void Login_(string user, string pass)
        {
            LogInPage log =new LogInPage(driver);
            log.username(user);
            log.password(pass);
            log.loginbutton();
            Thread.Sleep(3000);
        } 
    
        [TestMethod]
        [Ignore]
        public void Product()
        {   
            LogInPage log =new LogInPage(driver);
            log.username("standard_user");
            log.password("secret_sauce");
            log.loginbutton();
            SwagClassLib.ProductsPage product = new SwagClassLib.ProductsPage(driver);
            product.backpackcart();
            product.bikelightcart();
            Thread.Sleep(3000);
            product.cartlink();
            Thread.Sleep(5000);
        } 
        
        [DataTestMethod]
        [Ignore]
        public void CartPage()
        {   
            LogInPage log =new LogInPage(driver);
            log.username("standard_user");
            log.password("secret_sauce");
            log.loginbutton();
            Thread.Sleep(2000);
            SwagClassLib.ProductsPage product = new SwagClassLib.ProductsPage(driver);
            product.backpackcart();
            product.bikelightcart();
            Thread.Sleep(3000);
            product.cartlink();
            Thread.Sleep(5000);
            SwagClassLib.CartPage YCpage =new SwagClassLib.CartPage(driver);
            YCpage.CheckOut();
            Thread.Sleep(2000);
            SwagClassLib.CheckOutPage COpage =new SwagClassLib.CheckOutPage(driver);
            COpage.FirstName("abc");
            COpage.LastName("abc");
            COpage.PostalCode("123");
            COpage.Continue();
            COpage.Finish();
            Thread.Sleep(2000);
        }

        [DataTestMethod]
        [Ignore]
        [DataRow ("Abc","xyz","123")]

        public void CheckOut_(string Fname, string Lname, string Pin)
        {
           SwagClassLib.CheckOutPage COpage =new SwagClassLib.CheckOutPage(driver);
            COpage.FirstName(Fname);
            COpage.LastName(Lname);
            COpage.PostalCode(Pin);
            COpage.Continue();
            COpage.Finish();
        }

        [DataTestMethod]
        [Ignore]
        public void BackHome()
        {   
            LogInPage log =new LogInPage(driver);
            log.username("standard_user");
            log.password("secret_sauce");
            log.loginbutton();
            Thread.Sleep(2000);
            SwagClassLib.ProductsPage product = new SwagClassLib.ProductsPage(driver);
            product.backpackcart();
            product.bikelightcart();
            Thread.Sleep(3000);
            product.cartlink();
            Thread.Sleep(5000);
            SwagClassLib.CartPage YCpage =new SwagClassLib.CartPage(driver);
            YCpage.CheckOut();
            Thread.Sleep(2000);
            SwagClassLib.CheckOutPage COpage =new SwagClassLib.CheckOutPage(driver);
            COpage.FirstName("abc");
            COpage.LastName("abc");
            COpage.PostalCode("123");
            COpage.Continue();
            COpage.Finish();
            Thread.Sleep(2000);
            SwagClassLib.BackHome bhpage= new SwagClassLib.BackHome(driver);
            bhpage.Backhome();
            Thread.Sleep(1000);
        }

        [TestMethod]
        [Ignore
        ]
        public void Products()
        {   
            LogInPage log =new LogInPage(driver);
            log.username("standard_user");
            log.password("secret_sauce");
            log.loginbutton();
            SwagClassLib.ProductsPage product = new SwagClassLib.ProductsPage(driver);
            product.backpackcart();
            product.bikelightcart();
            Thread.Sleep(3000);
            product.cartlink();
            Thread.Sleep(5000);
            SwagClassLib.CartPage YCpage =new SwagClassLib.CartPage(driver);
            YCpage.CheckOut();
            Thread.Sleep(2000);
            SwagClassLib.CheckOutPage COpage =new SwagClassLib.CheckOutPage(driver);
            COpage.FirstName("abc");
            COpage.LastName("abc");
            COpage.PostalCode("123");
            COpage.Continue();
            COpage.Finish();
            Thread.Sleep(2000);
            product.menubtn();
            product.logoutlink();
            product.FiltersDropdown();
            Thread.Sleep(5000);
        } 

        [DataTestMethod]   
        [ignore]
        [DataRow("problem_user","secret_sauce")]
        public void problemuser(string user, string pass)
        {
            LogInPage log =new LogInPage(driver);
            log.username(user);
            log.password(pass);
            log.loginbutton();
            Thread.Sleep(3000);
           SwagClassLib.ProductsPage product = new SwagClassLib.ProductsPage(driver);
            string actualbackpackimg =product.puserbackpackimage();
            string expectedbackpackimg = "/static/media/sauce-backpack-1200x1500.34e7aa42.jpg";
            Assert.AreEqual(expectedbackpackimg,actualbackpackimg,"problem user image doesnot match");
        } 
         
        [TestMethod]
        public void locked_out_user()
        {
         LogInPage log =new LogInPage(driver);
         log.username("locked_out_user");
         log.password("secret_sauce");
         log.loginbutton();
         Thread.Sleep(6000);
         string actual4 =log.locked_out_user();
         string expectedname4 ="Epic sadface: Sorry, this user has been locked out.";
         Assert.AreEqual(expectedname4,actual4,"method fail");
         Thread.Sleep(2000);
         log.locked_out_user();
        }
        
        [TestMethod]
        public void dropdown()
        {   
            LogInPage log =new LogInPage(driver);
            log.username("standard_user");
            log.password("secret_sauce");
            log.loginbutton();
            SwagClassLib.ProductsPage product = new SwagClassLib.ProductsPage(driver);
            product.FiltersDropdown();
            Thread.Sleep(5000);
        }

        [TestMethod]
        [Ignore]
        public void performance_glitch_user()
        {
          LogInPage log =new LogInPage(driver);
         log.username("performance_glitch_user");
         log.password("secret_sauce");
         log.loginbutton();
         Thread.Sleep(6000);  
        }

        [TestCleanup]
        public void cleanup()
        {
            driver.Quit();
        }

        
        
    }
}
