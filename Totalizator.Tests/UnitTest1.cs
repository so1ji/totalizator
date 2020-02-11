using System;
using System.Data.Entity;
using Moq;
using NUnit.Framework;
using Totalizator.Models.DbModel;
using Totalizator.Services;
using System.Collections.Generic;
using System.Linq;


namespace Totalizator.Tests
{
    [TestFixture]
    public class UnitTest1
    {

        [Test]
        public void Test_Add_Bet()
        {
            Bet bet = new Bet();
            bet.EventId = 5;
            bet.UserId = 1;
            bet.Amount = 1;
            bet.TeamId = 1;


            var list = new List<Bet>();
            var queryable = list.AsQueryable();
            var mockDbSet = new Mock<DbSet<Bet>>();
            mockDbSet.As<IQueryable<Bet>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockDbSet.As<IQueryable<Bet>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockDbSet.As<IQueryable<Bet>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockDbSet.As<IQueryable<Bet>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());


            var dbContext = new Mock<totalizatorEntities>();
            dbContext.Setup(c => c.Bets).Returns(mockDbSet.Object);

            BetService betService = new BetService(dbContext.Object);

            betService.AddBet(bet);

            mockDbSet.Verify(m => m.Add(It.IsAny<Bet>()), Times.Once);
            dbContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [Test]
        public void Test_Delete_Bet()
        {
            int idOfDeletedbet = 1;

            var list = new List<Bet>();
            var queryable = list.AsQueryable();
            var mockDbSet = new Mock<DbSet<Bet>>();
            mockDbSet.As<IQueryable<Bet>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockDbSet.As<IQueryable<Bet>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockDbSet.As<IQueryable<Bet>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockDbSet.As<IQueryable<Bet>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());


            var dbContext = new Mock<totalizatorEntities>();
            dbContext.Setup(c => c.Bets).Returns(mockDbSet.Object);

            BetService betService = new BetService(dbContext.Object);
            betService.DeleteBet(idOfDeletedbet);

            mockDbSet.Verify(m => m.Remove(It.IsAny<Bet>()), Times.Once);
            dbContext.Verify(m => m.SaveChanges(), Times.Once);

        }

        [Test]
        public void Test_Count_Of_Bets_Without_Add()
        {
            int userId = 1;

            var list = new List<Bet>();
            var queryable = list.AsQueryable();
            var mockDbSet = new Mock<DbSet<Bet>>();
            mockDbSet.As<IQueryable<Bet>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockDbSet.As<IQueryable<Bet>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockDbSet.As<IQueryable<Bet>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockDbSet.As<IQueryable<Bet>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());


            var dbContext = new Mock<totalizatorEntities>();
            dbContext.Setup(c => c.Bets).Returns(mockDbSet.Object);

            BetService betService = new BetService(dbContext.Object);
            var count = betService.GetCountOfBets(userId);

            Assert.AreEqual(0, count);
        }

        [Test]
        public void Test_Count_Of_Bets_With_Add()
        {
            int userId = 1;

            var list = new List<Bet>();
            var queryable = list.AsQueryable();
            var mockDbSet = new Mock<DbSet<Bet>>();
            mockDbSet.As<IQueryable<Bet>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockDbSet.As<IQueryable<Bet>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockDbSet.As<IQueryable<Bet>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockDbSet.As<IQueryable<Bet>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());

            Bet bet = new Bet();
            bet.EventId = 5;
            bet.UserId = 1;
            bet.Amount = 1;
            bet.TeamId = 1;


            var dbContext = new Mock<totalizatorEntities>();
            dbContext.Setup(c => c.Bets).Returns(mockDbSet.Object);

            BetService betService = new BetService(dbContext.Object);
            betService.AddBet(bet);
            var count = betService.GetCountOfBets(userId);

            Assert.AreEqual(1, count);
        }

    }
}