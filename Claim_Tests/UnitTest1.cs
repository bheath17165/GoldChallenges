using System;
using System.Collections.Generic;
using Claims;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Claims_Tests
{
    [TestClass]
    public class UnitTest1
    {
        private ClaimRepository _repo = new ClaimRepository();

        Queue<ProgramUI> queue1 = new Queue<ProgramUI>();

        [TestInitialize]
        public void SeedRepo()
        {
            Claim claim1 = new Claim(1, ClaimType.Car, "Car accident on 465.", 400.00, new DateTime(2018, 4, 25), new DateTime(2018, 4, 27));
            Claim claim2 = new Claim(2, ClaimType.Home, "House fire in kitchen.", 4000.00, new DateTime(2018, 4, 11), new DateTime(2018, 4, 12));
            Claim claim3 = new Claim(3, ClaimType.Theft, "Stolen pancakes.", 4.00, new DateTime(2018, 4, 27), new DateTime(2018, 6, 01));

            _repo.EnterNewClaim(claim1);
            _repo.EnterNewClaim(claim2);
            _repo.EnterNewClaim(claim3);

        }

        [TestMethod]
        public void ShowAllClaimsInQueue()
        {
            int expected = 3;
            int actual = _repo.SeeAllClaims().Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestTakeCareOfNextClaim()
        {
            _repo.TakeCareOfNextClaim();
        }

        [TestMethod]
        public void EnterANewClaim()
        {
            Claim claim3 = new Claim(3, ClaimType.Theft, "Stolen pancakes.", 4.00, new DateTime(2018, 4, 27), new DateTime(2018, 6, 01));
            bool doesItWork = _repo.EnterNewClaim(claim3);
            Assert.IsTrue(doesItWork);
        }
    }
}
