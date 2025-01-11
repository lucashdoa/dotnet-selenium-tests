using OpenQA.Selenium;

namespace AutomationExercise.SeleniumNUnit.Pages;

public class AccountDeletedPage(IWebDriver driver) : BasePage(driver)
{
    private readonly IWebDriver driver = driver;
    private readonly By ContinueButton = By.CssSelector("[data-qa='continue-button']");
    private readonly By AccountDeletedMessage = By.CssSelector("h2[data-qa='account-deleted'] b");

    public void Continue()
    {
        driver.FindElement(ContinueButton).Click();
    }

    public string GetAccountDeletedText()
    {
        return driver.FindElement(AccountDeletedMessage).Text;
    }
}