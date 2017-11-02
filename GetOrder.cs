using System;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Teaco
{
    public class GetOrder
    {
        TimeSpan timeout = new TimeSpan(00, 00, 05);
        public ChromeDriver driver { set; get; }
        public double Pr { set; get; }
        public double OrCheck { set; get; }
        public double TSum { set; get; }

        public GetOrder(ChromeDriver driver)
        {
            this.driver = driver;
        }

        public void Action()
        {
            driver.SwitchTo().Window(driver.WindowHandles.ToList().Last());
            var popup = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"fancybox-lock\"]/div/a")));
            popup.Click();
            Task.Delay(1500).Wait();
            var buy = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div[5]/div[2]/div[2]/div[3]/div[2]/div/div/div/div[4]")));
            buy.Click();
            string price = driver.FindElementByXPath("/html/body/div[2]/div[5]/div[2]/div[2]/div[3]/div[2]/div/div/div/div[1]/span").Text;
            price = price.Replace('.', ',');
            Pr = Convert.ToDouble(price);
            var trash = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div[1]/header/div/div[2]/div[3]/a/div")));
            trash.Click();
            driver.SwitchTo().Window(driver.WindowHandles.ToList().Last());
            trash = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div[1]/header/div/div[2]/div[3]/div/a")));
            trash.Click();
            var getOrder = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div[3]/div[2]/div[2]/div[2]/div[2]/div[4]/a")));
            getOrder.Click();
        }

        public void CheckOut()
        {
            var check = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div[3]/div[2]/div/form/div[1]/div[1]/div[2]/div[1]/div/label/span")));
            check.Click();
            string OrderChek = driver.FindElementByXPath("/html/body/div[2]/div[3]/div[2]/div/form/div[1]/div/div[1]/div[1]/div[2]/div/div[2]/div[1]").Text;
            OrderChek = OrderChek.Replace('.', ',');
            string[] prOrd = OrderChek.Split(new Char[] { 'Р', ' ' });
            foreach (string m in prOrd)
            {
                if (m.Trim() != "");
            }
            OrCheck = Convert.ToDouble(prOrd[0]);

            string TotalSum = driver.FindElementByXPath("/html/body/div[2]/div[3]/div[2]/div/form/div[1]/div[1]/div[1]/div[4]/div[2]/div").Text;
            TotalSum = TotalSum.Replace('.', ',');
            string[] TotS = TotalSum.Split(new Char[] { 'Р', ' ' });
            foreach (string m in TotS)
            {
                if (m.Trim() != "");
            }
            TSum = Convert.ToDouble(TotS[0]);

            var wayOfpay = driver.FindElementByXPath("/html/body/div[2]/div[3]/div[2]/div/form/div[2]/div[4]/div[9]/label");
            wayOfpay.Click();
            wayOfpay.Submit();
        }

        public void SelfDelivery()
        {
            var SDel = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div[3]/div[2]/div/form/div[2]/div[3]/div[1]/span")));
            SDel.Click();
        }

        public void Delivery()
        {
            var Del = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div[3]/div[2]/div/form/div[2]/div[3]/div[2]/span")));
            Del.Click();
            var location = driver.FindElementByXPath("/html/body/div[2]/div[3]/div[2]/div/form/div[2]/div[4]/div[6]/div[2]/div[1]/div[2]/ul");
            location.Click();
            location = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div[3]/div[2]/div/form/div[2]/div[4]/div[6]/div[2]/div[1]/div[2]/div/ul/li[1]")));
            location.Click();
            location = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div[3]/div[2]/div/form/div[2]/div[4]/div[6]/div[3]/div/div/div[2]/ul")));
            location.Click();
            //location.Clear();
            //location = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div[3]/div[2]/div/form/div[2]/div[4]/div[6]/div[3]/div/div/div[2]/div/ul/li[1]")));
            //location.Click();
        }
    }
}