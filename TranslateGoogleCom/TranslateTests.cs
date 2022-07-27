//using NUnit.Framework;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Interactions;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace TranslateGoogleCom
//{
//    public class TranslateTests
//    {
//        /// <summary>
//        /// site: translate.google.com
//        /// TC#1
//        /// 1. select source lang: english
//        /// 2. select target lang: russian
//        /// 3. fill source: "cat"
//        /// 4. check result: should be "кошка"
//        /// </summary>

//        [Test]
//        public void TranslateTest()
//        {
//            #region Arrange
//            //Arrange

//            //var driver = new ChromeDriver();
//            //driver.Manage().Window.Maximize();
//            ////driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
//            //driver.Navigate().GoToUrl("https://translate.google.com/");
//            //var text = "cat";
//            //var expectedResult = "кошка";
//            #endregion


//            #region Act
//            //Act

//            //Thread.Sleep(6000);

//            SelectSourceLanguage(driver, "English");
//            SelectTargetLanguage(driver, "Russian");
//            FillInSource(driver, text);

//            #endregion

//            //Assert

//            var actualResult = GetTargetText(driver);
//            Assert.AreEqual(expectedResult, actualResult);
            
//            //Post Condition
//            driver.Quit();
//        }

//        private string GetTargetText(ChromeDriver driver)
//        {
//            Thread.Sleep(3000);
//            //var targetTextElement = driver.FindElement(By.XPath("//div[@data-result-index]//span[@data-phrase-index='0']/span"));
//            return targetTextElement.Text;
//        }


//        ////!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
//        ////FILL IN SOURCE
//        ////!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
//        //private void FillInSource(ChromeDriver driver, string text)
//        //{
//        //    //var sourceTextArea = driver.FindElement(By.XPath("//textarea[@aria-label='Source text']"));
//        //    sourceTextArea.SendKeys(text);
//        //    sourceTextArea.SendKeys(Keys.Enter);
//        //}


//        #region Target
//        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
//        //TARGET
//        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

//        private void SelectTargetLanguage(IWebDriver driver, string language)
//        {
//            if (CheckSelectedTargetLanguage(driver, language))
//            {
//                return;
//            }

//            if (CheckTargetQuickMenu(driver, language))
//            {
//                SelectTargetQuickMenu(driver, language);
//            }
//            else
//            {
//                SelectLanguageTargetMoreMenu(driver, language);
//            }
//        }

//        //Check selected target language
//        private bool CheckSelectedTargetLanguage(IWebDriver driver, string language)
//        {
//            //var selectedElement = driver.FindElement(By.XPath("(//div[@role='tablist'])[2]//button[@aria-selected='true']"));
//            var selectedLanguage = selectedElement.Text;
//            return selectedLanguage == language;
//        }

//        //Check Quick menu
//        private void SelectTargetQuickMenu(IWebDriver driver, string language)
//        {
//            //var quickMenuButtons = driver.FindElements(By.XPath("(//div[@role='tablist'])[2]//button[@aria-selected='false']"));
//            var possibleElement = quickMenuButtons.Where(x => string.Equals(x.Text, language, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
//            if (possibleElement != null)
//            {
//                possibleElement.Click();
//            }
//        }

//        private bool CheckTargetQuickMenu(IWebDriver driver, string language)
//        {
//            // var quickMenuButtons = driver.FindElements(By.XPath("(//div[@role='tablist'])[2]//button[@aria-selected='false']"));
//            var possibleElement = quickMenuButtons.Where(x => string.Equals(x.Text, language, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
//            return possibleElement != null;
//        }

//        //Select and click 'Russian' from drop-down menu
//        private void SelectLanguageTargetMoreMenu(IWebDriver driver, string language)
//        {
//            //var dropDownMenuButton = driver.FindElements(By.XPath("//button[@aria-label='More target languages']"));
//            var firstDropDownMenuButton = dropDownMenuButton.FirstOrDefault(x => x.Displayed);
//            if (firstDropDownMenuButton != null)
//            {
//                //Actions action = new Actions(driver);
//                //action.MoveToElement((IWebElement)firstDropDownMenuButton).Click().Perform();
//                firstDropDownMenuButton.Click();
//            }
//            else
//            {
//                throw new Exception("Drop-down menu is not found");
//            }

