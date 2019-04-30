using NUnit.Framework;
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
	class TMPage
	{
		private IWebDriver driver;

		public TMPage(IWebDriver driver)
		{
			this.driver = driver;
		}

		public void CreateTM()
		{
			TMHelpers.AddTM(driver, "as1", "as1", "111");


			//// Wait 1 second 
			//Wait.waituntil(driver, 1, "#tmsGrid > div.k-grid-content > table > tbody > tr:last-child > td:nth-child(1)", "CssSelector");

			//// Verify if save the record successfully
			//IWebElement actualCode = driver.FindElement(By.CssSelector("#tmsGrid > div.k-grid-content > table > tbody > tr:last-child > td:nth-child(1)"));
			//Assert.That(actualCode.Text, Is.EqualTo("as1"));
		}

		internal void ValidateTM()
		{
			Thread.Sleep(2000);
			// Wait at most 2 seconds for a record to be visible
			//Wait.waituntil(driver, 2, "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]", "XPath");

			// Go to the last page
			driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span")).Click();

			// Click previous page button
			driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[2]")).Click();

			while (true)
			{
				for (int i = 1; i <= 10; i++)
				{
					var elementText = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[" + i + "]/td[1]")).Text;
					if (elementText == "as1")
					{
						// Verify if find the record successfully
						Assert.That(true);
						return;
					}
				}

				// Click next page button
				driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[3]")).Click();
			}
		}

		public void EditTM()
		{
			// Wait 1 second
			Wait.waituntil(driver, 1, "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", "XPath");

			if (TMHelpers.HaveRecordTM(driver) != true)
			{
				TMHelpers.AddTM(driver, "as1", "as1", "111");
			}

			TMHelpers.ChangeRecordTM(driver, "as2", "as2", "222");

			// Verify if edit the record successfully
			IWebElement actualCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]"));
			Assert.That(actualCode.Text, Is.EqualTo("as2"));
		}


		public void DeleteTM()
		{
			// Wait 1 second
			Wait.waituntil(driver, 1, "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", "XPath");

			if (TMHelpers.HaveRecordTM(driver) != true)
			{
				TMHelpers.AddTM(driver, "as2", "as2", "222");
			}

			IWebElement recordCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]"));
			if (recordCode.Text != "as2")
			{
				TMHelpers.ChangeRecordTM(driver, "as2", "as2", "222");
			}

			// Click Delete Button
			driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[2]")).Click();

			// Click OK Button on the popup dialog
			IAlert alert = driver.SwitchTo().Alert();
			alert.Accept();

			// Wait 1 second
			Thread.Sleep(1000);

			// Verify if delete the record successfully
			IWebElement actualCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]"));
			Assert.That(actualCode.Text, Is.Not.EqualTo("as2"));
		}
	}
}