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
            // Click Delete Button
            IWebElement deleteButton = CommonDriver.driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[2]"));
            deleteButton.Click();

            // Click OK Button on the popup dialog
            IAlert alert = CommonDriver.driver.SwitchTo().Alert();
            alert.Accept();

            // Wait 1 second
            Thread.Sleep(1000);

			// Verify if delete the record successfully
			IWebElement actualCode = CommonDriver.driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]"));
			if (actualCode.Text != "as2")
			{
				Console.WriteLine("as2 didn't displayed, Test DeleteRecord Passed");
			}
			else
			{
				Console.WriteLine("as2 displayed, Test DeleteRecord Failed");
			}
		}
    }
}
