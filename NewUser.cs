using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Teaco
{
    public class NewUser
    {
        TimeSpan timeout = new TimeSpan(00, 00, 05);
        public ChromeDriver driver { set; get; }
        public string s { set; get; }
        public NewUser(ChromeDriver driver)
        {
            this.driver = driver;
        }

        public void Action()
        {
            s = "";
            string namb = "";

            var name = (new WebDriverWait(driver, timeout)).Until(ExpectedConditions.ElementIsVisible(By.Name("REGISTER[NAME]")));
            name.SendKeys("Тест");
            var lastName = driver.FindElementByName("REGISTER[LAST_NAME]");
            lastName.SendKeys("тест");

            Random rand = new Random();
            for (int v = 0; v < 6; v++)
            {
                s += Convert.ToChar(rand.Next(65, 90));
            }

            Admin admin = new Admin(s);

            var mail = driver.FindElement(By.Name("REGISTER[EMAIL]"));
            mail.SendKeys(s+"@mail.ru");

            Random randj = new Random();
            for (int v = 0; v < 7; v++)
            {
                namb += Convert.ToChar(rand.Next(48, 57));
            }

            var phone = driver.FindElementByName("REGISTER[PERSONAL_PHONE]");
            phone.SendKeys("999" + namb);
            var pass = driver.FindElementByName("REGISTER[PASSWORD]");
            pass.SendKeys("123456");
            pass = driver.FindElementByName("REGISTER[CONFIRM_PASSWORD]");
            pass.SendKeys("123456");
            var check = driver.FindElementByXPath("/html/body/div[2]/div[3]/div/div[2]/form/div[8]/label");
            check.Click();
            var reg = driver.FindElementByXPath("/html/body/div[2]/div[3]/div/div[2]/form/input[3]");
            reg.Click();
        }
    }
}