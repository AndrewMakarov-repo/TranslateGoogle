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

        //[Test]

        //public void TestForCat()
        //{
        //    var text = "cat";
        //    var expectedResult = "кошка";

        //    homePage.SourceMenu.SelectLanguage("English");
        //    homePage.TargetMenu.SelectLanguage("Russian");
        //    homePage.FillInSource(text);

        //    var actualResult = homePage.GetTargetText();
        //    Assert.AreEqual(expectedResult, actualResult);

        //}

        [Test]

        public void TestPerAspira()
        {
            var text = "Per aspera ad astra";
            var expectedResult = "Через тернии к звездам";

            homePage.SourceMenu.SelectLanguage("Latin");
            homePage.TargetMenu.SelectLanguage("Russian");
            homePage.FillInSource(text);

            var actualResult = homePage.GetTargetText();
            Assert.AreEqual(expectedResult, actualResult);

        }

        //[Test]

        //public void TestForHello()
        //{
        //    var text = "hello";
        //    var expectedResult = "ciao";
        //    var afterReverseExpectedResult = "hello";
        //    var afterReverseExpectedSourceLanguage = "Italian";
        //    var afterReverseExpectedTargetLanguage = "English";

        //    homePage.SourceMenu.SelectLanguage("English");
        //    homePage.TargetMenu.SelectLanguage("Italian");
        //    homePage.FillInSource(text);

        //    var actualResult = homePage.GetTargetText();
        //    Assert.AreEqual(expectedResult, actualResult);

        //    //CLICK REVERSE
        //    Assert.Multiple(() =>
        //    {
        //        Assert.AreEqual(afterReverseExpectedResult, actualResult);
        //        Assert.AreEqual(homePage.SourceMenu.SelectLanguage, afterReverseExpectedTargetLanguage);
        //        Assert.AreEqual();
        //    });

    }
}