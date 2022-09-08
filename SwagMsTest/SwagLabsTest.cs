using Microsoft.VisualStudio.TestTools.UnitTesting;
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
using System.Configuration;
using System.Collections.Specialized;


namespace SwagMstest
{
   [TestClass]
    public class SwagLabsTest
    {
    
        IWebDriver driver;

        [TestInitialize]
        public void start_Browser()

        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(SwagClassLib.Constant.SwagUrl);
            Thread.Sleep(2000);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(30);
        }
        
        
        [TestMethod]
        [Ignore]
        
        /*[DataRow("standard_user","secret_sauce")]
        [DataRow("locked_out_user","secret_sauce")]
        [DataRow("problem_user","secret_sauce")]
        [DataRow("performance_glitch_user","secret_sauce")] */
        
        public void LogInPage() //string user, string pass
        {
            LogInPage log =new LogInPage(driver);
            log.username(SwagClassLib.Constant.username);
            log.password(SwagClassLib.Constant.password);
            log.loginbutton();
            string actualoginltitle = log.getPageTitle();
            string expectedlogintitle="Swag Labs";
            Assert.AreEqual(expectedlogintitle,actualoginltitle,"title doesnot match");
            Thread.Sleep(5000);
        
        } 
    
        [TestMethod]
        [Ignore]
        public void Product()
        {   
            LogInPage log =new LogInPage(driver);
            log.username(SwagClassLib.Constant.username);
            log.password(SwagClassLib.Constant.password);
            log.loginbutton();
            SwagClassLib.ProductsPage product = new SwagClassLib.ProductsPage(driver);

            string actualproducttitle = product.ProductTitle();
            string expectedproducttitle="PRODUCTS";
            Assert.AreEqual(actualproducttitle,expectedproducttitle,"product doesnot match");

            product.backpackcart();
            product.bikelightcart();
            product.cartlink();
        } 
        
        [DataTestMethod]
    
        public void CartPage()
        {   
            LogInPage log =new LogInPage(driver);
            log.username(SwagClassLib.Constant.username);
            log.password(SwagClassLib.Constant.password);
            log.loginbutton();
            SwagClassLib.ProductsPage product = new SwagClassLib.ProductsPage(driver);
            product.backpackcart();
            product.bikelightcart();
            product.cartlink();
            SwagClassLib.CartPage YCpage =new SwagClassLib.CartPage(driver);
            string actualyourcart = YCpage.CartText();
            string expectedyourcart="Your Cart";
            Assert.AreEqual(actualyourcart,expectedyourcart,"yourcart doesnot match");
            YCpage.CheckOut();
            
        }

        [DataTestMethod]
        [Ignore]
        public void CheckOutPage()
        {  
            LogInPage log =new LogInPage(driver);
            log.username("standard_user");
            log.password("secret_sauce");
            log.loginbutton();
            SwagClassLib.ProductsPage product = new SwagClassLib.ProductsPage(driver);
            product.backpackcart();
            product.bikelightcart();
            product.cartlink();
            SwagClassLib.CartPage YCpage =new SwagClassLib.CartPage(driver);
            YCpage.CheckOut();
            SwagClassLib.CheckOutPage COpage =new SwagClassLib.CheckOutPage(driver);
            COpage.FirstName("Abc");
            COpage.LastName("xyz");
            COpage.PostalCode("123");
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
            SwagClassLib.ProductsPage product = new SwagClassLib.ProductsPage(driver);
            product.backpackcart();
            product.bikelightcart();
            product.cartlink();
            SwagClassLib.CartPage YCpage =new SwagClassLib.CartPage(driver);
            YCpage.CheckOut();
            SwagClassLib.CheckOutPage COpage =new SwagClassLib.CheckOutPage(driver);
            COpage.FirstName("abc");
            COpage.LastName("abc");
            COpage.PostalCode("123");
            COpage.Continue();
            COpage.Finish();
            SwagClassLib.BackHome bhpage= new SwagClassLib.BackHome(driver);
            bhpage.Backhome();
        }

        [TestMethod]
        [Ignore]
        public void Products()
        {   
            LogInPage log =new LogInPage(driver);
            log.username("standard_user");
            log.password("secret_sauce");
            log.loginbutton();
            SwagClassLib.ProductsPage product = new SwagClassLib.ProductsPage(driver);
            product.backpackcart();
            product.bikelightcart();
            product.cartlink();
            SwagClassLib.CartPage YCpage =new SwagClassLib.CartPage(driver);
            YCpage.CheckOut();
            SwagClassLib.CheckOutPage COpage =new SwagClassLib.CheckOutPage(driver);
            COpage.FirstName("abc");
            COpage.LastName("abc");
            COpage.PostalCode("123");
            COpage.Continue();
            COpage.Finish();
            product.menubtn();
            product.logoutlink();
        
        } 

        [DataTestMethod]
        [Ignore]   
        [DataRow("problem_user","secret_sauce")]
        public void problemuser(string user, string pass)
        {
            LogInPage log =new LogInPage(driver);
            log.username(user);
            log.password(pass);
            log.loginbutton();
           SwagClassLib.ProductsPage product = new SwagClassLib.ProductsPage(driver);
            string actualbackpackimg =product.puserbackpackimage();
            string expectedbackpackimg = "/static/media/sauce-backpack-1200x1500.34e7aa42.jpg";
            Assert.AreEqual(expectedbackpackimg,actualbackpackimg,"problem user image doesnot match");
        } 
         
        [TestMethod]
        [Ignore]
        public void locked_out_user()
        {
         LogInPage log =new LogInPage(driver);
         log.username("locked_out_user");
         log.password("secret_sauce");
         log.loginbutton();
         string actual4 =log.locked_out_user();
         string expectedname4 ="Epic sadface: Sorry, this user has been locked out.";
         Assert.AreEqual(expectedname4,actual4,"method fail");
         log.locked_out_user();
        }
        
        [TestMethod]
        [Ignore]
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
          
        } 

        [TestCleanup]
        public void cleanup()
        {
            driver.Quit();
        } 
    }
        
} 
