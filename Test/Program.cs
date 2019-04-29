using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
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
	[Parallelizable(ParallelScope.All)]
	public class Program
	{

		static void Main(string[] args)
		{

		}
		private IWebDriver driver;

		[SetUp]
		public void Setup()
		{
			//defining driver
			driver = new ChromeDriver();

			ExcelHelpers.PopulateInCollection(@"C:\Users\A&S\source\repos\AvaYu\TM_Ava\Data\TestData.xlsx", "Data");

			//login object and logging in to TurnUp
			LoginPage loginPage = new LoginPage(driver);
			loginPage.LoginSteps();

			//homePage object and navigating to TM page
			HomePage homePage = new HomePage(driver);
			homePage.navigateTM();
		}

		[Test]
		public void CreateTM()
		{
			var tmPage = new TMPage(driver);
			tmPage.CreateTM();
			tmPage.ValidateTM();
		}

		[Test]
		public void EditTM()
		{
			//TMpage object and editing an existing record
			TMPage tmPage = new TMPage(driver);
			tmPage.EditTM();
		}

		[Test]
		public void DeleteTM()
		{
			var tmPage = new TMPage(driver);
			tmPage.DeleteTM();
		}

		[TearDown]
		public void TearDown()
		{
			driver.Close();
		}

	}
}