//            // var selectedElementFromDropDown = driver.FindElements(By.XPath($"//div[@data-language-code]/div[text()='{language}']"));
//            var selectedLanguageFromDropDown = selectedElementFromDropDown.Where(x => x.Displayed).FirstOrDefault();
//            //TODO: change to explicit wait 
//            Thread.Sleep(500);
//            if (selectedLanguageFromDropDown != null)
//            {
//                selectedLanguageFromDropDown.Click();
//            }
//        }

//        #endregion

//        #region Source
//        ////!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
//        ////SOURCE
//        ////!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

//        //private void SelectSourceLanguage(IWebDriver driver, string language)
//        //{
//        //    if (CheckSelectedSourceLanguage(driver, language))
//        //    {
//        //        return;
//        //    }

//        //    if (CheckSourceQuickMenu(driver, language))
//        //    {
//        //        SelectSourceQuickMenu(driver, language);
//        //    }
//        //    else
//        //    {
//        //        SelectLanguageFromMoreMenu(driver, language);
//        //    }
//        //}


//        ////Check selected source language
//        //private bool CheckSelectedSourceLanguage(IWebDriver driver, string language)
//        //{
//        //    //var selectedElement = driver.FindElement(By.XPath("(//div[@role='tablist'])[1]//button[@aria-selected='true']"));
//        //    var selectedLanguage = selectedElement.Text;
//        //    return selectedLanguage == language;
//        //}

//        ////****Select language from Drop-down list******************]
//        ////Check Quick menu
//        //private void SelectSourceQuickMenu(IWebDriver driver, string language)
//        //{
//        //  //  var quickMenuButtons = driver.FindElements(By.XPath("(//div[@role='tablist'])[1]//button[@aria-selected='false']"));
//        //    var possibleElement = quickMenuButtons.Where(x => string.Equals(x.Text, language, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
//        //    if (possibleElement != null)
//        //    {
//        //        possibleElement.Click();
//        //    }
//        //}

//        //private bool CheckSourceQuickMenu(IWebDriver driver, string language)
//        //{
//        //    //var quickMenuButtons = driver.FindElements(By.XPath("(//div[@role='tablist'])[1]//button[@aria-selected='false']"));
//        //    var possibleElement = quickMenuButtons.Where(x => string.Equals(x.Text, language, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
//        //    return possibleElement != null;
//        //}

//        ////Select and click 'English' from drop-down menu
//        //private void SelectLanguageFromMoreMenu(IWebDriver driver, string language)
//        //{
//        //    //var dropDownMenuButton = driver.FindElements(By.XPath("//button[@aria-label='More source languages']"));
//        //    var firstDropDownMenuButton = dropDownMenuButton.FirstOrDefault(x => x.Displayed);
//        //    if (firstDropDownMenuButton != null)
//        //    {
//        //        //Actions action = new Actions(driver);
//        //        //action.MoveToElement((IWebElement)firstDropDownMenuButton).Click().Perform();
//        //        firstDropDownMenuButton.Click();
//        //    }
//        //    else
//        //    {
//        //        throw new Exception("Drop-down menu is not found");
//        //    }

//        //    //var selectedElementFromDropDown = driver.FindElements(By.XPath($"//div[@data-language-code]/div[text()='{language}']"));
//        //    var selectedLanguageFromDropDown = selectedElementFromDropDown.Where(x => x.Displayed).FirstOrDefault();
//        //    if (selectedLanguageFromDropDown != null)
//        //    {
//        //        selectedLanguageFromDropDown.Click();
//        //    }
//        //}

//        #endregion
//    }
//}
    

