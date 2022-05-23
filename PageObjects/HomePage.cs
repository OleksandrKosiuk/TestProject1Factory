using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1Factory.PageObjects
{
    public class HomePage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//input[@id='input_search']")]
        public IWebElement searchInput;

        [FindsBy(How = How.XPath, Using = "//button[@class='button-reset search-btn']")]
        public IWebElement searchButton;

        public HomePage(WebDriver driver) : base(driver)
        {

        }
        public void SearchByKeyWord(String keyword)
        {
            searchInput.SendKeys(keyword);
            searchButton.Click();
        }
    }
}
