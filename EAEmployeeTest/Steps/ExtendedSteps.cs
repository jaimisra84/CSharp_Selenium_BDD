﻿using EAAutoFramework.Base;
using EAAutoFramework.Config;
using EAAutoFramework.Helpers;
using EAEmployeeTest.Pages;
using TechTalk.SpecFlow;

namespace EAEmployeeTest.Steps
{
    [Binding]
    internal class ExtendedSteps : BaseStep
    {
        /*[Given(@"I have navigated to the application")]
        public void GivenIHaveNavigatedToTheApplication()
        {
            NavigateSite();
        }*/


        [Given(@"I Delete employee '(.*)' before I start running test")]
        public void GivenIDeleteEmployeeBeforeIStartRunningTest(string employeeName)
        {
            string query = "delete from Employees where Name = '" + employeeName + "'";
            Settings.ApplicationCon.ExecuteQuery(query);
        }

        [Given(@"I see application opened")]
        public void GivenISeeApplicationOpened()
        {
            CurrentPage.As<LoginPage>().CheckIfLoginExist();//WMS Code
            //CurrentPage.As<HomePage>().CheckIfLoginExist();EA Code
        }

        /*[Then(@"I click (.*) link")]
        public void ThenIClickLink(string linkName)
        {
            if (linkName == "login")
                CurrentPage = CurrentPage.As<HomePage>().ClickLogin();
            else if (linkName == "employeeList")
                CurrentPage = CurrentPage.As<HomePage>().ClickEmployeeList();
        }

        [Then(@"I click (.*) button")]
        public void ThenIClickButton(string buttonName)
        {
            if (buttonName == "login")
                CurrentPage = CurrentPage.As<LoginPage>().ClickLoginButton();
            else if (buttonName == "createnew")
                CurrentPage = CurrentPage.As<EmployeeListPage>().ClickCreateNew();
            else if (buttonName == "create")
                CurrentPage = CurrentPage.As<CreateEmployeePage>().ClickCreateButton();
        }*/

        [Then(@"I click log off")]
        public void ThenIClickLogOff()
        {
            CurrentPage.As<EmployeeListPage>().ClickLogoff();
        }

        //WMS Code
        [Given(@"User navigates to the application")]
        public void GivenUserNavigatesToTheApplication()
        {
            NavigateSite();
            CurrentPage = GetInstance<LoginPage>();
            //NavigateSite();
            //CurrentPage = GetInstance<HomePage>();
        }

        [Given(@"User validates the application is opened")]
        public void GivenUserValidatesTheApplicationIsOpened()
        {
            CurrentPage.As<LoginPage>().CheckIfLoginExist();
        }

    }
}
