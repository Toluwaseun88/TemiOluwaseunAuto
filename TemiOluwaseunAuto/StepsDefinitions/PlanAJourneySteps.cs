using TemiOluwaseunAuto.BaseClass;
using TemiOluwaseunAuto.PageObject;
using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace TemiOluwaseunAuto.StepsDefinitions
{
    [Binding]
    public class PlanAJourneySteps
    {
        private BaseTest _basetest;
        PlanAJourneyPage planAJourneyPage;

        public PlanAJourneySteps(BaseTest baseTest)
        {
            _basetest = baseTest;
            planAJourneyPage = new PlanAJourneyPage(_basetest.Driver);
        }

        [Given(@"I navigate to Journey planner Page on TFL")]
        public void GivenINavigateToJourneyPlannerPageOnTFL()
        {
            planAJourneyPage.GoToPage();
        }

        [Given(@"I enter invalid location ""([^""]*)"" into From Field")]
        [Given(@"I enter valid location ""([^""]*)"" into From Field")]
        public void GivenIEnterValidLocationIntoFromField(string p0)
        {
            planAJourneyPage.FromField.SendKeys(p0);
        }

        [Given(@"I enter invalid location ""([^""]*)"" into To Field")]
        [Given(@"I enter valid location ""([^""]*)"" into To Field")]
        public void GivenIEnterValidLocationIntoToField(string p0)
        {
            planAJourneyPage.ToField.SendKeys(p0);
            planAJourneyPage.InitialToValue = p0;
        }

        [When(@"I click Update Journey Button")]
        [When(@"I click Plan a Journey Button without filling To and From Field")]
        [StepDefinition(@"I click Plan a Journey Button")]
        public void WhenIClickPlanAJourneyButton()
        {
            planAJourneyPage.PlanJourneyButton.Click();
        }

        [Then(@"Journey Results should be displayed")]
        public void ThenJourneyResultsShouldBeDisplayed()
        {
            planAJourneyPage.VerifyValidJourneyResults();
        }

        [Then(@"No Journey Results should be displayed")]
        public void ThenNoJourneyResultsShouldBeDisplayed()
        {
            planAJourneyPage.VerifyInvalidJourneyResults(); ;
        }


        [Then(@"field level validation errors should be displayed")]
        public void ThenFieldLevelValidationErrorsShouldBeDisplayed()
        {
            planAJourneyPage.VerifyFieldValidationErrorMsg();
        }

        [When(@"I click on Edit Journey Button")]
        public void WhenIClickOnEditJourneyButton()
        {
            planAJourneyPage.EditJourneyLink.Click();
        }

        [When(@"I Edit the To field to ""([^""]*)""")]
        public void WhenIEditTheToFieldTo(string p0)
        {
            planAJourneyPage.ToField.SendKeys(Keys.Control + "a");
            planAJourneyPage.ToField.SendKeys(Keys.Delete);
            planAJourneyPage.ToField.SendKeys(p0);
        }

        [Then(@"Journey Results should be updated")]
        public void ThenJourneyResultsShouldBeUpdated()
        {
            planAJourneyPage.VerifyJourneyResultsUpdated();
        }

        [Given(@"I have planned several valid Journeys")]
        public void GivenIHavePlannedSeveralValidJourneys()
        {
            throw new PendingStepException();
        }

        [When(@"I navigate to the Recent Tab")]
        public void WhenINavigateToTheRecentTab()
        {
            throw new PendingStepException();
        }

        [Then(@"I should be able to see the list of All Journeys Planned")]
        public void ThenIShouldBeAbleToSeeTheListOfAllJourneysPlanned()
        {
            throw new PendingStepException();
        }

    }
}
