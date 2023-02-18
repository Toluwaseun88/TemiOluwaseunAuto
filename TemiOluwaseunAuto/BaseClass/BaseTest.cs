using AventStack.ExtentReports;
using OpenQA.Selenium;

namespace TemiOluwaseunAuto.BaseClass
{
    public class BaseTest
    {
        public IWebDriver Driver { get; set; }

        public MediaEntityModelProvider CaptureScreenshotAndReturnModel(string Name)
        {
            var screenshot = ((ITakesScreenshot)Driver).GetScreenshot().AsBase64EncodedString;

            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, Name).Build();
        }
        
    }
}