using System;
using System.Threading;
using OpenQA.Selenium;

namespace Incae
{
    public class Elements
    {
        public static void Delay(int miliSeconds)
        {
            Thread.Sleep(miliSeconds);
        }

        public static void GoToUrl(string url)
        {
            Driver.Instance.Navigate().GoToUrl(url);
        }

        public static string returnDriverURL()
        {
            return Driver.Instance.Url;
        }

        public static void ClickElementById(string id)
        {
            Driver.Instance.FindElement(By.Id(id)).Click();
        }

        public static void ClickElementByXPath(string xPath)
        {
            Driver.Instance.FindElement(By.XPath(xPath)).Click();
        }

        public static void ClickElementByLinkText(string linkText)
        {
            Driver.Instance.FindElement(By.LinkText(linkText)).Click();
        }

        public static void ClickElementByCssSelector(string cssSelector)
        {
            Driver.Instance.FindElement(By.CssSelector(cssSelector)).Click();
        }

        public static void SendKeysById(string id, string text)
        {
            IWebElement element = Driver.Instance.FindElement(By.Id(id));
            element.Clear();
            element.SendKeys(text);
        }

        public static void SendKeysByXPath(string xPath, string text)
        {
            IWebElement element = Driver.Instance.FindElement(By.XPath(xPath));
            element.Clear();
            element.SendKeys(text);
        }

        public static void SendKeysByCssSelector(string cssSelector, string text)
        {
            IWebElement element = Driver.Instance.FindElement(By.CssSelector(cssSelector));
            element.Clear();
            element.SendKeys(text);
        }


        public static void SendKeysByName(string name, string text)
        {
            IWebElement element = Driver.Instance.FindElement(By.Name(name));
            element.SendKeys(text);
        }

        public static IWebElement ReturnElementByXPath(string xPath)
        {
            IWebElement element = Driver.Instance.FindElement(By.XPath(xPath));
            return element;
        }

        public static dynamic ReturnElementsByXPath(string xPath)
        {
            var element = Driver.Instance.FindElements(By.XPath(xPath));
            return element;
        }

        public static bool ElementDisplayedById(string id)
        {
            if (Driver.Instance.FindElement(By.Id(id)).Displayed)
                return true;
            return false;
        }

        public static bool ElementDisplayedByXPath(string xPath)
        {
            if (Driver.Instance.FindElement(By.XPath(xPath)).Displayed)
                return true;
            return false;
        }

        public static void Encontrar()
       {
           var c = Driver.Instance.FindElements(By.TagName("h1"));
           int d = 0;
           while (d < c.Count)
           {
               Console.WriteLine(d);
               Console.WriteLine(d +"  "+ c[d].Text);
               d++;
           }
       }
    }
}
