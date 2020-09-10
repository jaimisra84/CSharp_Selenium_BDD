using EAAutoFramework.Base;
using EAAutoFramework.Extensions;
using OpenQA.Selenium;

namespace EAEmployeeTest.Pages
{
    internal class HomePage : BasePage
    {
        IWebElement lnkClientTab => DriverContext.Driver.FindElement(By.LinkText("Clients"));
        IWebElement lnkManageClient => DriverContext.Driver.FindElement(By.LinkText("Manage Clients"));

        public void clickClientTab()
        {
            lnkClientTab.Click();
        }
        public ManageClientPage clickManageClient()
        {
            lnkManageClient.Click();
            return GetInstance<ManageClientPage>();
        }

        internal void checkIfHomeExist()
        {
            lnkClientTab.AssertElementPresent();
        }
    }
}
