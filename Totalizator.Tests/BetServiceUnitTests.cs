using System;
using System.Data.Entity;
using Moq;
using NUnit.Framework;
using Totalizator.Models.DbModel;
using Totalizator.Services;
using System.Collections.Generic;
using System.Linq;
using Totalizator.Util.Exeptions;

namespace Totalizator.Tests
{
    [TestFixture]
    public class BetServiceUnitTests
    {

        static TestContext context;
        static BetService betService;
        static UserService userService;
        static TeamService teamService;
        static EventService eventService;

        [SetUp]
        protected void Init()
        {
            context = new TestContext();
            betService = new BetService(context);
            userService = new UserService(context);
            teamService = new TeamService(context);
            eventService = new EventService(context);

            AddUser();
            AddTeam();
            AddEvent();
        }


        private void AddUser()
        {
            User user = new User();
            user.Id = 1;
            user.UserName = "Herman";
            user.Email = "herman@gmail.com";
            user.Password = "qwerty";

            userService.AddUser(user);
        }

        private void AddTeam()
        {
            Team team = new Team();
            team.Id = 1;
            team.Name = "Komanda";
            team.Description = "desc";

            teamService.AddTeam(team);
        }

        private void AddEvent()
        {
            Event evnt = new Event();
            DateTime date = DateTime.Now;
            evnt.Id = 1;
            evnt.TypeId = 1;
            evnt.Date = date;
            evnt.Name = "First Event";
            evnt.Description = "desc";
            evnt.TeamFirstId = 1;
            evnt.TeamSecondId = 2;
            evnt.WinnerId = null;
            evnt.TeamFirstCoefficient = 1;
            evnt.TeamSecondCoefficient = 1;
            evnt.TeamFirstPoints = 0;
            evnt.TeamSecondPoints = 0;
            evnt.CreatorId = 1;
            evnt.CreateDate = date;
            evnt.EditorId = null;
            evnt.EditDate = null;
            evnt.Status = 0;

            eventService.AddEvent(evnt);
        }

        [Test]
        public void Test_Add_Bet()
        {
            Bet bet = new Bet();
            bet.Id = 1;
            bet.EventId = 1;
            bet.UserId = 1;
            bet.Amount = 1;
            bet.TeamId = 1;

            betService.AddBet(bet);

            Assert.AreEqual(bet, context.Bets.Single());
        }

        [Test]
        public void Test_Delete_Bet()
        {
            int idOfDeletedbet = 1;
            betService.DeleteBet(idOfDeletedbet);
            Assert.IsEmpty(context.Bets.Where(p => p.Id == idOfDeletedbet));
        }

        [Test]
        public void Test_Delete_Bet_With_Zero_Id()
        {
            var id = 0;
            var ex = Assert.Throws<WrongIdExeption>(() => betService.DeleteBet(id));
            Assert.That(ex.Message, Is.EqualTo("Id of Bet can't be 0 of lower"));
        }

        [Test]
        public void Test_Delete_Bet_Wit_Negative_Id()
        {
            Random random = new Random();
            var id = random.Next(Int32.MinValue, -1);
            var ex = Assert.Throws<WrongIdExeption>(() => betService.DeleteBet(id));
            Assert.That(ex.Message, Is.EqualTo("Id of Bet can't be 0 of lower"));
        }

        [Test]
        public void Test_Count_Of_Bets__Without_Add()
        {
            var userId = 1;
            var result = betService.GetCountOfBets(userId);
            Assert.Zero(result);
        }

        [Test]
        public void Test_Count_Of_Bets_With_Add()
        {
            var userId = 1;

            Bet bet = new Bet();
            bet.EventId = 1;
            bet.UserId = 1;
            bet.Amount = 1;
            bet.TeamId = 1;

            betService.AddBet(bet);
            var result = betService.GetCountOfBets(userId);

            Assert.AreEqual(1, result);
        }

        [Test]
        public void Test_List_Bet_With_Zero_Page_Nubmer()
        {
            var pageNumber = 0;
            var userId = 1;

            var ex = Assert.Throws<WrongPageNumberExeption>(() => betService.ListBet(pageNumber, userId));
            Assert.That(ex.Message, Is.EqualTo("Page number can't be 0 or lower"));
        }

        [Test]
        public void Test_List_Bet_With_Negative_Page_Nubmer()
        {
            Random random = new Random();
            var pageNumber = random.Next(Int32.MinValue, -1);

            var userId = 1;

            var ex = Assert.Throws<WrongPageNumberExeption>(() => betService.ListBet(pageNumber, userId));
            Assert.That(ex.Message, Is.EqualTo("Page number can't be 0 or lower"));
        }

        [Test]
        public void Test_List_Bet_With_Zero_User_Id()
        {
            var userId = 0;
            var pageNumber = 1;

            var ex = Assert.Throws<WrongIdExeption>(() => betService.ListBet(pageNumber, userId));
            Assert.That(ex.Message, Is.EqualTo("User Id can't be 0 or lower"));
        }

        [Test]
        public void Test_List_Bet_With_Negative_User_Id()
        {
            Random random = new Random();
            var userId = random.Next(Int32.MinValue, -1);

            var pageNumber = 1;

            var ex = Assert.Throws<WrongIdExeption>(() => betService.ListBet(pageNumber, userId));
            Assert.That(ex.Message, Is.EqualTo("User Id can't be 0 or lower"));
        }
    }
}