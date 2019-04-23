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
		public void navigateTM()
		{
			//Navigate to TM page
			CommonDriver.driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a")).Click();
			CommonDriver.driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a")).Click();

			// Wait 1 second
			Wait.waituntil(CommonDriver.driver, 1, "//*[@id='container']/p/a", "XPath");
		}
	}
}
