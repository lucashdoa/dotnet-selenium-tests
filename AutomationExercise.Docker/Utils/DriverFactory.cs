using AutomationExercise.Docker.Models.Browsers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;

namespace AutomationExercise.Docker.Utils;

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
                chromeOptions.AddArgument("--start-maximized");
                driver = new RemoteWebDriver(new Uri("http://172.18.0.2:4444/wd/hub"), chromeOptions.ToCapabilities());
                break;
        }

        return driver;
    }
}