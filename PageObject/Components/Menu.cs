using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjects.Components
{
    public class Menu : IMenu
    {

        //locator for left and right quick menu "//c-wiz[@data-node-index='3;0']//c-wiz[@data-node-index='1;0']/div[./button]"
        //locator for left and right drop-down in quick menu "//c-wiz[@data-node-index='3;0']//c-wiz[@data-node-index='1;0']/div/button"

        private IWebDriver driver;

        private static readonly By SelectedSourceElementLocator = By.XPath("(//div[@role='tablist'])[1]//button[@aria-selected='true']");
        private static readonly By SelectedTargetElementLocator = By.XPath("(//div[@role='tablist'])[2]//button[@aria-selected='true']");
        private readonly By SelectedLanguageLocator;

        public string SelectedLanguage 
        {
            get
            {
                var selectedElement = driver.FindElement(SelectedLanguageLocator);
                return selectedElement.Text;
            } 
        }

        public void SelectLanguage(string language)
        {
        }
    }
}
