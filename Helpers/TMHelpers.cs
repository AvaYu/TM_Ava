using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TM_Ava.Helpers
{
	class TMHelpers
	{
		public static void AddTM(IWebDriver driver, string code, string description, string price)
		{
			// Click Create New button 
			driver.FindElement(By.XPath("//*[@id='container']/p/a")).Click();

			// Click dropdown box from TypeCode
			driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]")).Click();

			// Change TypeCode from Material to Time
			driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[2]")).Click();

			// Input Code Name
			driver.FindElement(By.Id("Code")).SendKeys(code);

			// Input Description Name
			driver.FindElement(By.Id("Description")).SendKeys(description);

			// Input Price Number
			driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]")).SendKeys(price);

			// Click Save Button
			driver.FindElement(By.XPath("//*[@id='SaveButton']")).Click();

			// Wait 1 second 
			Wait.waituntil(driver, 1, "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", "XPath");
		}		

		public static void ChangeRecordTM(IWebDriver driver, string code, string description, string price)
		{
			// Click Edit Button
			driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[1]")).Click();

			// Click TypeCode Menu Item
			driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]")).Click();

			// Input Code Name
			driver.FindElement(By.Id("Code")).Clear();
			driver.FindElement(By.Id("Code")).SendKeys(code);

			// Input Description Name
			driver.FindElement(By.Id("Description")).Clear();
			driver.FindElement(By.Id("Description")).SendKeys(description);

			// Input Price Number
			driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]")).Clear();
			driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]")).SendKeys(price);

			// Click Save Button
			driver.FindElement(By.XPath("//*[@id='SaveButton']")).Click();

			// Wait 1 second 
			Wait.waituntil(driver, 1, "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", "XPath");
		}

		//generic method to see if we have a TM record
		public static bool HaveRecordTM(IWebDriver driver)
		{
			IWebElement firstRecord = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]"));
			if (firstRecord.Displayed)
			{
				return true;
			}
			return false;
		}
	}
}