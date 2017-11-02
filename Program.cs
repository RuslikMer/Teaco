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
    class Program
    {
        public class TeacoOrder
        {
            public string OrderId { get; set; }
            public string UrlAdress { get; set; }
            public string ProdName { get; set; }
            public double ProductValue { get; set; }
            public double DeliveryValue { get; set; }
            public double OrderValue { get; set; }
            public double AdminOrderValue { get; set; }
            public double Sap { get; set; }
            public double Uniteller { get; set; }
            public double nProductValue { get; set; }
            public double nDeliveryValue { get; set; }
            public double nOrderValue { get; set; }
            public double nAdminOrderValue { get; set; }
            public double nSap { get; set; }
            public double nUniteller { get; set; }
            public RemoteWebDriver Driver { set; get; }
            Object WrapText { get; set; }

            static void Main(string[] args)
            {
                using (var driver = new ChromeDriver())
                {
                    TimeSpan timeout = new TimeSpan(00, 00, 05);
                    WaitAndFind find = new WaitAndFind(driver);
                   
                    driver.Navigate().GoToUrl("http://teaco.ru/catalog/chay/tsvety-i-travy/myatnyy-nektar-100gr/");
                    driver.Manage().Window.Maximize();

                    GetOrder order = new GetOrder(driver);
                    order.Action();

                    NewUser user = new NewUser(driver);
                    user.Action();
                    //Auth auth = new Auth(driver);
                    //auth.Action();

                    order.SelfDelivery();
                    order.CheckOut();

                    UserData userData = new UserData(driver);
                    userData.Action();

                    Admin admin = new Admin(driver);
                    admin.Revocation();

                    Table table = new Table(driver, userData.OrdNum, userData.ProductName, order.Pr, order.OrCheck, admin.AdmOrd, admin.label, userData.prFromData);
                    table.NewTable();

                    //SendMail mail = new SendMail();
                    //mail.Mail();

                }
            }
        }
    }
}