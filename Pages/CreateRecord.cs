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
            // Click Administration Menu Item
            IWebElement administrationMenu = CommonDriver.driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            administrationMenu.Click();

            // Click Time & Materials Menu Link
            IWebElement timeMaterialLink = CommonDriver.driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            timeMaterialLink.Click();

            // Click Create New Button
            IWebElement createButton = CommonDriver.driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            createButton.Click();

            // Click TypeCode Menu Item
            IWebElement typeCodeMenu = CommonDriver.driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]"));
            typeCodeMenu.Click();

            // Change TypeCode from Material to Time
            IWebElement timeLink = CommonDriver.driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[2]"));
            timeLink.Click();

            // Input Code Name
            IWebElement code = CommonDriver.driver.FindElement(By.Id("Code"));
            code.SendKeys("as1");

            // Input Description Name
            IWebElement description = CommonDriver.driver.FindElement(By.Id("Description"));
            description.SendKeys("as1");

            // Input Price Number
            IWebElement price = CommonDriver.driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            price.SendKeys("1");

            // Click Save Button
            IWebElement saveButton = CommonDriver.driver.FindElement(By.XPath("//*[@id='SaveButton']"));
            saveButton.Click();

            // Wait 1 second 
            Thread.Sleep(1000);

            // Verify if save the record successfully
			// Go to the last page
            IWebElement lastPageButton = CommonDriver.driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            lastPageButton.Click();

            // Wait 1 second 
            Thread.Sleep(1000);

            IWebElement actualCode = CommonDriver.driver.FindElement(By.CssSelector("#tmsGrid > div.k-grid-content > table > tbody > tr:last-child > td:nth-child(1)"));
			
			if (actualCode.Text == "as1")
            {
                Console.WriteLine("as1 displayed, Test CreateRecord Passed");
            }
			else
			{
				Console.WriteLine("Text didn't match, Test CreateRecord Failed");
			}
        }
    }
}
