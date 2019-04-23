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
    class DeleteTest
    {
        public void DeleteRecord()
        {
			// Wait 1 second
			Wait.waituntil(CommonDriver.driver, 1, "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", "XPath");

			if (TMHelpers.haveRecord() != true)
			{
				TMHelpers.addRecord("as2", "as2", "222");
			}

			IWebElement recordCode = CommonDriver.driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]"));
			if (recordCode.Text != "as2")
			{
				TMHelpers.changeRecord("as2", "as2", "222");
			}

			// Click Delete Button
			CommonDriver.driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[2]")).Click();

			// Click OK Button on the popup dialog
			IAlert alert = CommonDriver.driver.SwitchTo().Alert();
			alert.Accept();

			// Wait 1 second
			Thread.Sleep(1000);

			// Verify if delete the record successfully
			IWebElement actualCode = CommonDriver.driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]"));
			Assert.That(actualCode.Text, Is.Not.EqualTo("as2"));
		}
    }
}