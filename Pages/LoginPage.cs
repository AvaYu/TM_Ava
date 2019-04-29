using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM_Ava.Helpers;

namespace TM_Ava.Pages
{
    class LoginPage
    {
		private IWebDriver driver;

		public LoginPage(IWebDriver driver)
		{
			this.driver = driver;
		}

		IWebElement username => driver.FindElement(By.Id("UserName"));
		IWebElement password => driver.FindElement(By.Id("Password"));


		public void LoginSteps()
        {
            // Launch the URL
            //driver.Navigate().GoToUrl("http://horse-dev.azurewebsites.net/Account/Login?ReturnUrl=%2f");
			driver.Navigate().GoToUrl(ExcelHelpers.ReadData(2, "URL"));

			// Enter Valid Username
			//IWebElement username = driver.FindElement(By.Id("UserName"));
			//username.SendKeys("hari");
			username.SendKeys(ExcelHelpers.ReadData(2, "Username"));

			// Enter Valid Password
			//IWebElement password = driver.FindElement(By.Id("Password"));
			//password.SendKeys("123123");
			password.SendKeys(ExcelHelpers.ReadData(2, "Password"));

			try
			{
				// Click the Login Button
				IWebElement loginButton = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
				loginButton.Click();

				// Verify if you are on the homescreen
				driver.Manage().Window.Maximize();

				// Identify 'hello hari'
				IWebElement helloHomepage = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));

				Assert.That(helloHomepage.Text, Is.EqualTo("Hello hari!"));
			}
			catch(Exception e)
			{
				Console.WriteLine("Error occured while launching the homepage",e.Message);
			}
        }
    }
}