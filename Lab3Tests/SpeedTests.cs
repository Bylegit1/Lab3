using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

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
            Assert.AreEqual("25 мах", speed.Verbose());
        }

        [TestMethod()]
        public void SummationTest()
        {
            var speed = new Speed(5, MeasureType.mps);
            speed = speed + 2.2;
            Assert.AreEqual("7,2 м/с", speed.Verbose());

            speed = 3.5 + new Speed(10, MeasureType.mps);
            Assert.AreEqual("13,5 м/с", speed.Verbose());
        }

        [TestMethod()]
        public void DifferenceTest()
        {
            var speed = new Speed(5, MeasureType.kph);
            speed = speed - 3;
            Assert.AreEqual("2 км/ч", speed.Verbose());

            speed = 10 - new Speed(3, MeasureType.mps);
            Assert.AreEqual("7 м/с", speed.Verbose());
        }

        [TestMethod()]
        public void ProductTest()
        {
            var speed = new Speed(5, MeasureType.max);
            speed = speed * 2;
            Assert.AreEqual("10 мах", speed.Verbose());

            speed = 3 * new Speed(4, MeasureType.kph);
            Assert.AreEqual("12 км/ч", speed.Verbose());
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
            Assert.AreEqual("6,124419236106921 мах", speed.To(MeasureType.max).Verbose());

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
            Assert.AreEqual("29,4384 м/с", (mps + kn).Verbose());
            Assert.AreEqual("3324,6 м/с", (mps + max).Verbose());
            Assert.AreEqual("76,99407407407408 км/ч", (kph + kn).Verbose());
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

            speed1 = new Speed(50, MeasureType.kph);
            speed2 = new Speed(20, MeasureType.mps);
            Assert.IsTrue(speed1 > speed2, "50 км/ч > 20 м/с");

            speed1 = new Speed(100, MeasureType.kph);
            speed2 = new Speed(30, MeasureType.mps);
            Assert.IsTrue(speed1 != speed2, "100 км/ч != 30 м/с");

            speed1 = new Speed(1, MeasureType.max);
            speed2 = new Speed(300, MeasureType.mps);
            Assert.IsTrue(speed1 > speed2, "1 мах > 300 м/с");

            speed1 = new Speed(100, MeasureType.kn);
            speed2 = new Speed(50, MeasureType.mps);
            Assert.IsTrue(speed1 > speed2, "100 узлов > 50 м/с");
        }

        [TestMethod()]
        public void DifferenceSpeedsTest()
        {
            var speed1 = new Speed(30, MeasureType.mps);
            var speed2 = new Speed(36, MeasureType.kph); 
            var result = speed1 - speed2;
            Assert.AreEqual("-99,6 м/с", result.Verbose());

            speed1 = new Speed(100, MeasureType.kph);
            speed2 = new Speed(10, MeasureType.mps); 
            result = speed1 - speed2;
            Assert.AreEqual("62,96296296296296 км/ч", result.Verbose());

            speed1 = new Speed(20, MeasureType.kn);
            speed2 = new Speed(5, MeasureType.mps);
            result = speed1 - speed2;
            Assert.AreEqual("10,272373540856032 уз", result.Verbose());
        }

        [TestMethod()]
        public void ConvertToDifferentTypesTest()
        {
            var speed = new Speed(100, MeasureType.kph);
            Assert.AreEqual("360 м/с", speed.To(MeasureType.mps).Verbose());
            Assert.AreEqual("700,3891050583658 уз", speed.To(MeasureType.kn).Verbose());
            Assert.AreEqual("1,0861039039401437 мах", speed.To(MeasureType.max).Verbose());

            speed = new Speed(50, MeasureType.kn);
            Assert.AreEqual("97,19200000000001 м/с", speed.To(MeasureType.mps).Verbose());
            Assert.AreEqual("359,97037037037035 км/ч", speed.To(MeasureType.kph).Verbose());

            speed = new Speed(2, MeasureType.max);
            Assert.AreEqual("662,92 м/с", speed.To(MeasureType.mps).Verbose());
            Assert.AreEqual("2455,259259259259 км/ч", speed.To(MeasureType.kph).Verbose());
        }

        [TestMethod()]
        public void ProductSpeed()
        {
            var speed1 = new Speed(2, MeasureType.mps);
            var speed2 = new Speed(3, MeasureType.mps);
            var result = speed1 * speed2;
            Assert.AreEqual("6 м/с", result.To(MeasureType.mps).Verbose());

            speed1 = new Speed(2, MeasureType.kph);
            speed2 = new Speed(3, MeasureType.max);
            result = speed1 * speed2;
            Assert.AreEqual("98210,37037037035 км/ч", result.To(MeasureType.kph).Verbose());

            speed1 = new Speed(1, MeasureType.kn);
            speed2 = new Speed(1, MeasureType.mps);
            result = speed1 * speed2;
            Assert.AreEqual("7,357567866281094 уз", result.To(MeasureType.kn).Verbose());
        }

    }
}