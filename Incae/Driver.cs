using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Incae
{
    public class Driver
    {
        public static IWebDriver Instance { set; get; }

        public static void Initialize()
        {
            Instance = new ChromeDriver();

            Instance.Manage().Window.Maximize();
        }


        public static void WaitForThePage(int timeToWait)
        {
            Thread.Sleep(timeToWait);
        }

        public static void Close()
        {
            //Driver.Instance.Close();
        }

    }


}