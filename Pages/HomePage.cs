using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TM_Ava.Helpers;

namespace TM_Ava.Pages
{
	class HomePage
	{
		IWebDriver driver;
		public HomePage(IWebDriver driver)
		{
			this.driver = driver;
		}

		public void navigateTM()
		{
			//Navigate to TM page
			driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a")).Click();
			driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a")).Click();

			// Wait 1 second
			Wait.waituntil(driver, 1, "//*[@id='container']/p/a", "XPath");
		}
	}
}
