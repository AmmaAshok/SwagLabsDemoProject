using System;
using OpenQA.Selenium;
using System.Threading;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;


namespace SwagClassLib
{
    public class LogInPage
    {
        private IWebDriver _driver;
        //username TextBox
        [FindsBy(How=How.Id, Using="user-name")]
        private IWebElement _username;
         //Password TextBox
        [FindsBy(How=How.Id, Using="password")]
        private IWebElement _password;
         //LogIn button
        [FindsBy(How=How.Id, Using="login-button")]
        private IWebElement _loginbutton;

        [FindsBy(How= How.XPath, Using="//h3[@data-test='error']")]
        private IWebElement _Locked_out_user;
        
        public LogInPage(IWebDriver driver)
        {
            _driver =driver; 
        PageFactory.InitElements(_driver,this);
        }

        public void username(string uname)
        {
        _username.Clear();
        _username.SendKeys(uname);
        }
        
        public void password(string upassword)
        {
        _password.Clear();
        _password.SendKeys(upassword);
        }

        public void loginbutton()
        {
         _loginbutton.Click();
        }

        public string locked_out_user()
        {
            string actual4 =  _Locked_out_user.Text;
            return actual4;
        }

        public string getPageTitle()
        {
            return _driver.Title;
        }

        
    }
}

