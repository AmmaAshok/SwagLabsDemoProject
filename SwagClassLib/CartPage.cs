using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SwagClassLib
{
    public class CartPage
    {
        private IWebDriver _driver;

        [FindsBy(How=How.XPath, Using="//span[@class='title']")]
        private IWebElement _yourcart;
        
        [FindsBy(How= How.Id, Using="checkout")]
        private IWebElement _CheckOut;

        public CartPage (IWebDriver driver)
        {
          
         _driver =driver; 
         PageFactory.InitElements(_driver,this);
        }

        public void CheckOut()
        {
            _CheckOut.Click();
        }

        public string CartText()
        {
           string actual2=_yourcart.Text;
            return actual2;
        }
    }
}