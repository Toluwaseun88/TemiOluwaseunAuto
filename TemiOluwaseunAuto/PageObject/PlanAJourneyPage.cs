using NUnit.Framework;
using OpenQA.Selenium;

namespace TemiOluwaseunAuto.PageObject
{
    public class PlanAJourneyPage
    {
        private string test_url = "https://tfl.gov.uk/plan-a-journey/";
        private IWebDriver driver;
        public string ApplyURL { get; set; }
        public string FindOutMoreURL { get; set; }
        public string InitialToValue { get; set; }

        public PlanAJourneyPage(IWebDriver _driver)
        {
            driver = _driver;
        }


        public IWebElement FromField => driver.FindElement(By.Id("InputFrom"));
        public IWebElement ToField => driver.FindElement(By.Id("InputTo"));
        public IWebElement PlanJourneyButton => driver.FindElement(By.Id("plan-journey-button"));
        IWebElement AcceptCookiesButton => driver.FindElement(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll"));
        IWebElement JourneyResultsPage => driver.FindElement(By.XPath("//*[contains(@class,'jp-results-headline')]"));
        IWebElement ToFieldValue => driver.FindElement(By.XPath("//*[@id=\"plan-a-journey\"]/div[1]/div[1]/div[2]/span[2]/strong"));
        IWebElement EarlierJourneysLink => driver.FindElement(By.LinkText("Earlier journeys"));
        IWebElement LaterJourneysLink => driver.FindElement(By.LinkText("Later journeys"));
        IWebElement NoJourneyResultsMsg => driver.FindElement(By.XPath("\r\n//*[@id=\"full-width-content\"]/div/div[8]/div/div/ul/li"));
        IWebElement FromFieldErrorMsg => driver.FindElement(By.XPath("//*[@id=\"search-filter-form-0\"]/div/span"));
        IWebElement ToFieldErrorMsg => driver.FindElement(By.XPath("//*[@id=\"search-filter-form-1\"]/span[1]"));
        public IWebElement EditJourneyLink => driver.FindElement(By.LinkText("Edit journey"));
        //IWebElement UpdateJourneyButton => driver.FindElement(By.LinkText("plan-journey-button"));

        public void GoToPage()
        {
            driver.Navigate().GoToUrl(test_url);
            AcceptCookiesButton.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        public void VerifyValidJourneyResults()
        {
            _ = driver.PageSource;
            string ExpectedPageHeader = "Journey results";
            string ActualPageHeader = JourneyResultsPage.Text;

            Assert.Multiple(() =>
                {
                    Assert.That(ActualPageHeader, Is.EqualTo(ExpectedPageHeader));
                    Assert.That(EarlierJourneysLink.Displayed);
                    Assert.That(LaterJourneysLink.Displayed);
                });
                Console.WriteLine("Journey Results Successfully displayed for valid Journeys");

        }
        public void VerifyInvalidJourneyResults()
        {

            Assert.That(NoJourneyResultsMsg.Text, Is.EqualTo("Sorry, we can't find a journey matching your criteria"));
             
            Console.WriteLine("Journey Results not displayed for invalid Journeys");
        }

        public void VerifyFieldValidationErrorMsg()
        {
            Assert.Multiple(() =>
            {
                Assert.That(FromFieldErrorMsg.Text, Is.EqualTo("The From field is required."));
                Assert.That(ToFieldErrorMsg.Text, Is.EqualTo("The To field is required."));
            });
        }

        public void VerifyJourneyResultsUpdated()
        {
            string UpdatedValue = ToFieldValue.Text;
            string InitialValue = InitialToValue;
            Console.WriteLine(InitialValue);
            Console.WriteLine(UpdatedValue);
            Assert.Multiple(() =>
            {
                Assert.That(UpdatedValue,Is.Not.EqualTo(InitialValue));
                Assert.That(EarlierJourneysLink.Displayed);
                Assert.That(LaterJourneysLink.Displayed);
            });

        }

    }
}

