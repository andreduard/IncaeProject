using System;
using OpenQA.Selenium;

namespace Incae
{
    public class Decision
    {
        static readonly double[] WeeksArray = { 4, 1, 3, 1.5, 1, 5, 1, 10, 2, 1, 2, 2, 2, 2, 4, 2, 3, 2, 1, 30, 1, 2, 1, 1, 1, 1, 20, 1, 1, 2, 20, 30, 2 };

        static readonly double[] PriceArray = { 5000, 500, 20000, 3000, 500, 50000, 3000, 50000, 30000, 10000, 
                                 25000, 15000, 3000, 15000, 30000, 15000, 10000, 30000, 5000, 
                                 500000, 1000, 20000, 10000, 500, 500, 500, 200000, 200000, 
                                 5000, 500, 10000, 200000, 400000 };

        private static string budget;
        private static string weeks;
        private static string approve;

        private static string budgetLeft;
        private static string weeksLeft;

        /*public static void Encontrar()
        {
            var c = Driver.Instance.FindElements(By.TagName("p"));
            int d = 0;
            while (d < c.Count)
            {
                Console.WriteLine(d);
                string weeks = c[0].Text;
                string budget = c[3].Text;
                string approve = c[6].Text;
                Console.WriteLine(weeks.Remove(0,19));
                Console.WriteLine(budget.Remove(0, 14));
                Console.WriteLine(approve.Remove(0, 12));
                Console.WriteLine(c[d].Text);
                d++;
            }
        }*/

        public static void  GetWeekAndBudgetLeft()
        {
            var c = Driver.Instance.FindElements(By.TagName("p"));

            weeks = c[0].Text;
            budget = c[3].Text;
            approve = c[6].Text;

            //remove all that the values have in front
            weeks = weeks.Remove(0, 19);
            budget = budget.Remove(0, 14);
            approve = approve.Remove(0, 12);

            //remove ")" values have at the end
            weeks = weeks.Trim(')');
            budget = budget.Trim(')');
            approve = approve.Trim(')');

            Console.WriteLine("Semanas  "+weeks);
            Console.WriteLine("Presup   "+budget);
            Console.WriteLine("Aprobacion   "+approve);

        }


        public static void SelectDecision()
        {
            Driver.WaitForThePage(5000);

            Elements.ClickElementByXPath("//button[@type='button']");

            Driver.WaitForThePage(5000);
            
            Elements.ClickElementByCssSelector("button.btn.btn-outline-primary");

            Driver.WaitForThePage(5000);


            //gets the value of the weeks,budget before a decision is take.
            GetWeekAndBudgetLeft();

            Elements.ClickElementByLinkText("Toma de decisión");

            Driver.WaitForThePage(5000);

            GetWeekAndBudgetLeft();

            //Click to the decision
            Elements.ClickElementByXPath("(//tr[@id='tactic-{tactic.id}']/td[5]/button)[3]");

            //To convert weeks that is String to a Double
            double a;

            //To convert budget that is String to a Double
            double b;

            //converts weeks to a Double
            double.TryParse(weeks,out a);

            //converts budget to a Double
            double.TryParse(budget, out b);

            //subtract the value(weeks) of the decision from the remaining weeks
            weeksLeft = (a - WeeksArray[2]).ToString();

            //subtract the value(price) of the decision from the remaining budget
            budgetLeft = (b - PriceArray[2]).ToString();

            Console.WriteLine("Resta  "+weeksLeft);

            Console.WriteLine("Resta  " + budgetLeft);

        }

        //To know if budget and weeks went down
        public static Boolean WeekBudgetDown()
        {
            Driver.WaitForThePage(5000);

            GetWeekAndBudgetLeft();

            if (weeks == weeksLeft && budget == budgetLeft)
            {
                return true;
            }
            return false;
        }

    }
}
