using EAAutoFramework.Base;
using OpenQA.Selenium;
using EAAutoFramework.Extensions;

namespace EAEmployeeTest.Pages
{
    class LoginPage : BasePage
    {
        IWebElement txtUserName => DriverContext.Driver.FindElement(By.Id("UserName"));

        IWebElement txtSecureID => DriverContext.Driver.FindElement(By.Id("SecureIDTextBox"));

        IWebElement txtPassword => DriverContext.Driver.FindElement(By.Id("Password"));

        IWebElement btnLogin => DriverContext.Driver.FindElement(By.CssSelector("input.btn"));


        public void wmsLogin(string userName = "devbadge")
        {
            txtSecureID.SendKeys(userName);
        }

        public HomePage clickSubmit()
        {
            txtSecureID.Submit();
            return GetInstance<HomePage>();
        }


        /*public HomePage ClickLoginButton()
        {
            btnLogin.Submit();
            return GetInstance<HomePage>();
        }*/


        internal void CheckIfLoginExist()
        {
            txtSecureID.AssertElementPresent();
        }
    }
}
