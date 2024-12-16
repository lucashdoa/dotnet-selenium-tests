using AutomationExercise.SeleniumNUnit.Drivers;
using AutomationExercise.SeleniumNUnit.Models.Browsers;
using AutomationExercise.SeleniumNUnit.Pages;
using AutomationExericse.SeleniumNUnit.Models.Users;
using OpenQA.Selenium;

namespace AutomationExercise.SeleniumNUnit.Tests;

public class AuthenticationTests
{
    private IWebDriver driver;
    private HomePage? homePage;
    private SignupPage? signupPage;
    private AccountCreatedPage? accountCreatedPage;

    [SetUp]
    public void Setup()
    {
        driver = DriverFactory.CreateDriver(BrowserType.CHROME);
        driver.Manage().Window.Maximize();
        homePage = new HomePage(driver);
        signupPage = new SignupPage(driver);
        accountCreatedPage = new AccountCreatedPage(driver);

        homePage.GoTo();
    }

    [TearDown]
    public void TearDown()
    {
        driver.Dispose();
    }

    [Test]
    public void RegisterUser()
    {
        UserAddress address = new(
            "John",
            "Doe",
            "Test Street, Number 7 Apartment 101",
            "United States",
            "Las Vegas",
            "Nevada",
            "123456789",
            "98765432"
        );

        User user = new(
            "validuser",
            "validuser12@email.com",
            true,
            "secretpassword",
            "25",
            "10",
            "1984",
            true,
            true,
            address
        );

        signupPage.SignupUserWithEmail("testemail", "testemail@mail.com");
        signupPage.EnterAccountInformation(user);

        accountCreatedPage.Continue();
        homePage.DeleteAccount();
    }
}