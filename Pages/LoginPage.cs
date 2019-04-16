﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM_Ava.Helpers;

namespace TM_Ava.Pages
{
    class LoginTest
    {
        public void LoginSteps()
        {
            // Launch the URL
            CommonDriver.driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/Account/Login?ReturnUrl=%2f");

            // Enter Valid Username
            IWebElement username = CommonDriver.driver.FindElement(By.Id("UserName"));
            username.SendKeys("hari");

            // Enter Valid Password
            IWebElement password = CommonDriver.driver.FindElement(By.Id("Password"));
            password.SendKeys("123123");

            // Click the Login Button
            IWebElement loginButton = CommonDriver.driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
            loginButton.Click();

            // Verify if you are on the homescreen
            CommonDriver.driver.Manage().Window.Maximize();

            // Identify 'hello hari'
            IWebElement helloHomepage = CommonDriver.driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));

            if (helloHomepage.Text == "Hello hari!")
            {
                Console.WriteLine("Hello hari displayed, Test LoginPage Passed");
            }
			else
			{
				Console.WriteLine("Text didn't match, Test LoginPage Failed");
			}
        }
    }
}