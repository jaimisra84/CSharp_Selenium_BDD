using EAAutoFramework.Base;
using EAAutoFramework.Extensions;
using OpenQA.Selenium;
using System;

namespace EAEmployeeTest.Pages
{
    internal class ManageClientPage : BasePage
    {
        IWebElement lnkCreateNewClient => DriverContext.Driver.FindElement(By.LinkText("Create New Client"));

        internal void CheckIfManageClientExist()
        {
            lnkCreateNewClient.AssertElementPresent();
        }
    }
}
