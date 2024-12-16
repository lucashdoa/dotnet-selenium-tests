using OpenQA.Selenium;

namespace AutomationExercise.SeleniumNUnit.Pages;

public class HomePage(IWebDriver driver)
{
    private readonly By DeleteAccountButton = By.CssSelector("[href*='delete_account']");

    public void GoTo()
    {
        driver.Navigate().GoToUrl("https://automationexercise.com/");
    }

    public void DeleteAccount()
    {
        driver.FindElement(DeleteAccountButton).Click();
    }
}