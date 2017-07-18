using System;
using OpenQA.Selenium;

namespace Incae
{
    public class Games
    {
        public static void CreateNewGame(string nombreEquipo, int cantJugadores)
        {
            int cant = 0;

            Elements.ClickElementByXPath("//button[@href='/game-create']");

            Elements.SendKeysByXPath("//input[@type='text']", nombreEquipo);

            while (cant < cantJugadores)
            {
                Elements.SendKeysByXPath("(//input[@type='text'])[2]", "Andres");

                Elements.ClickElementByCssSelector("button.btn.btn-secondary");

                Console.WriteLine(cant);

                cant++;
            }

            Elements.ClickElementByXPath("//div[@id='game-create']/div/div/div[2]/div[2]/button");
        }

        /*public static void Encontrar()
       {
           var c = Driver.Instance.FindElements(By.TagName("h1"));
           int d = 0;
           while (d < c.Count)
           {
               Console.WriteLine(d);
               Console.WriteLine(c[d].Text);
               d++;
           }
       }*/

        public static string EqualText
        {
            get
            {
                var findTag = Driver.Instance.FindElements(By.TagName("h1"));
                Console.WriteLine(findTag.Count);
                Console.WriteLine(findTag[0].Text);
                return findTag[0].Text;
            }
        }

        public static void GoToSaveGame(String nameOfTheGame)
        {
            var cont = 1;
            var validate = false;

            //Button to go to save games
            Elements.ClickElementByXPath("//button[@href='/saved-games']");

            Driver.WaitForThePage(5000);

            Console.WriteLine();

            while (validate == false)
            {
                try
                {
                    string name =Driver.Instance.FindElement(By.XPath("//div[@id='saved-games']/div/div/div/table/tbody/tr[" + cont.ToString() + "]/td")).Text;

                    if (nameOfTheGame == name)
                    {
                        Elements.ClickElementByXPath("//div[@id='saved-games']/div/div/div/table/tbody/tr[" +
                                                     cont.ToString() + "]/td");
                        validate = true;
                    }
                }
                catch (Exception)
                {
                    validate = true;
                }

                cont++;
            }

            //Botn aceptar
            Elements.ClickElementByXPath("//div[@id='saved-games']/div/div/div/div/button");
        }


        public static bool TheresNoGame()
        {
            if ("https://incae-test.herokuapp.com/saved-games" == Elements.returnDriverURL())
            {
                return false;
            }
            return true;
        }


    }
}
