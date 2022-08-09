using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using Serilog;

namespace Core
{
    public abstract class BaseTest
    {
        public IWebDriver driver;
        
        [OneTimeSetUp]
        public void CreateLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File($"log-{DateTime.Now.ToString("dd-MM-yy hh-mm-ss")}.txt")
                .CreateLogger();
        }

        [SetUp]
        public void CreateDriver()
        {
            Log.Logger.Information("Create Chrome Driver");
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://translate.google.com/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }

        [TearDown]
        public void QuitDriver()
        {
            try
            {
                if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
                {
                    var screenShot = ((ITakesScreenshot)driver).GetScreenshot();
                    string screenshotFile = Path.Combine(Directory.GetCurrentDirectory(), $"{TestContext.CurrentContext.Test.Name}{DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss")}.jpeg");
                    screenShot.SaveAsFile(screenshotFile, ScreenshotImageFormat.Jpeg);

                    // Add that file to NUnit results
                    TestContext.AddTestAttachment(screenshotFile, "My Screenshot");
                }
            }
            catch
            { 
                //Ignore any exception
            }
            //
            Log.Logger.Information("Close Chrome Driver");
            driver.Quit();
        }

    }
}
