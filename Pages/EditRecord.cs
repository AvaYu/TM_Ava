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
    class EditTest
    {
		public void EditRecord()
		{
			// Wait 1 second
			Wait.waituntil(CommonDriver.driver, 1, "//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]", "XPath");

			if (TMHelpers.haveRecord() != true)
			{
				TMHelpers.addRecord("as1", "as1", "111");
			}

			TMHelpers.changeRecord("as2", "as2", "222");

			// Verify if edit the record successfully
			IWebElement actualCode = CommonDriver.driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]"));
			Assert.That(actualCode.Text, Is.EqualTo("as2"));
		}   
    }
}