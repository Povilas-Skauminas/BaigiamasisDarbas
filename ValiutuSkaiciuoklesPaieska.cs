using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baigiamasis_darbas.NewFolder;
using NUnit.Framework;

namespace Baigiamasis_darbas
{
    public class ValiutuSkaiciuoklesPaieska : MainMethods
    {
        browserController controller;

        [SetUp]
        public void setUp()
        {
            controller = new browserController();
            controller.driver.Manage().Window.Maximize();
            controller.driver.Url = "https://www.tax.lt/skaiciuokles/valiutu_skaiciuokle";
        }

        [Test]
        public void PatikrintiArGalimaPridetiValiutas()
        {
            ClickElementByXpath(controller.driver, "//p[contains(text(),'Sutinku')]");
            ClickElementByXpath(controller.driver, "//select[@id='add_currency']");
            ClickElementByXpath(controller.driver, "//select[@id='add_currency']//option[@value='MDL']");
            CheckIfElementIsThereByXpath(controller.driver, "//label[contains(text(),'MDL')]");
        }

        [Test]
        public void PatikrintiArVeikiaKalendoriausForamtoKeitimoFunkcija()
        {
            ClickElementByXpath(controller.driver, "//p[contains(text(),'Sutinku')]");
            ClickElementByXpath(controller.driver, "//input[@id='rate_date']");
            ClickElementByXpath(controller.driver, "//html/body/div[3]/div[1]/table/thead/tr[1]/th[2]");
            ClickElementByXpath(controller.driver, "//html/body/div[3]/div[2]/table/thead/tr/th[2]");
            CheckIfElementIsThereByXpath(controller.driver, "//span[@class='year' and contains(text(),'2028')]");
        }

        [Test]
        public void PatikrintiArPridejusValiutaAtsirandaVeliava()
        {
            ClickElementByXpath(controller.driver, "//p[contains(text(),'Sutinku')]");
            ClickElementByXpath(controller.driver, "//select[@id='add_currency']");
            ClickElementByXpath(controller.driver, "//select[@id='add_currency']//option[@value='MDL']");
            CheckIfElementIsThereByXpath(controller.driver, "//img[@src='/images/flags/md.png']");
        }
        
        [TearDown]
        public void tearDown()
        {
            tear(controller.driver);
        }
    }
}
