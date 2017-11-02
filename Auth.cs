using System;
using OpenQA.Selenium.Chrome;

namespace Teaco
{
    public class Auth
    {
        TimeSpan timeout = new TimeSpan(00, 00, 05);
        public ChromeDriver driver { set; get; }

        public Auth(ChromeDriver driver)
        {
            this.driver = driver;
        }

        public void Action()
        {
            var mail = driver.FindElementByName("USER_LOGIN");
            mail.SendKeys("xunuyohawe@p33.org");
            var pass = driver.FindElementByName("USER_PASSWORD");
            pass.SendKeys("123456");
            var Login = driver.FindElementByName("Login");
            Login.Click();
        }
    }
}