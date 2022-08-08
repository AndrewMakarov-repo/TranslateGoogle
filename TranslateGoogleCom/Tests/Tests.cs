using Core;
using NUnit.Framework;
using TranslateGoogleCom.PageObjects;

namespace TranslateGoogleCom.Tests
{
    public class Tests : BaseTest
    {
        public HomePage homePage;

        private static readonly object[] _sourceLists =
        {
            new object[] {"English", "Russian", "cat", "кошка"},   //case 1
            new object[] {"English", "Russian", "dog", "собака"}   //case 2
        };

        [SetUp]

        #region Setup
        public void Setup()
        {
            this.homePage = new HomePage(driver);
        }
        #endregion

        #region TestCases
        //[TestCase("cat","кошка","English", "Russian")]
        //[TestCase("dog", "собака","English", "Russian")]
        //[TestCase("mouse", "мыши","English", "Russian")]
        //[TestCase("Hello", "Ciao", "English", "Italian")]

        //[TestCaseSource(typeof(TestDataReader), "TestCases")]
        //public void DataDrivenTestFromFile(string sourceLanguage, string targetLanguage, string text, string expectedResult)//see TestDataReader tab
        //{
        //    //Arrange
        //    //var text = "cat";
        //    //var expectedResult = "кошка";

        //    //Act
        //    homePage.SourceMenu.SelectLanguage(sourceLanguage);
        //    homePage.TargetMenu.SelectLanguage(targetLanguage);
        //    homePage.FillInSource(text);

        //    //Assert
        //    var actualResult = homePage.GetTargetText();
        //    Assert.AreEqual(expectedResult, actualResult);
        //}

        [TestCaseSource(nameof(_sourceLists))]
        public void DataDrivenTestFromObjects(string sourceLanguage, string targetLanguage, string text, string expectedResult)
        {
            //Arrange
            //var text = "cat";
            //var expectedResult = "кошка";

            //Act
            homePage.SourceMenu.SelectLanguage(sourceLanguage);
            homePage.TargetMenu.SelectLanguage(targetLanguage);
            homePage.FillInSource(text);

            //Assert
            var actualResult = homePage.GetTargetText();
            Assert.AreEqual(expectedResult, actualResult);
        }


        #endregion



        #region Tests (w/o TDD)
        //[Test]
        //public void TestForCat()
        //{
        //    //Arrange
        //    var text = "cat";
        //    var expectedResult = "кошка";

        //    //Act
        //    homePage.SourceMenu.SelectLanguage("English");
        //    homePage.TargetMenu.SelectLanguage("Russian");
        //    homePage.FillInSource(text);

        //    //Assert
        //    var actualResult = homePage.GetTargetText();
        //    Assert.AreEqual(expectedResult, actualResult);

        //}

        //[Test]
        //public void TestPerAspera()
        //{
        //    //Arrange
        //    var text = "Per aspera ad astra";
        //    var expectedResult = "Через трудности для звезд";

        //    //Act
        //    homePage.SourceMenu.SelectLanguage("Latin");
        //    homePage.TargetMenu.SelectLanguage("Russian");
        //    homePage.FillInSource(text);

        //    //Assert
        //    var actualResult = homePage.GetTargetText();
        //    Assert.AreEqual(expectedResult, actualResult);
        //}

        //[Test]

        //public void TestForHello()
        //{
        //    //Arrange
        //    var text = "Hello";
        //    var expectedResult = "Ciao";
        //    var afterReverseExpectedSourceLanguage = "ITALIAN";
        //    var afterReverseExpectedTargetLanguage = "ENGLISH";

        //    //Act and assert
        //    homePage.SourceMenu.SelectLanguage("English");
        //    homePage.TargetMenu.SelectLanguage("Italian");
        //    homePage.FillInSource(text);

        //    var actualResult = homePage.GetTargetText();
        //    Assert.AreEqual(expectedResult, actualResult);

        //    //CLICK REVERSE
        //    //Act and assert
        //    homePage.ReverseButton.ClickButton();
        //    Thread.Sleep(200);
        //    var actualResultAfterReverse = homePage.GetTargetText();
        //    Assert.Multiple(() =>
        //    {
        //        Assert.AreEqual(text, actualResultAfterReverse);
        //        Assert.AreEqual(homePage.SourceMenu.SelectedLanguage, afterReverseExpectedSourceLanguage);
        //        Assert.AreEqual(homePage.TargetMenu.SelectedLanguage, afterReverseExpectedTargetLanguage);
        //    });
        //}
        #endregion
    }
}