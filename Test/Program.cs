using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM_Ava.Helpers;
using TM_Ava.Pages;

namespace TM_Ava
{
	[TestFixture]
	class Program
    {
        static void Main(string[] args)
		{
		}

		[SetUp]
		public void setup()
		{
			// Define driver
			CommonDriver.driver = new ChromeDriver();

			// Login object and logging in to turnup
			LoginTest loginPage = new LoginTest();
			loginPage.LoginSteps();

			//homePage object and navigating to TM page
			HomePage homePage = new HomePage();
			homePage.navigateTM();

		}
		
		[Test]
		public void testCreateTM()
		{
			// CreateRecord object 
			CreateTest createRecord = new CreateTest();
			createRecord.CreateRecord();
		}

		[Test]
		public void testEditTM()
		{
			// EditRecord object
			EditTest editRecord = new EditTest();
			editRecord.EditRecord();
		}

		[Test]
		public void testDeleteTM()
		{
			// DeleteRecord object
			DeleteTest deleteRecord = new DeleteTest();
			deleteRecord.DeleteRecord();
		}

		[TearDown]
		public void tearDown()
		{
			CommonDriver.driver.Close();
		}
	}
}
