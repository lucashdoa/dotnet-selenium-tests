using OpenQA.Selenium;

namespace AutomationExercise.SeleniumNUnit.Pages;

public class BasePage(IWebDriver driver)
{
    protected IWebDriver _driver = driver;
    public readonly By HomeNavigationButton = By.CssSelector("");
    public readonly By ProductsNavigationButton = By.CssSelector("a[href='/products']");
    public readonly By CartNavigationButton = By.CssSelector("a[href='/view_cart']");
    public readonly By SignupLoginNavigationButton = By.CssSelector("a[href='/login']");
    public readonly By TestCasesNavigationButton = By.CssSelector("a[href='/test_cases']");
    public readonly By APITestingNavigationButton = By.CssSelector("a[href='/api_list']");
    public readonly By VideoTutorialsNavigationButton = By.CssSelector("a[href*='youtube']");
    public readonly By ContactUsNavigationButton = By.CssSelector("a[href='/contact_us']");

    public void NavigateTo(string route)
    {
        _driver.Navigate().GoToUrl($"https://automationexercise.com{route}");
    }
}