using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TM_Ava.Helpers
{
	class TMHelpers
	{
		// Generic Method to Create Record
		public static void addRecord(string code, string description, string price)
		{
			// Click Create New Button
			CommonDriver.driver.FindElement(By.XPath("//*[@id='container']/p/a")).Click();

			// Click TypeCode Menu Item
			CommonDriver.driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]")).Click();

			// Change TypeCode from Material to Time
			CommonDriver.driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[2]")).Click();

			// Input Code Name
			CommonDriver.driver.FindElement(By.Id("Code")).SendKeys(code);

			// Input Description Name
			CommonDriver.driver.FindElement(By.Id("Description")).SendKeys(description);

			// Input Price Number
			CommonDriver.driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]")).SendKeys(price);

			// Click Save Button
			CommonDriver.driver.FindElement(By.XPath("//*[@id='SaveButton']")).Click();

			// Wait 1 second 
			Wait.waituntil(CommonDriver.driver, 1, "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", "XPath");
		}

		// Generic Method to Check if hava a record
		public static bool haveRecord()
		{
			IWebElement firstRecord = CommonDriver.driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]"));
			if (firstRecord.Displayed)
			{
				return true;
			}
			return false;
		}

		// Generic Method to Edit Record
		public static void changeRecord(string code, string description, string price)
		{
			// Click Edit Button
			CommonDriver.driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[1]")).Click();

			// Click TypeCode Menu Item
			CommonDriver.driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]")).Click();

			// Input Code Name
			CommonDriver.driver.FindElement(By.Id("Code")).Clear();
			CommonDriver.driver.FindElement(By.Id("Code")).SendKeys(code);

			// Input Description Name
			CommonDriver.driver.FindElement(By.Id("Description")).Clear();
			CommonDriver.driver.FindElement(By.Id("Description")).SendKeys(description);

			// Input Price Number
			CommonDriver.driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]")).Clear();
			CommonDriver.driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]")).SendKeys(price);

			// Click Save Button
			CommonDriver.driver.FindElement(By.XPath("//*[@id='SaveButton']")).Click();

			// Wait 1 second 
			Wait.waituntil(CommonDriver.driver, 1, "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", "XPath");
		}
		
	}
}
