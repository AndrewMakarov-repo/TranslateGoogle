using Core;
using NUnit.Framework;
using TranslateGoogleCom.PageObjects;

namespace TranslateGoogleCom.Tests
{
    public class Tests : BaseTest
    {
        public HomePage homePage;

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
            var text = "cat";
            var expectedResult = "кошка";

            homePage.SelectSourceLanguage("English");
            homePage.SelectTargetLanguage("Russian");
            homePage.FillInSource(text);

            var actualResult = homePage.GetTargetText();
            Assert.AreEqual(expectedResult, actualResult);

        }
    }
}
