using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace AutomationExercise.SeleniumNUnit.Utils;

public class ReportManager
{
    private static ExtentReports? _extent;
    private static ExtentTest? _test;
    private static ExtentSparkReporter? _htmlReporter;

    public static void Setup()
    {
        string reportPath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Reports", "ExtentReport.html");
        _htmlReporter = new ExtentSparkReporter(reportPath);
        _extent = new ExtentReports();
        _extent.AttachReporter(_htmlReporter);
    }

    public static void StartTest(string testName, string testDescription)
    {
        _test = _extent!.CreateTest(testName, testDescription);
    }

    public static void FailTest(string errorMessage)
    {
        _test!.Fail(errorMessage);
    }

    public static void AttachScreenshot(string screenshotPath)
    {
        _test!.AddScreenCaptureFromPath(screenshotPath);
    }

    public static void Log(string message)
    {
        _test!.Log(Status.Info, message);
    }

    public static void Flush()
    {
        _extent!.Flush();
    }
}
