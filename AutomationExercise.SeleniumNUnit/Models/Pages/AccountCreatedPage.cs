using OpenQA.Selenium;

namespace AutomationExercise.SeleniumNUnit.Pages;

public class AccountCreatedPage(IWebDriver driver) : BasePage(driver)
{
    private readonly IWebDriver driver = driver;
    private readonly By ContinueButton = By.CssSelector("[data-qa='continue-button']");
    private readonly By AccountCreatedMessage = By.CssSelector("h2[data-qa='account-created'] b");

    public void Continue()
    {
        driver.FindElement(ContinueButton).Click();
    }

    public string GetAccountCreatedText()
    {
        return driver.FindElement(AccountCreatedMessage).Text;
    }
}