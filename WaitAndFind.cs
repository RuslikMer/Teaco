using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System.Drawing.Imaging;
using System.IO;
using OpenQA.Selenium;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using OpenQA.Selenium.Support.UI;

namespace Teaco
{
    public class WaitAndFind
    {
        TimeSpan timeout = new TimeSpan(00, 00, 05);
        public ChromeDriver driver { set; get; }
        string s = " ";

        public WaitAndFind(ChromeDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement Xpath(string x)
        {
            return new WebDriverWait(driver, timeout).Until(ExpectedConditions.ElementIsVisible(By.XPath(x)));
        }

        public void Name(string x)
        {
            driver.FindElement(By.Name("REGISTER[EMAIL]")).SendKeys(x);
        }

        public IWebElement Id(string x)
        {
            return new WebDriverWait(driver, timeout).Until(ExpectedConditions.ElementIsVisible(By.Id(x)));
        }

        public IWebElement ClassName(string x)
        {
            return new WebDriverWait(driver, timeout).Until(ExpectedConditions.ElementIsVisible(By.ClassName(x)));
        }
    }
}
