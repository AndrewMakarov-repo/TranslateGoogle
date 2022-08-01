using Core.Utilities.Extentions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PageObjects.Components
{
    public class Menu : IMenu
    {

        //locator for left and right quick menu "//c-wiz[@data-node-index='3;0']//c-wiz[@data-node-index='1;0']/div[./button]"
        //locator for left and right drop-down in quick menu "//c-wiz[@data-node-index='3;0']//c-wiz[@data-node-index='1;0']/div/button"

        private IWebDriver driver;
        private IWebElement rootElement;

        private static readonly By SelectedLanguageLocator = By.XPath(".//button[@aria-selected='true']");
        //private static readonly By QuickTargetMenuButtonsLocator = By.XPath("(//div[@role='tablist'])[2]//button[@aria-selected='false']");
        //private static readonly By QuickSourceMenuButtonsLocator = By.XPath("(//div[@role='tablist'])[1]//button[@aria-selected='false']");
        //private static readonly By DropTargetDownMenuButtonLocator = By.XPath("//button[@aria-label='More target languages']");
        //private static readonly By DropSourceDownMenuButtonLocator = By.XPath("//button[@aria-label='More source languages']");
        //private static string SelectedTargetElementFromDropDownLocator = "//div[@data-language-code]/div[text()='{0}']";
        //private static string SelectedSourceElementFromDropDownLocator = "//div[@data-language-code]/div[text()='{0}']";



        private static readonly By QuickMenuButtonsLocator = By.XPath(".//button[@aria-selected='false']");
        private static readonly By DropDownMenuButtonLocator = By.XPath(".//button[contains(@aria-label,'More')]");
        private static string SelectedElementFromDropDownLocator = "//div[@data-language-code]/div[text()='{0}']";

        //ctor
        public Menu(IWebDriver driver, IWebElement rootElement)
        {
            this.driver = driver;
            this.rootElement = rootElement;
        }

        //ctor2
        public Menu(IWebDriver driver, By rootElementLocator)
        {
            this.driver = driver;
            this.rootElement = driver.FindElement(rootElementLocator);
        }


        public string SelectedLanguage 
        {
            get
            {
                var selectedElement = rootElement.FindElement(SelectedLanguageLocator);
                return selectedElement.Text;
            } 
        }

        public void SelectLanguage(string language)
        {
            if (SelectedLanguage == language)
            {
                return;
            }

            if (CheckQuickMenu(language))
            {
                SelectQuickMenu(language);
            }
            else
            {
                SelectLanguageFromMoreMenu(language);
            }
        }

        private void SelectLanguageFromMoreMenu(string language)
        {
            var dropDownMenuButtons = this.rootElement.FindElements(DropDownMenuButtonLocator);
            var firstDropDownMenuButton = dropDownMenuButtons.FirstOrDefault(x => x.Displayed);
            if (firstDropDownMenuButton != null)
            {
                //Actions action = new Actions(driver);
                //action.MoveToElement((IWebElement)firstDropDownMenuButton).Click().Perform();
                firstDropDownMenuButton.Click();
            }
            else
            {
                throw new Exception("Drop-down menu is not found");
            }
            Thread.Sleep(5000);
            var selectedSourceElementFromDropDown = this.rootElement.FindElements(By.XPath(string.Format(SelectedElementFromDropDownLocator, language)));
            Thread.Sleep(5000);
            var selectedLanguageFromDropDown = selectedSourceElementFromDropDown.Where(x => x.Displayed).FirstOrDefault();
            Thread.Sleep(5000);

            driver.HoverAndClick(selectedLanguageFromDropDown);

        }

        private void SelectQuickMenu(string language)
        {
            var quickMenuButtons = this.rootElement.FindElements(QuickMenuButtonsLocator);
            var possibleElement = quickMenuButtons.Where(x => string.Equals(x.Text, language, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            if (possibleElement != null)
            {
                possibleElement.Click();
            }
        }

        private bool CheckQuickMenu(string language)
        {
            var quickMenuButtons = this.rootElement.FindElements(QuickMenuButtonsLocator);
            var possibleElement = quickMenuButtons.Where(x => string.Equals(x.Text, language, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            return possibleElement != null;
        }
    }
}
