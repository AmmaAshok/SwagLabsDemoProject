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
    public class BackHome
    {
         private IWebDriver _driver;


        
        [FindsBy(How= How.XPath, Using="//button[contains(text(),'Back Home')]")]
        private IWebElement _Backhome;

        public BackHome (IWebDriver driver)
        {
          
         _driver =driver; 
         PageFactory.InitElements(_driver,this);
        }

        public void Backhome()
        {
         _Backhome.Click();
        }
    }
}