using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestProject1Factory.PageObjects;

namespace TestProject1Factory
{
    public class BaseTest
    {
        public WebDriver driver;
        public const string AVIC_URL = "https://avic.ua/";

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(AVIC_URL);
        }
        [TearDown]
        public void CloseUp()
        {
            driver.Quit();
        }

        public WebDriver getDriver()
        { 
            return driver;
        }

        public HomePage GetHomePage()
        {
            return new HomePage(getDriver());
        }

        public SearchResultsPage GetSearchResultsPage()
        { 
            return new SearchResultsPage(getDriver());
        }
    }
    public class SearchResultsTest : BaseTest
    {
        private const string SEARCH_KEYWORD = "iPhone 13";
        private const string SEARCH_KEYWORD_2 = "google телефон";
        private const string EXPECTED_QUERY = "query=iPhone";
        private const string EXPECTED_QUERY_2 = "google";
        private const int EXPECTED_AMOUNT_OF_PRODUCTS = 12;

        [Test]
        public void CheckThatUrlContainsSearchWord()
        {
            GetHomePage().SearchByKeyWord(SEARCH_KEYWORD);
            Assert.True(getDriver().Url.Contains(EXPECTED_QUERY));
        }

        [Test]
        public void CheckElementsAmountOnSearchPage()
        {
            GetHomePage().SearchByKeyWord(SEARCH_KEYWORD);
            GetHomePage().ImplicitWait(30);
            Assert.AreEqual(EXPECTED_AMOUNT_OF_PRODUCTS, GetSearchResultsPage().GetSearchResultsCount());
        }

        [Test]
        public void CheckThatSearhResultsContainsSearchWord()
        {
            GetHomePage().SearchByKeyWord(SEARCH_KEYWORD);
            foreach (IWebElement webElement in GetSearchResultsPage().GetSearchResultsList())
            {
                Assert.True(webElement.Text.Contains(SEARCH_KEYWORD));
            }
        }

        [Test]
        public void CheckThatUrlContainsSearchWordGoogle()
        {
            GetHomePage().SearchByKeyWord(SEARCH_KEYWORD_2);
            Assert.True(getDriver().Url.Contains(EXPECTED_QUERY_2));
        }
    }
}