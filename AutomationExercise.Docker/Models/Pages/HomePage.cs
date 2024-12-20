using OpenQA.Selenium;

namespace AutomationExercise.Docker.Pages;

public class HomePage(IWebDriver driver) : BasePage(driver)
{
    private readonly By DeleteAccountButton = By.CssSelector("[href*='delete_account']");

    public void DeleteAccount()
    {
        _driver.FindElement(DeleteAccountButton).Click();
    }
}