using MapsNavigationTestSuite.Main.Drivers;
using MapsNavigationTestSuite.Main.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace MapsNavigationTestSuite.Tests.Steps
{
    [Binding]
    public class MapsNavigationWebSteps
    {
        private readonly SeleniumDriverSetup _driverSetup = new();
        private MapsPage _mapsPage;

        [BeforeScenario]
        public void Setup()
        {
            var driver = _driverSetup.InitializeDriver();
            _mapsPage = new MapsPage(driver);
        }

        [AfterScenario]
        public void Teardown()
        {
            _driverSetup.QuitDriver();
        }

        [Given(@"I have opened Google Maps in a browser")]
        public void GivenIHaveOpenedGoogleMaps()
        {
            _mapsPage.NavigateToGoogleMaps();
            Assert.That(_mapsPage.SearchBox.Displayed, Is.True, "Google Maps failed to load.");
        }

        [When(@"I enter ""(.*)"" as the web starting point")]
        public void WhenIEnterWebStartingPoint(string startingPoint)
        {
            _mapsPage.EnterStartingPoint(startingPoint);
        }

        [When(@"I enter ""(.*)"" as the web destination")]
        public void WhenIEnterWebDestination(string destination)
        {
            _mapsPage.EnterDestination(destination);
        }

        [Then(@"I should see web directions to the Solirius Office")]
        public void ThenIShouldSeeWebDirections()
        {
            Assert.That(_mapsPage.AreDirectionsDisplayed(), Is.True, "Directions not displayed.");
        }
    }
}