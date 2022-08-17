using Core.UI.PageElements;
using Core.Utilities;
using OpenQA.Selenium;
using PageObjects.Components;
using Serilog;

namespace TranslateGoogleCom.PageObjects
{
    public class HomePage : BasePage
    { 
        private static readonly By RootSourceMenuLocator = By.XPath("//c-wiz[@data-node-index='3;0']//c-wiz[@data-node-index='1;0']/div[./button][1]");
        private static readonly By RootTargetMenuLocator = By.XPath("//c-wiz[@data-node-index='3;0']//c-wiz[@data-node-index='1;0']/div[./button][2]");
        private static readonly By TargetTextElementLocator = By.XPath("//div[@data-result-index]//span[@data-phrase-index='0']/span");//кошка
        private static readonly By SourceTextAreaLocator = By.XPath("//textarea[@aria-label='Source text']");
        private static readonly By ReverseButtonLocator = By.XPath("(.//*[@aria-label='Swap languages (Ctrl+Shift+S)'])[1]");   
        //".//*[@id='ow25']/div/span/button/div[3]") it works too.//*[@id='ow25']//button
     //
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
            Log.Logger.Information($"Typing source word {text}");
        }

        //property for reverse button (instance of the reverse button)
        public Button ReverseButton
        {
            get
            {
                return new Button(driver, ReverseButtonLocator);
            }
        }
    }
}
