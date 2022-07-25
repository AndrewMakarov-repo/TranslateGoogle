using OpenQA.Selenium;
using System;
using System.Linq;
using System.Threading;

namespace TranslateGoogleCom.PageObjects
{
    public class HomePage : BasePage
    {
        private IWebDriver driver;

        //ctor
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private static string SelectedTargetElementFromDropDownLocator = "//div[@data-language-code]/div[text()='{0}']";
        private static string SelectedSourceElementFromDropDownLocator = "//div[@data-language-code]/div[text()='{0}']";

        //locators
        private static readonly By TargetTextElementLocator = By.XPath("//div[@data-result-index]//span[@data-phrase-index='0']/span");//кошка
        private static readonly By SourceTextAreaLocator = By.XPath("//textarea[@aria-label='Source text']");
        private static readonly By SelectedTargetElementLocator = By.XPath("(//div[@role='tablist'])[2]//button[@aria-selected='true']");
        private static readonly By QuickTargetMenuButtonsLocator = By.XPath("(//div[@role='tablist'])[2]//button[@aria-selected='false']");
        private static readonly By DropTargetDownMenuButtonLocator = By.XPath("//button[@aria-label='More target languages']");
        //private static readonly By selectedTargetElementFromDropDownLocator = By.XPath($"//div[@data-language-code]/div[text()='Russian']");
        private static readonly By SelectedSourceElementLocator = By.XPath("(//div[@role='tablist'])[1]//button[@aria-selected='true']");
        private static readonly By QuickSourceMenuButtonsLocator = By.XPath("(//div[@role='tablist'])[1]//button[@aria-selected='false']");
        private static readonly By DropSourceDownMenuButtonLocator = By.XPath("//button[@aria-label='More source languages']");
        //private static readonly By selectedSourceElementFromDropDownLocator = By.XPath($"//div[@data-language-code]/div[text()='English']");

        public string GetTargetText()
        {
            Thread.Sleep(3000);
            var targetTextElement = this.driver.FindElement(TargetTextElementLocator);
            return targetTextElement.Text;
        }

        #region Source

        public void FillInSource(string text)
        {
            var sourceTextArea = this.driver.FindElement(SourceTextAreaLocator);
            sourceTextArea.SendKeys(text);
            sourceTextArea.SendKeys(Keys.Enter);
        }

        public void SelectSourceLanguage(string language)
        {
            if (CheckSelectedSourceLanguage(language))
            {
                return;
            }

            if (CheckSourceQuickMenu(language))
            {
                SelectSourceQuickMenu(language);
            }
            else
            {
                SelectLanguageFromMoreMenu(language);
            }
        }

        //Check selected source language
        public bool CheckSelectedSourceLanguage(string language)
        {
            var selectedSourceElement = this.driver.FindElement(SelectedSourceElementLocator);
            var selectedLanguage = selectedSourceElement.Text;
            return selectedLanguage == language;
        }

        //Check Quick menu
        public void SelectSourceQuickMenu(string language)
        {
            var quickSourceMenuButtons = this.driver.FindElements(QuickSourceMenuButtonsLocator);
            var possibleElement = quickSourceMenuButtons.Where(x => string.Equals(x.Text, language, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            if (possibleElement != null)
            {
                possibleElement.Click();
            }
        }

        public bool CheckSourceQuickMenu(string language)
        {
            var quickSourceMenuButtons = this.driver.FindElements(QuickSourceMenuButtonsLocator);
            var possibleElement = quickSourceMenuButtons.Where(x => string.Equals(x.Text, language, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            return possibleElement != null;
        }

        //Select and click 'English' from drop-down menu
        public void SelectLanguageFromMoreMenu(string language)
        {
            var dropSourceDownMenuButtons = this.driver.FindElements(DropSourceDownMenuButtonLocator);
            var firstDropDownMenuButton = dropSourceDownMenuButtons.FirstOrDefault(x => x.Displayed);
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

            var selectedSourceElementFromDropDown = this.driver.FindElements(By.XPath(string.Format(SelectedSourceElementFromDropDownLocator, language)));
            var selectedLanguageFromDropDown = selectedSourceElementFromDropDown.Where(x => x.Displayed).FirstOrDefault();
            if (selectedLanguageFromDropDown != null)
            {
                selectedLanguageFromDropDown.Click();
            }
        }
        #endregion

        #region Target
        public void SelectTargetLanguage(string language)
        {
            if (CheckSelectedTargetLanguage(language))
            {
                return;
            }

            if (CheckTargetQuickMenu(language))
            {
                SelectTargetQuickMenu(language);
            }
            else
            {
                SelectLanguageTargetMoreMenu(language);
            }
        }

        //Check selected target language
        public bool CheckSelectedTargetLanguage(string language)
        {
            var selectedTargetElement = this.driver.FindElement(SelectedTargetElementLocator);
            var selectedLanguage = selectedTargetElement.Text;
            return selectedLanguage == language;
        }

        //Check Quick menu
        public void SelectTargetQuickMenu(string language)
        {
            var quickTargetMenuButtons = this.driver.FindElements(QuickTargetMenuButtonsLocator);
            var possibleElement = quickTargetMenuButtons.Where(x => string.Equals(x.Text, language, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            if (possibleElement != null)
            {
                possibleElement.Click();
            }
        }

        public bool CheckTargetQuickMenu(string language)
        {
            var quickTargetMenuButtons = this.driver.FindElements(QuickTargetMenuButtonsLocator);
            var possibleElement = quickTargetMenuButtons.Where(x => string.Equals(x.Text, language, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            return possibleElement != null;
        }

        //Select and click 'Russian' from drop-down menu
        public void SelectLanguageTargetMoreMenu(string language)
        {
            var dropTargetDownMenuButton = this.driver.FindElements(DropTargetDownMenuButtonLocator);
            var firstDropDownMenuButton = dropTargetDownMenuButton.FirstOrDefault(x => x.Displayed);
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
            var selectedTargetElementFromDropDown = this.driver.FindElements(By.XPath(string.Format(SelectedTargetElementFromDropDownLocator, language)));
            var selectedLanguageFromDropDown = selectedTargetElementFromDropDown.Where(x => x.Displayed).FirstOrDefault();
            //TODO: change to explicit wait 
            Thread.Sleep(1500);
            if (selectedLanguageFromDropDown != null)
            {
                selectedLanguageFromDropDown.Click();
            }
        }
        #endregion
    }
}
