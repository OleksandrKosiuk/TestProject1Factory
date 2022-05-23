using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1Factory.PageObjects
{
    public class SearchResultsPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//div[@class='prod-cart__descr']")]
        public IList<IWebElement> searchResultsProductList;
        public SearchResultsPage(WebDriver driver) : base(driver)
        {

        }

        public IList<IWebElement> GetSearchResultsList()
        {
            return searchResultsProductList;
        }

        public int GetSearchResultsCount()
        { 
             return GetSearchResultsList().Count;
        }
    }
}
