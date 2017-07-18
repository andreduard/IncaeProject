using Incae;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IncaeTest
{
    [TestClass]
    public class IncaeTest
    {
        [TestInitialize]
        public void Init()
        {
            Driver.Initialize();
        }

        [TestMethod]
        public void GoToThePageAndLogin()
        {
            Elements.GoToUrl("https://incae-test.herokuapp.com/");
        }

        [TestMethod]
        public void CreateNewGame()
        {
            GoToThePageAndLogin();

            const string team = "Test039303";

            //Parameters are Name of the Team and the Number of players
            Games.CreateNewGame(team , 6);

            Driver.WaitForThePage(5000);
            
            Elements.Encontrar();
            
            Assert.AreEqual("Bienvenidos \""+team+"\"", Games.EqualText);
        }

        [TestMethod]
        public void GoToSaveGame()
        {
            GoToThePageAndLogin();

            const string teamName ="test";

            Games.GoToSaveGame(teamName);

            Assert.IsTrue(Games.TheresNoGame(), "No hay juego creado");

            Assert.AreEqual("Bienvenidos \"{}\"", Games.EqualText);

            //Assert.AreEqual("Bienvenidos \""+teamName+"\"", Games.EqualText);
        }

        [TestMethod]
        public void SelectDecision()
        {
            GoToSaveGame();
            
            Decision.SelectDecision();

            Assert.IsTrue(Decision.WeekBudgetDown(),"Se redujeron las semanas y el presupuesto equivocado.");

        }
    }
}

