using AutomationExercise.SeleniumNUnit.Constants;
using AutomationExercise.SeleniumNUnit.Utils;
using AutomationExercise.SeleniumNUnit.Models.Browsers;
using AutomationExercise.SeleniumNUnit.Pages;
using AutomationExercise.SeleniumNUnit.Models.Users;
using OpenQA.Selenium;

namespace AutomationExercise.SeleniumNUnit.Tests;

public class AuthenticationTests
{
    private IWebDriver driver;
    private ScreenshotHelper screenshotHelper;
    private HomePage homePage;
    private SignupPage signupPage;
    private AccountCreatedPage accountCreatedPage;
    private AccountDeletedPage accountDeletedPage;

    [SetUp]
    public void Setup()
    {
        driver = DriverFactory.CreateDriver(BrowserType.CHROME);
        driver.Manage().Window.Maximize();

        ReportManager.Setup();
        screenshotHelper = new ScreenshotHelper(driver);

        homePage = new HomePage(driver);
        signupPage = new SignupPage(driver);
        accountCreatedPage = new AccountCreatedPage(driver);
        accountDeletedPage = new AccountDeletedPage(driver);

        homePage.NavigateTo(Routes.home);
    }

    [TearDown]
    public void TearDown()
    {
        ReportManager.Flush();
        driver.Dispose();
    }

    [Test, Category("TC01"), Category("Smoke")]
    public void RegisterUser()
    {
        try
        {
            ReportManager.StartTest("Test Case 1: Register User Test", "Testing account creation functionality");

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
                "validseleniumuser",
                "validseleniumuser@email.com",
                true,
                "secretpassword",
                "25",
                "10",
                "1984",
                true,
                true,
                address
            );

            signupPage.SignupUserWithEmail(user.name, user.email);
            signupPage.EnterAccountInformation(user);
            ReportManager.Log("Created account successfully");

            Assert.AreEqual("ACCOUNT CREATED!", accountCreatedPage.GetAccountCreatedText());
            ReportManager.AttachScreenshot(screenshotHelper.CaptureScreenshot("account-created-successfully"));

            accountCreatedPage.Continue();
            homePage.DeleteAccount();

            Assert.AreEqual("ACCOUNT DELETED!", accountDeletedPage.GetAccountDeletedText());
            ReportManager.AttachScreenshot(screenshotHelper.CaptureScreenshot("account-deleted-successfully"));
            ReportManager.Log("Deleted account successfully");
        }
        catch (Exception e)
        {
            string errorScreenshotPath = screenshotHelper.CaptureScreenshot("TC01_Failed");
            ReportManager.AttachScreenshot(errorScreenshotPath);
            ReportManager.FailTest(e.Message);
            throw;
        }
    }
}