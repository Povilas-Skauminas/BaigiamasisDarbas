using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baigiamasis_darbas.NewFolder
{
    internal class browserController
    {
        public IWebDriver driver;

        public browserController()
        {
            driver = new ChromeDriver();
        }
    }
}
