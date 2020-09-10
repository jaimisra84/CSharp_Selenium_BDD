using AventStack.ExtentReports;
using EAAutoFramework.Base;
using EAEmployeeTest.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace EAEmployeeTest.Steps
{
    [Binding]
    public class LoginSteps : BaseStep
    {
        [When(@"User enters SecureID")]
        public void ThenUserEntersSecureIDAndClicksSubmit()
        {
            CurrentPage.As<LoginPage>().wmsLogin("devbadge");
        }

        [Then(@"User clicks on Submit")]
        public void ThenUserClicksSubmit()
        {
            CurrentPage = CurrentPage.As<LoginPage>().clickSubmit();
        }

        [Then(@"User validates the login was successful")]
        public void ThenUserValidatesLoginWasSuccessful()
        {
            try
            {
                CurrentPage.As<HomePage>().checkIfHomeExist();
            }
            catch (Exception e)
            {
                //Assert.Fail();
                //ExtentTest.Fail(e.ToString());
                Assert.IsTrue(false);
                Console.WriteLine(e.ToString());
            }
        }
    }
}
