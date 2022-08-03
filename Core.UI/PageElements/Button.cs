using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Core.UI.PageElements
{
    public class Button
    {
        private IWebDriver driver;
        private By locator;
        //private static readonly By ReverseButtonLocator = By.XPath("//*[@id='ow25']//button");     //"//*[@id='ow25']/div/span/button/div[3]") it works too

        //ctor
        public Button(IWebDriver driver, By locator)
        {
            this.driver = driver;
            this.locator = locator;
        }

        //Methos for any button
        public void ClickButton()
        {
            //var action = new Actions(driver);
            //action.MoveToElement(driver.FindElement(locator)).Click().Build().Perform();

            driver.FindElement(locator).Click();
        }
    }
}
