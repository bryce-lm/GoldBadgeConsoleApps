using System;
using ClaimsRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClaimsTests
{
    [TestClass]
    public class Tests
    {
        private Repository _repo;
        private Claims _claims;
        private Claims _lateClaims;

        [TestInitialize]
        public void Initialize()
        {
            _repo = new Repository();
            _claims = new Claims(1, ClaimType.Car, "Car accident on 465.", 450.00m, DateTime.Parse("04/25/2018"), DateTime.Parse("04/27/2018"), true);
            _lateClaims = new Claims(1, ClaimType.Theft, "Stolen pancakes.", 4.00m, DateTime.Parse("04/27/2018"), DateTime.Parse("04/29/2018"), true);
        }

        [TestMethod]
        public void POCOsTest()
        {
            Claims newClaim = new Claims(2, ClaimType.Home, "House fire in kitchen.", 4000.00m, DateTime.Parse("04/11/2018"), DateTime.Parse("04/13/2018"), false);

            Assert.AreEqual(2, newClaim.ClaimID);
            Assert.AreEqual(ClaimType.Home, newClaim.ClaimType);
            Assert.AreEqual("House fire in kitchen.", newClaim.Description);
            Assert.AreEqual(DateTime.Parse("04/11/2018"), newClaim.IncidentDate);
            Assert.AreEqual(DateTime.Parse("04/13/2018"), newClaim.ClaimDate);
            Assert.AreEqual(false, newClaim.IsValid);
        }

        [TestMethod]
        public void AddClaimTest()
        {
            _repo.AddClaim(_claims);

            int expected = 1;
            int actual = _repo.GetList().Count;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void RemoveClaimTest()
        {
            Repository content = new Repository();

        }

        [TestMethod]
        public void ValidTestTrue()
        {
            _repo.AddClaim(_claims);

            bool expected = true;
            bool actual = _claims.IsValid;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidTestFalse()
        {
            _repo.AddClaim(_lateClaims);

            bool expected = false;
            bool actual = _lateClaims.IsValid;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetListTest()
        {
            _repo.GetList();
            Assert.IsNotNull(_repo);

        }
    }
}
