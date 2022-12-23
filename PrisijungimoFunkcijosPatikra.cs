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
using static System.Net.WebRequestMethods;

namespace Baigiamasis_darbas
{
    public class PrisijungimoFunkcijosPatikra : MainMethods
    {
        browserController controller;

        [SetUp]
        public void setUp()
        {
            controller = new browserController();
            controller.driver.Manage().Window.Maximize();
            controller.driver.Url = "https://tax.lt/";
        }

        [Test]
        public void NesekmingasPrisijungimas()
        {
            ClickElementByXpath(controller.driver, "//p[contains(text(),'Sutikimas')]");
            ClickElementByXpath(controller.driver, "//a[@class='btn btn-info']");
            SendKeysByXpath(controller.driver, "//input[@name='user[login]']", "test123");
            SendKeysByXpath(controller.driver, "//input[@name='user[password]']", "test123");
            ClickElementByXpath(controller.driver, "//input[@type='submit']");
            CheckIfElementIsThereByXpath(controller.driver, "//div[@class='alert alert-error']");
        }

        [Test]
        public void SekmingasPrisijungimas()
        {
            ClickElementByXpath(controller.driver, "//p[contains(text(),'Sutikimas')]");
            ClickElementByXpath(controller.driver, "//a[@class='btn btn-info']");
            SendKeysByXpath(controller.driver, "//input[@name='user[login]']", "test123");
            SendKeysByXpath(controller.driver, "//input[@name='user[password]']", "test123456789");
            ClickElementByXpath(controller.driver, "//input[@type='submit']");
            CheckIfElementIsThereByXpath(controller.driver, "//div[@class='alert alert-success']");
        }
        [Test]
        public void PatikrinimasArPrijungtaIReikiamaVartotoja()
        {
            ClickElementByXpath(controller.driver, "//p[contains(text(),'Sutikimas')]");
            ClickElementByXpath(controller.driver, "//a[@class='btn btn-info']");
            SendKeysByXpath(controller.driver, "//input[@name='user[login]']", "test123");
            SendKeysByXpath(controller.driver, "//input[@name='user[password]']", "test123456789");
            ClickElementByXpath(controller.driver, "//input[@type='submit']");
            ClickElementByXpath(controller.driver, "//a[@class='btn' and contains(text(),' test123')]");
            CheckIfElementIsThereByXpath(controller.driver, "//h1[contains(text(),'test123 nustatymai')]");
        }

        [TearDown]
        public void tearDown()
        {
            tear(controller.driver);
        }
    }
}
