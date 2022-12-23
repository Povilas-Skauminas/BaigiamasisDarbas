using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using Baigiamasis_darbas.NewFolder;

namespace Baigiamasis_darbas.NewFolder

{
    public class MainMethods
    {



        public void ClickElementByXpath(IWebDriver driver, string xpath)
        {
            By by = By.XPath(xpath);
            driver.FindElement(by).Click();
        }

        public void GoToUrl(IWebDriver driver, string url)
        {
            driver.Url = url;
        }
        public void SendKeysByXpath(IWebDriver driver, string xpath, string text)
        {
            driver.FindElement(By.XPath(xpath)).SendKeys(text);
        }

        public void CheckIfElementIsThereByXpath(IWebDriver driver, string xpath)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element to be searched not found";
            IWebElement searchResult = fluentWait.Until(x => x.FindElement(By.XPath(xpath)));
        }
        public void ScrollFunctionBy150(IWebDriver driver)
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            System.Threading.Thread.Sleep(1000);
            js.ExecuteScript("window.scrollBy(0,150);");
        }
 
        public void tear(IWebDriver driver)
        {
            driver.Quit();
        }
    }
}
    