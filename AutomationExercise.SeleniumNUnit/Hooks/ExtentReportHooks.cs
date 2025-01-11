using AutomationExercise.SeleniumNUnit.Utils;

namespace AutomationExercise.SeleniumNUnit;

[SetUpFixture]
public class ExtentReportHooks
{
    [OneTimeSetUp]
    public void SetUp()
    {
        ReportManager.Setup();
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        ReportManager.Flush();
    }
}
