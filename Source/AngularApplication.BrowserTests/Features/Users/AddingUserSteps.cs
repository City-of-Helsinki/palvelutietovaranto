using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceRegister.AngularApplication.BrowserTests.Infrastructure;
using ServiceRegister.Tests.Infrastructure;
using TechTalk.SpecFlow;

namespace ServiceRegister.AngularApplication.BrowserTests.Features.Users
{
    [Binding]
    [Scope(Feature = "AddingUser")]
    internal sealed class AddingUserSteps
    {
        [Given(@"the user is starting to add a new user")]
        public void GivenTheUserIsStartingToAddANewUser()
        {
            TestEnvironment.Driver.NavigateTo(string.Format("{0}Organizations/{1}/NewUser", 
                TestEnvironment.ApplicationHomePage,
                CurrentScenarioContext.OrganizationId.ToString("D")));
            Thread.Sleep(5000);
        }

        [Then(@"the user cannot be saved")]
        public void ThenTheUserCannotBeSaved()
        {
            Assert.IsFalse(TestEnvironment.Driver.IsElementEnabled("saveNewUserButton"));
        }



        [Then(@"the user can be saved")]
        public void ThenTheUserCanBeSaved()
        {
            Assert.IsTrue(TestEnvironment.Driver.IsElementEnabled("saveNewUserButton"));
        }

        [When(@"focus is moved out of the email address field")]
        public void WhenFocusIsMovedOutOfTheEmailAddressField()
        {
            TestEnvironment.Driver.ClickElement("userPhoneNumberInput");
        }

        [Then(@"email address error message is displayed")]
        public void ThenEmailAddressErrorMessageIsDisplayed()
        {
            Assert.IsTrue(TestEnvironment.Driver.IsElementDisplayed("userEmailAddressErrorMessage"));
        }

        [Then(@"email address error message is not displayed")]
        public void ThenEmailAddressErrorMessageIsNotDisplayed()
        {
            Assert.IsFalse(TestEnvironment.Driver.IsElementDisplayed("userEmailAddressErrorMessage"));
        }

        [When(@"phone number '(.+)' is typed")]
        public void WhenPhoneNumberIsTyped(string phoneNumber)
        {
            TestEnvironment.Driver.TypeText("userPhoneNumberInput", phoneNumber);

        }

        [When(@"focus is moved out of the phone number field")]
        public void WhenFocusIsMovedOutOfThePhoneNumberField()
        {
            TestEnvironment.Driver.ClickElement("userEmailAddressInput");
        }

        [Then(@"phone number error message is displayed")]
        public void ThenPhoneNumberErrorMessageIsDisplayed()
        {
            Assert.IsTrue(TestEnvironment.Driver.IsElementDisplayed("userPhoneNumberErrorMessage"));
        }

        [Then(@"phone number error message is not displayed")]
        public void ThenPhoneNumberErrorMessageIsNotDisplayed()
        {
            Assert.IsFalse(TestEnvironment.Driver.IsElementDisplayed("userPhoneNumberErrorMessage"));
        }

        [Then(@"password error message is displayed")]
        public void ThenPasswordErrorMessageIsDisplayed()
        {
            Assert.IsTrue(TestEnvironment.Driver.IsElementDisplayed("userConfirmedPasswordErrorMessage"));
        }

        [Then(@"password error message is not displayed")]
        public void ThenPasswordErrorMessageIsNotDisplayed()
        {
            Assert.IsFalse(TestEnvironment.Driver.IsElementDisplayed("userConfirmedPasswordErrorMessage"));
        }

        [Then(@"insufficient permissions error is displayed")]
        public void InsufficientPermissionsErrorIsDisplayed()
        {
            Assert.IsTrue(TestEnvironment.Driver.Value.Url.Contains("INSUFFICIENT_PERMISSIONS"));
        }

       
    }
}