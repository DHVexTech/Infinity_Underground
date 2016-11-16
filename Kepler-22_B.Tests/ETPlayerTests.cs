﻿using NUnit.Framework;
using System;
using Kepler_22_B.API.Entities;



namespace Kepler_22_B.Tests
{
    [TestFixture]
    class ETPlayerTests
    {
        /// <summary>
        /// Tests if the player can go on the left.
        /// </summary>
        [Test]
        public void TestIfThePlayerCanGoOnTheLeft()
        {
            ETPlayer sut = new ETPlayer();

            sut.Deplacement(0);

            Assert.That(sut.PositionX, Is.EqualTo(-1));
        }

        /// <summary>
        /// Tests if the player can go down.
        /// </summary>
        [Test]
        public void TestIfThePlayerCanGoDown()
        {
            ETPlayer sut = new ETPlayer();

            sut.Deplacement(1);

            Assert.That(sut.PositionY, Is.EqualTo(1));
        }

        /// <summary>
        /// Tests if the player can on the right.
        /// </summary>
        [Test]
        public void TestIfThePlayerCanOnTheRight()
        {
            ETPlayer sut = new ETPlayer();

            sut.Deplacement(2);

            Assert.That(sut.PositionX, Is.EqualTo(1));
        }

        /// <summary>
        /// Tests if the player can go top.
        /// </summary>
        [Test]
        public void TestIfThePlayerCanGoTop()
        {
            ETPlayer sut = new ETPlayer();

            sut.Deplacement(3);

            Assert.That(sut.PositionY, Is.EqualTo(-1));
        }

        /// <summary>
        /// Inserts the position in constructor.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        [TestCase(1, 10)]
        [TestCase(50, 12)]
        [TestCase(500, 2)]
        public void InsertPositionInConstructor(int x, int y)
        {
            ETPlayer sut = new ETPlayer(x, y);

            Assert.That(sut.PositionX, Is.EqualTo(x));
            Assert.That(sut.PositionY, Is.EqualTo(y));

        }



        /// <summary>
        /// Tests the nunit.
        /// </summary>
        [Test]
        public void TestNunit()
        {
            Assert.That(true);
        }
    }
}