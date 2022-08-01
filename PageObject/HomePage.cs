using Core.Utilities;
using OpenQA.Selenium;
using PageObjects.Components;

namespace TranslateGoogleCom.PageObjects
{
    public class HomePage : BasePage
    { 
        private static readonly By RootSourceMenuLocator = By.XPath("//c-wiz[@data-node-index='3;0']//c-wiz[@data-node-index='1;0']/div[./button][1]");
        private static readonly By RootTargetMenuLocator = By.XPath("//c-wiz[@data-node-index='3;0']//c-wiz[@data-node-index='1;0']/div[./button][2]");
        private static readonly By TargetTextElementLocator = By.XPath("//div[@data-result-index]//span[@data-phrase-index='0']/span");//кошка
        private static readonly By SourceTextAreaLocator = By.XPath("//textarea[@aria-label='Source text']");

        private IWebDriver driver;

        //ctor
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //properties for driver and rootelement
        public Menu SourceMenu
        {
            get
            {
                return new Menu(driver, RootSourceMenuLocator);
            }
        }

        public Menu TargetMenu
        {
            get
            {
                return new Menu(driver, RootTargetMenuLocator);
            }
        }

        public string GetTargetText()
        {
            Wait.For(() => driver.FindElement(TargetTextElementLocator).Displayed);
            var targetTextElement = this.driver.FindElement(TargetTextElementLocator);
            return targetTextElement.Text;
        }

        public void FillInSource(string text)
        {
            Wait.For(() => driver.FindElement(SourceTextAreaLocator).Displayed);
            var sourceTextArea = this.driver.FindElement(SourceTextAreaLocator);
            sourceTextArea.SendKeys(text);
            sourceTextArea.SendKeys(Keys.Enter);
        }
    }
}
