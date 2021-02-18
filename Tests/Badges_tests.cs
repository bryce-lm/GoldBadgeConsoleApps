using System;
using System.Collections.Generic;
using BadgesRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BadgesTests
{
    [TestClass]
    public class Tests
    {
        private Repository _repo;
        private Badges _badges;

        [TestInitialize]
        public void Initialize()
        {
            List<string> list = new List<string>();
            list.Add("A7");

            _repo = new Repository();
            _badges = new Badges(12345, list);
        }
    }
}