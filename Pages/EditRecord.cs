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
			// Go to the first page
			CommonDriver.driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[1]/span")).Click();

			// Click Edit Button
			CommonDriver.driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[1]")).Click();

            // Click TypeCode Menu Item
            CommonDriver.driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]")).Click();

            // Input Code Name
            CommonDriver.driver.FindElement(By.Id("Code")).Clear();
            CommonDriver.driver.FindElement(By.Id("Code")).SendKeys("as2");

            // Input Description Name
            CommonDriver.driver.FindElement(By.Id("Description")).Clear();
            CommonDriver.driver.FindElement(By.Id("Description")).SendKeys("as2");

            // Input Price Number
            CommonDriver.driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]")).Clear();
            CommonDriver.driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]")).SendKeys("2");

            // Click Save Button
            CommonDriver.driver.FindElement(By.XPath("//*[@id='SaveButton']")).Click();

            // Wait 1 second 
            Thread.Sleep(1000);

            // Verify if edit the record successfully
            IWebElement actualCode = CommonDriver.driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]"));

            if (actualCode.Text == "as2")
            {
                Console.WriteLine("as2 displayed, Test EditRecord Passed");
            }
			else
			{
				Console.WriteLine("Text didn't match, Test EditRecord Failed");
			}
		}
    }
}
