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
    public class UserData
    {
        TimeSpan timeout = new TimeSpan(00, 00, 05);
        public ChromeDriver driver { set; get; }
        public string OrdNum { set; get; }
        public string ProductName { set; get; }
        public double prFromData { set; get; }

        public UserData(ChromeDriver driver)
        {
            this.driver = driver;
        }

        public void Action()
        {
            //driver.Navigate().Forward();
            //driver.Navigate().GoToUrl("http://teaco.ru/lk/store/");
            var Lk = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div[3]/div[2]/a")));
            Lk.Click();

            Task.Delay(800).Wait();
            var OrderNumber = driver.FindElementByXPath("/html/body/div[2]/div[4]/div/div[2]/div/div/div/div[2]/div/div[1]/div[1]").Text;
            string[] on = OrderNumber.Split(new Char[] { 'з', 'а', 'к', ' ' });
            foreach (string m in on)
            {
                if (m.Trim() != "");
            }
            OrdNum = on[5];

            var Info = driver.FindElementByXPath("/html/body/div[2]/div[4]/div/div[2]/div/div/div/div[2]/div/div[1]/div[4]/span");
            Info.Click();

            Task.Delay(800).Wait();
            string priceFromData = driver.FindElementByXPath("/html/body/div[2]/div[4]/div/div[2]/div/div/div/div[2]/div/div[2]/div/table/tfoot/tr/td[4]").Text;
            priceFromData = priceFromData.Replace('.', ',');
            string[] FD = priceFromData.Split(new Char[] {  'Р', ' ' });
            foreach (string m in FD)
            {
                if (m.Trim() != "");
            }
            prFromData = Convert.ToDouble(FD[0]);

            ProductName = driver.FindElementByXPath("/html/body/div[2]/div[4]/div/div[2]/div/div/div/div[2]/div/div[2]/div/table/tbody/tr/td[1]").Text;
        }
    }
}