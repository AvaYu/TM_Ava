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
    class Program
    {
        static void Main(string[] args)
        {
            // Define driver
            CommonDriver.driver = new ChromeDriver();

            // Login object and logging in to turnup
            LoginTest loginPage = new LoginTest();
            loginPage.LoginSteps();

            // CreateRecord object 
            CreateTest createRecord = new CreateTest();
            createRecord.CreateRecord();

            // EditRecord object
            EditTest editRecord = new EditTest();
            editRecord.EditRecord();

            // DeleteRecord object
            DeleteTest deleteRecord = new DeleteTest();
            deleteRecord.DeleteRecord();











        }
    }
}
