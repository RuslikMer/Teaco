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
    public class Admin
    {
        public double AdmOrd { set; get; }
        public string label { set; get; }
        public string s { set; get; }

        public ChromeDriver driver { set; get; }
        public Admin(ChromeDriver driver)
        {
            this.driver = driver;
        }
        public Admin(string s)
        {
            this.s = s;
        }

        public void Revocation()
        {

            TimeSpan timeout2 = new TimeSpan(00, 00, 05);

            //авторизация админки
            driver.Navigate().Forward();
            driver.Navigate().GoToUrl("http://teaco.ru/bitrix/admin/sale_order.php?PAGEN_1=1&SIZEN_1=20&lang=ru");
            var mail = (new WebDriverWait(driver, timeout2)).Until(ExpectedConditions.ElementIsVisible(By.Name("USER_LOGIN")));
            mail.Clear();
            mail.SendKeys("admin");
            var password = driver.FindElementByName("USER_PASSWORD");
            password.SendKeys("36Eoaz5m");
            password.Submit();

            //поиск заказа
            var search = (new WebDriverWait(driver, timeout2)).Until(ExpectedConditions.ElementIsVisible(By.Name("filter_universal")));
            search.SendKeys("тест");
            search.Submit();

            //детальная страница заказа
            search = (new WebDriverWait(driver, timeout2)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"tbl_sale_order\"]/tbody/tr[1]/td[4]/table/tbody/tr/td[2]/b/a")));
            search.Click();
            string AdminOrder = driver.FindElementById("sale-order-financeinfo-price-view").Text;
            AdminOrder = AdminOrder.Replace('.', ',');
            AdmOrd = Convert.ToDouble(AdminOrder);

            //отмена заказа
            var action = driver.FindElementByXPath("//*[@id=\"sale-adm-status-cancel-blocktext\"]/a");
            action.Click();
            driver.SwitchTo().Window(driver.WindowHandles.ToList().Last());
            action = (new WebDriverWait(driver, timeout2)).Until(ExpectedConditions.ElementIsVisible(By.Id("sale-adm-status-cancel-dialog-btn")));
            action.Click();

            //url заказа
            driver.SwitchTo().Window(driver.WindowHandles.ToList().First());
            label = driver.SwitchTo().Window(driver.WindowHandles.ToList().First()).Url;
        }
    }
}
