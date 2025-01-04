using OpenQA.Selenium;

namespace AutomationExercise.SeleniumNUnit.Utils;

public class ScreenshotHelper(IWebDriver driver)
{
    private readonly IWebDriver _driver = driver;

    public string CaptureScreenshot(string screenshotName)
    {
        var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
        string filePath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Screenshots", $"{screenshotName}.png");

        Directory.CreateDirectory(Path.GetDirectoryName(filePath) ?? AppContext.BaseDirectory);
        screenshot.SaveAsFile(filePath);

        return filePath;
    }
}
