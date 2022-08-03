using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace Core
{
    public abstract class BaseTest
    {
        public IWebDriver driver;
        
        [SetUp]
        public void CreateDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://translate.google.com/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }

        [TearDown]
        public void QuitDriver()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                var screenShot = ((ITakesScreenshot)driver).GetScreenshot();
                string screenshotFile = Path.Combine(Directory.GetCurrentDirectory(), $"{TestContext.CurrentContext.Test.Name}{DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss")}.jpeg");
                screenShot.SaveAsFile(screenshotFile, ScreenshotImageFormat.Jpeg);

                // Add that file to NUnit results
                TestContext.AddTestAttachment(screenshotFile, "My Screenshot");
            }
            driver.Quit();
        }

    }
}
