using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TM_Ava.Helpers
{
	class Wait
	{
		// Generic Wait Method
		public static void waituntil(IWebDriver driver, int timeSeconds, string locatorValue, string locatorType)
		{
			if (locatorType == "XPath")
			{
				WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeSeconds));
				wait.Until(d => d.FindElement(By.XPath(locatorValue)));
			}
			else if (locatorType == "Id")
			{
				WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeSeconds));
				wait.Until(d => d.FindElement(By.Id(locatorValue)));
			}
			else if (locatorType == "CssSelector")
			{
				WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeSeconds));
				wait.Until(d => d.FindElement(By.CssSelector(locatorValue)));
			}
		}
	}
}
