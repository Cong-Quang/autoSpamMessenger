using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Drawing;
using System.Threading;

namespace autoSpamMessenger
{
    internal class chrome
    {
        private IWebDriver driver;
        public void OpenChrome()
        {
            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;
            ChromeOptions op = new ChromeOptions();
            op.AddArguments("--disable-notifications");
            op.AddArgument("headless");
            driver = new ChromeDriver(driverService, op);
        }
        public void CloseChrom()
        {
            driver.Close();
        }
        public void login(string usename, string password)
        {
            driver.Navigate().GoToUrl("https://www.facebook.com/");
            driver.FindElement(By.Id("email")).SendKeys(usename);
            driver.FindElement(By.Id("pass")).SendKeys(password + Keys.Return);
        }
        public void openLink(string link)
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            driver.Navigate().GoToUrl(link);
        }
        public void Click(string NoiDung, int SoLuong)
        {
            Thread.Sleep(1000);
            Console.Write("Đang Chạy: ");
            for (int i = 1; i < SoLuong+1; i++)
            {
                string xpat= "//div[@data-lexical-editor]";
                driver.FindElement(By.XPath(xpat)).SendKeys($"{NoiDung} [{i}]"+ Keys.Return);
                Console.SetCursorPosition(12,2);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(i);
            }
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
