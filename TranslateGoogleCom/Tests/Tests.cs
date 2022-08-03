using Core;
using Core.UI.PageElements;
using Core.Utilities.Extentions;
using NUnit.Framework;
using OpenQA.Selenium;
using PageObjects.Components;
using System.Threading;
using TranslateGoogleCom.PageObjects;

namespace TranslateGoogleCom.Tests
{
    public class Tests : BaseTest
    {
        public HomePage homePage;
        private IWebDriver reverseButton;
        private By rootElementLocator;


        [SetUp]

        #region Setup
        public void Setup()
        {
            this.homePage = new HomePage(driver);
        }
        #endregion

        [Test]
        public void TestForCat()
        {
            //Arrange
            var text = "cat";
            var expectedResult = "кошка";

            //Act
            homePage.SourceMenu.SelectLanguage("English");
            homePage.TargetMenu.SelectLanguage("Russian");
            homePage.FillInSource(text);

            //Assert
            var actualResult = homePage.GetTargetText();
            Assert.AreEqual(expectedResult, actualResult);

        }

        [Test]
        public void TestPerAspera()
        {
            //Arrange
            var text = "Per aspera ad astra";
            var expectedResult = "Через трудности для звезд";

            //Act
            homePage.SourceMenu.SelectLanguage("Latin");
            homePage.TargetMenu.SelectLanguage("Russian");
            homePage.FillInSource(text);

            //Assert
            var actualResult = homePage.GetTargetText();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]

        public void TestForHello()
        {
            //Arrange
            var text = "Hello";
            var expectedResult = "Ciao";
            var afterReverseExpectedSourceLanguage = "ITALIAN";
            var afterReverseExpectedTargetLanguage = "ENGLISH";

            //Act and assert
            homePage.SourceMenu.SelectLanguage("English");
            homePage.TargetMenu.SelectLanguage("Italian");
            homePage.FillInSource(text);

            var actualResult = homePage.GetTargetText();
            Assert.AreEqual(expectedResult, actualResult);

            //CLICK REVERSE
            //Act and assert
            homePage.ReverseButton.ClickButton();
            Thread.Sleep(200);
            var actualResultAfterReverse = homePage.GetTargetText();
            Assert.Multiple(() =>
            {
                Assert.AreEqual(text, actualResultAfterReverse);
                Assert.AreEqual(homePage.SourceMenu.SelectedLanguage, afterReverseExpectedSourceLanguage);
                Assert.AreEqual(homePage.TargetMenu.SelectedLanguage, afterReverseExpectedTargetLanguage);
            });
        }
    }
}