using Baigiamasis_darbas.NewFolder;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baigiamasis_darbas
{
    public class InidividualiosVeiklosSkaiciuoklesPatikra : MainMethods
    {
        browserController controller;

        [SetUp]
        public void setUp()
        {
            controller = new browserController();
            controller.driver.Manage().Window.Maximize();
            controller.driver.Url = "https://tax.lt/skaiciuokles/individualios_veiklos_mokesciu_skaiciuokle";
        }

        [Test]
        public void PatikraArIsivedaSkaiciai()
        {
            ClickElementByXpath(controller.driver, "//p[contains(text(),'Sutikimas')]");
            SendKeysByXpath(controller.driver, "//input[@name='pajamos']", "50");
            ScrollFunctionBy150(controller.driver);
            CheckIfElementIsThereByXpath(controller.driver, "//td[@id='pajamos_div' and contains(text(),'50,00')]");
        }

        [Test]
        public void PatikraArVeikiaPensijosKaupimoMygtukas()
        {
            ClickElementByXpath(controller.driver, "//p[contains(text(),'Sutikimas')]");
            ClickElementByXpath(controller.driver, "//input[@name='papildomas_pensijos_kaupimas']");
            CheckIfElementIsThereByXpath(controller.driver, "//select[@id='papildomas_pensijos_kaupimas_procentai']");
        }

        [Test]
        public void PatikraArVeikiaSanauduSkaiciavimoMygtukai()
        {
            ClickElementByXpath(controller.driver, "//p[contains(text(),'Sutikimas')]");
            ScrollFunctionBy150(controller.driver);
            SendKeysByXpath(controller.driver, "//input[@name='pajamos']", "200");
            ClickElementByXpath(controller.driver, "//input[@id='kaip_skaiciuojamos_sanaudos_2']");
            CheckIfElementIsThereByXpath(controller.driver, "//td[@id='sanaudos_div' and contains(text(),'60,00')]");
            ClickElementByXpath(controller.driver, "//input[@id='kaip_skaiciuojamos_sanaudos_1']");
            CheckIfElementIsThereByXpath(controller.driver, "//td[@id='sanaudos_div' and contains(text(),'0,00')]");
        }

        [TearDown]
        public void tearDown()
        {
            tear(controller.driver);
        }
    }
}
