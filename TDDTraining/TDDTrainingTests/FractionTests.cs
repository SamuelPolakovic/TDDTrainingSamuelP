/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH, Inc., 2021. All rights reserved
   ------------------------------------------------------------------------------------------------- */
   
using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Text;
using NUnit.Framework;
using TDDTraining;

namespace TDDTrainingTests
{
    public class FractionTests
    {
        [TestCase(0, 0)]
        [TestCase(1, 0)]
        [TestCase(0, 1)]
        [TestCase(1, 1)]
        [TestCase(5, 3)]
        public void FractionAddSimpleNumbersTest(int firstNumber, int secondNumber)
        {
            var fractionOne = new Fraction(firstNumber);
            var fractionTwo = new Fraction(secondNumber);

            var expectedResult = new Fraction(firstNumber+ secondNumber);

            var sut = Fraction.Add(fractionOne, fractionTwo);

            Assert.AreEqual(expectedResult.ToString(), sut.ToString());
        }

        [TestCase(0)]
        [TestCase(156)]
        [TestCase(-15)]
        public void FractionConstructorSimpleNumbersTest(int firstNumber)
        {
            var sut = new Fraction(firstNumber);

            var expectedResult = firstNumber.ToString();

            Assert.AreEqual(expectedResult, sut.ToString());
        }

        [TestCase(2, 4)]
        [TestCase(6, 12)]
        public void FractionRepresentationTest(int firstNumber, int secondNumber)
        {
            var sut = new Fraction(firstNumber, secondNumber);

            var expectedResult = new Fraction(1,2);

            Assert.AreEqual(expectedResult.ToString(), sut.ToString());
        }

        [TestCase(12, 6)]
        public void FractionRepresentationDenominatorIsLowerTest(int firstNumber, int secondNumber)
        {
            var sut = new Fraction(firstNumber, secondNumber);

            var expectedResult = "2";

            Assert.AreEqual(expectedResult, sut.ToString());
        }



        [Test]
        public void FractionAddSameDenominatorTest()
        {
            var fractionOne = new Fraction(2,4);
            var fractionTwo = new Fraction(2,4);

            var expectedResult = new Fraction(1);

            var sut = Fraction.Add(fractionOne, fractionTwo);

            Assert.AreEqual(expectedResult.ToString(), sut.ToString());
        }

        [Test]
        public void FractionAddDifferentDenominatorTest()
        {
            var fractionOne = new Fraction(1, 3);
            var fractionTwo = new Fraction(1, 2);

            var expectedResult = new Fraction(5,6);

            var sut = Fraction.Add(fractionOne, fractionTwo);

            Assert.AreEqual(expectedResult.ToString(), sut.ToString());
        }

        [Test]
        public void FractionAddDifferentMinusDenominatorTest()
        {
            var fractionOne = new Fraction(-1, 3);
            var fractionTwo = new Fraction(1, 2);

            var expectedResult = new Fraction(1, 6);

            var sut = Fraction.Add(fractionOne, fractionTwo);

            Assert.AreEqual(expectedResult.ToString(), sut.ToString());
        }

        [Test]
        public void FractionAddDifferentDenominatorMinusTest()
        {
            var fractionOne = new Fraction(1, 3);
            var fractionTwo = new Fraction(-1, 2);
            var expectedResult = new Fraction(-1, 6);

            var sut = Fraction.Add(fractionOne, fractionTwo);

            Assert.AreEqual(expectedResult.FractionValues, sut.FractionValues);
        }

        [Test]
        public void FractionCorrectNegativeRepresentation()
        {
            var expectedResult = "-2";

            var sut = new Fraction(-6, 3);

            Assert.AreEqual(expectedResult, sut.ToString());
        }

        [Test]
        public void FractionCorrectNegativeDenominatorRepresentation()
        {
            var expectedResult = new Fraction(-12, 6);

            var sut = new Fraction(6, -3);

            Assert.AreEqual(expectedResult, sut);
        }

        [Test]
        public void FractionComplicatedAddRepresentation()
        {
            var fractionOne = new Fraction(372, 654);
            var fractionTwo = new Fraction(215, 9);
            var expectedResult = new Fraction(23993, 981);

            var sut = Fraction.Add(fractionOne, fractionTwo);

            Assert.AreEqual(expectedResult.FractionValues, sut.FractionValues);
        }

        [Test]
        public void FractionComplicatedAddRepresentationEquals()
        {
            var fractionOne = new Fraction(372, 654);
            var fractionTwo = new Fraction(215, 9);
            var expectedResult = new Fraction(23993, 981);

            var sut = Fraction.Add(fractionOne, fractionTwo);

            Assert.AreEqual(expectedResult, sut);
        }

        [Test]
        public void FractionReadFromString()
        {
            var expected = new Fraction(2, 4);
            
            var sut = new Fraction("2/4");

            Assert.AreEqual(expected,sut);
        }

        [Test]
        public void FractionAddFromWithoutNumeratorString()
        {
            var fractionOne = new Fraction("2/4");
            var fractionTwo = new Fraction("-2/4");
            var expectedResult = new Fraction("/1");

            var sut = Fraction.Add(fractionOne, fractionTwo);

            Assert.AreEqual(expectedResult, sut);
        }

        [Test]
        public void FractionAddFromString()
        {
            var fractionOne = new Fraction("3/5");
            var fractionTwo = new Fraction("-2/4");
            var expectedResult = new Fraction("2/20");

            var sut = Fraction.Add(fractionOne, fractionTwo);

            Assert.AreEqual(expectedResult, sut);
        }
    }
}
