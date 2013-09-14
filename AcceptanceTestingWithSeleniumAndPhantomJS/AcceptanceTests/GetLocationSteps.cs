using System;
using TechTalk.SpecFlow;

namespace AcceptanceTests
{
    [Binding]
    public class GetLocationSteps
    {
        [Given(@"I have opened the webpage")]
        public void GivenIHaveOpenedTheWebpage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I press submit button")]
        public void WhenIPressSubmitButton()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"my location should be visible on the screen")]
        public void ThenMyLocationShouldBeVisibleOnTheScreen()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
