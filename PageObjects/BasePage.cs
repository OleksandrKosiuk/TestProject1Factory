using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1Factory.PageObjects
{
    public class BasePage
    {
        public WebDriver driver;
        public BasePage(WebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void ImplicitWait(double timeToWait)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeToWait);
        }
    }
}
