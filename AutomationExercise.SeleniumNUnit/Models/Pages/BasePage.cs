using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutomationExercise.SeleniumNUnit.Pages;

public class BasePage(IWebDriver driver)
{
    private IWebDriver driver = driver;
    public readonly By HomeNavigationButton = By.CssSelector("");
    public readonly By ProductsNavigationButton = By.CssSelector("a[href='/products']");
    public readonly By CartNavigationButton = By.CssSelector("a[href='/view_cart']");
    public readonly By SignupLoginNavigationButton = By.CssSelector("a[href='/login']");
    public readonly By TestCasesNavigationButton = By.CssSelector("a[href='/test_cases']");
    public readonly By APITestingNavigationButton = By.CssSelector("a[href='/api_list']");
    public readonly By VideoTutorialsNavigationButton = By.CssSelector("a[href*='youtube']");
    public readonly By ContactUsNavigationButton = By.CssSelector("a[href='/contact_us']");
    private readonly By CloseAdButton = By.CssSelector("div[aria-label='Close ad']");

    protected IWebDriver Driver { get => driver; set => driver = value; }

    public void NavigateTo(string route)
    {
        driver.Navigate().GoToUrl($"https://automationexercise.com{route}");
    }

    public void HoverElement(IWebElement element)
    {
        Actions actions = new(driver);
        actions.MoveToElement(element).Perform();
    }

    public void ScrollElementIntoView(IWebElement element)
    {
        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        js.ExecuteScript("arguments[0].scrollIntoView({behavior: 'instant', block: 'center', inline: 'nearest'});", element);
    }

    public bool WaitForElementToBeVisible(By locator, int timeout)
    {
        try
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
            return true;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    public void WaitForElementToBeClickable(By locator, int timeout)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
        wait.Until(ExpectedConditions.ElementToBeClickable(locator));
    }
}