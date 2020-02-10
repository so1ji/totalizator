using System;
using System.Data.Entity;
using Moq;
using NUnit;
using NUnit.Framework;
using Totalizator.Models.DbModel;
using Totalizator.Services;

namespace Totalizator.Tests
{
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            Bet expect = new Bet();
            expect.Id = 10;
            expect.EventId = 5;
            expect.UserId = 1;
            expect.Amount = 1;
            expect.TeamId = 1;

            var dbContext = new Mock<totalizatorEntities>();
            BetService betService = new BetService(dbContext.Object);

            var result = dbContext.Object.Bets.Find(10);

            Assert.AreEqual(expect, result);
        }
    }
}
