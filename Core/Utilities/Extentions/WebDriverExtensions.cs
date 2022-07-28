using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Extentions
{
    public static class WebDriverExtensions
    {
        public static void Hover(this IWebDriver driver, IWebElement element)
        {
            var action = new Actions(driver);
            action.MoveToElement(element).Perform();
        }

        public static void Hover(this IWebDriver driver, By locator)
        {
            var action = new Actions(driver);
            action.MoveToElement(driver.FindElement(locator)).Perform();
        }

        public static void HoverAndClick(this IWebDriver driver, IWebElement element)
        {
            var action = new Actions(driver);
            action.MoveToElement(element).Perform();
            element.Click();
        }

        public static void HoverAndClick(this IWebDriver driver, By locator)
        {
            var element = driver.FindElement(locator);
            //HoverAndClick(driver, element);
            driver.HoverAndClick(element);
        }

        //SELECT FROM DROP DOWN MENU

        private static void SelectFromDropDownMenu(this IWebDriver driver, By locator)
        { 
            var action = new Actions(driver);
            action.MoveToElement(driver.FindElement(locator)).Click().Perform();
        }

        public static void SelectSourceFromDropDownMenu(this IWebDriver driver, By locator)
        {
            var action = new Actions(driver);
            var element = driver.FindElement(locator);
            driver.SelectFromDropDownMenu((By)element);
        }

    }
}
