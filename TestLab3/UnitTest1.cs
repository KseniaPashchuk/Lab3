using NUnit.Framework;
using System.Collections.Generic;
using Lab3.model;
using Lab3.action;
using System.Linq;
using System;

namespace Tests
{
    public class Tests
    {
        private List<BoolVector> boolVectors;

        [SetUp]
        public void Setup()
        {
            boolVectors = new List<BoolVector>();
            boolVectors.Add(new BoolVector(new List<int>() { 0, 1, 1, 0 }));
            boolVectors.Add(new BoolVector(new List<int>() { 0, 0, 1, 0 }));
            boolVectors.Add(new BoolVector(new List<int>() { 1, 1, 1, 0 }));
            boolVectors.Add(new BoolVector(new List<int>() { 0, 1, 0, 0 }));
            boolVectors.Add(new BoolVector(new List<int>() { 1, 1, 1, 0 }));
        }

        [Test]
         public void test_conjunction()
        {
            BoolVector expectedResult = new BoolVector(new List<int>() { 0, 0, 0, 0 });
            BoolVector actualResult = BoolVectorAction.conjunction(boolVectors);
            Assert.IsTrue(expectedResult.Components.SequenceEqual(actualResult.Components));
        }

        [Test]
        public void test_conjunctionNegative()
        {
            try
            {
                boolVectors.Add(new BoolVector(new List<int>() { 0, 1, 1, 0, 1 }));
                BoolVector actualResult = BoolVectorAction.conjunction(boolVectors);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("All bool vectors must be the same size", ex.Message);
            }
            catch (Exception ex)
            {
                // not the right kind of exception
                Assert.Fail();
            }
        }

        [Test]
        public void test_disjunction()
        {
            BoolVector expectedResult = new BoolVector(new List<int>() { 1, 1, 1, 0 });
            BoolVector actualResult = BoolVectorAction.disjunction(boolVectors);
            Assert.IsTrue(expectedResult.Components.SequenceEqual(actualResult.Components));
        }

        [Test]
        public void test_disjunctionNegative()
        {
            try
            {
                boolVectors.Add(new BoolVector(new List<int>() { 0, 1, 1, 0, 1 }));
                BoolVector actualResult = BoolVectorAction.disjunction(boolVectors);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("All bool vectors must be the same size", ex.Message);
            }
            catch (Exception ex)
            {
                // not the right kind of exception
                Assert.Fail();
            }
        }

        [Test]
        public void test_negation()
        {
            BoolVector expectedResult = new BoolVector(new List<int>() { 0, 0, 0, 1 });
            BoolVector actualResult = BoolVectorAction.vectorNegation(boolVectors[4]);
            Assert.IsTrue(expectedResult.Components.SequenceEqual(actualResult.Components));
        }

        [Test]
        public void test_getNumberOfZeros()
        {
            int result = boolVectors[0].getNumberOfZeros();
            Assert.AreEqual(2, result);
        }

        [Test]
        public void test_getNumberOfOne()
        {
            int result = boolVectors[0].getNumberOfOne();
            Assert.AreEqual(2, result);
        }
    }
}