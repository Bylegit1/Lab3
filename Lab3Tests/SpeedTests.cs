using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Tests
{
    [TestClass()]
    public class SpeedTests
    {
        [TestMethod()]
        public void VerboseTest()
        {
            var speed = new Speed(25, MeasureType.mps);
            Assert.AreEqual("25 м/с", speed.Verbose());

            speed = new Speed(1, MeasureType.kph);
            Assert.AreEqual("1 км/ч", speed.Verbose());

            speed = new Speed(2, MeasureType.kn);
            Assert.AreEqual("2 уз", speed.Verbose());

            speed = new Speed(25, MeasureType.max);
            Assert.AreEqual("25 М", speed.Verbose());
        }

        [TestMethod()]
        public void SummationTest()
        {
            var speed = new Speed(5, MeasureType.mps);
            speed = speed + 2.2;
            Assert.AreEqual("7,2 м/с", speed.Verbose());
        }

        [TestMethod()]
        public void DifferenceTest()
        {
            var speed = new Speed(5, MeasureType.kph);
            speed = speed - 3;
            Assert.AreEqual("2 км/ч", speed.Verbose());
        }

        [TestMethod()]
        public void ProductTest()
        {
            var speed = new Speed(5, MeasureType.max);
            speed = speed * 2;
            Assert.AreEqual("10 М", speed.Verbose());
        }

        [TestMethod()]
        public void MeterToAnyTest()
        {
            Speed speed;
            speed = new Speed(108, MeasureType.mps);
            Assert.AreEqual("30 км/ч", speed.To(MeasureType.kph).Verbose());

            speed = new Speed(2003, MeasureType.mps);
            Assert.AreEqual("1030,434603671084 уз", speed.To(MeasureType.kn).Verbose());

            speed = new Speed(2030, MeasureType.mps);
            Assert.AreEqual("6,124419236106921 М", speed.To(MeasureType.max).Verbose());

            speed = new Speed(1, MeasureType.kph);
            Assert.AreEqual("3,6 м/с", speed.To(MeasureType.mps).Verbose());

            speed = new Speed(2, MeasureType.kn);
            Assert.AreEqual("3,88768 м/с", speed.To(MeasureType.mps).Verbose());

            speed = new Speed(3, MeasureType.max);
            Assert.AreEqual("994,3799999999999 м/с", speed.To(MeasureType.mps).Verbose());
        }
       
        [TestMethod()]
        public void AddMpsKphKnMaxTest()
        {
            var mps = new Speed(10, MeasureType.mps);
            var kph = new Speed(5, MeasureType.kph);
            var kn = new Speed(10, MeasureType.kn);
            var max = new Speed(10, MeasureType.max);

            Assert.AreEqual("28 м/с", (mps + kph).Verbose());
        }

        [TestMethod()]
        public void ComparisonTest()
        {
            var speed1 = new Speed(10, MeasureType.kph);
            var speed2 = new Speed(36, MeasureType.mps);
            Assert.IsTrue(speed1 == speed2, speed1.To(MeasureType.mps).Verbose());

            speed1 = new Speed(2, MeasureType.max);
            speed2 = new Speed(1, MeasureType.kn);
            Assert.IsTrue(speed1 > speed2, speed2.To(MeasureType.max).Verbose());
        }

    }
}