using AutomationExercise.SeleniumNUnit.Models.Browsers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;

namespace AutomationExercise.SeleniumNUnit.Utils;

public class DriverFactory
{
    public static IWebDriver CreateDriver(BrowserType browser)
    {
        IWebDriver driver;

        switch(browser)
        {
            case BrowserType.FIREFOX:
                driver = new FirefoxDriver();
                break;
            case BrowserType.IE:
                driver = new InternetExplorerDriver();
                break;
            case BrowserType.SAFARI:
                driver = new SafariDriver();
                break;
            default:
            case BrowserType.CHROME:
                ChromeOptions chromeOptions = new ChromeOptions();
                chromeOptions.AddArguments("--disable-headless-mode", "--no-sandbox");
                driver = new ChromeDriver(chromeOptions);
                 // Set implicit wait time to 10 seconds
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
                break;
        }

        return driver;
    }
}