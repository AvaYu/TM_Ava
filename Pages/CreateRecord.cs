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
    class CreateTest
    {
        public void CreateRecord()
        {
			TMHelpers.addRecord("as1", "as1", "111");

			// Wait 1 second
			Wait.waituntil(CommonDriver.driver, 1, "//*[@id='tmsGrid']/div[4]/a[4]/span", "XPath");
						
            // Go to the last page
            CommonDriver.driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span")).Click();

			// Wait 1 second 
			Wait.waituntil(CommonDriver.driver, 1, "#tmsGrid > div.k-grid-content > table > tbody > tr:last-child > td:nth-child(1)", "CssSelector");

			// Verify if save the record successfully
			IWebElement actualCode = CommonDriver.driver.FindElement(By.CssSelector("#tmsGrid > div.k-grid-content > table > tbody > tr:last-child > td:nth-child(1)"));
			Assert.That(actualCode.Text, Is.EqualTo("as1"));  
        }
    }
}
