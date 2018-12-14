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
            boolVectors = new List<BoolVector>
            {
                new BoolVector(new List<int>() { 0, 1, 1, 0 }),
                new BoolVector(new List<int>() { 0, 0, 1, 0 }),
                new BoolVector(new List<int>() { 1, 1, 1, 0 }),
                new BoolVector(new List<int>() { 0, 1, 0, 0 }),
                new BoolVector(new List<int>() { 1, 1, 1, 0 })
            };
        }

        [Test]
         public void Test_conjunction()
        {
            BoolVector expectedResult = new BoolVector(new List<int>() { 0, 0, 0, 0 });
            BoolVector actualResult = BoolVectorAction.Conjunction(boolVectors);
            Assert.IsTrue(expectedResult.Components.SequenceEqual(actualResult.Components));
        }

        [Test]
        public void Test_conjunctionNegative()
        {
            try
            {
                boolVectors.Add(new BoolVector(new List<int>() { 0, 1, 1, 0, 1 }));
                BoolVector actualResult = BoolVectorAction.Conjunction(boolVectors);
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
        public void Test_disjunction()
        {
            BoolVector expectedResult = new BoolVector(new List<int>() { 1, 1, 1, 0 });
            BoolVector actualResult = BoolVectorAction.Disjunction(boolVectors);
            Assert.IsTrue(expectedResult.Components.SequenceEqual(actualResult.Components));
        }

        [Test]
        public void Test_disjunctionNegative()
        {
            try
            {
                boolVectors.Add(new BoolVector(new List<int>() { 0, 1, 1, 0, 1 }));
                BoolVector actualResult = BoolVectorAction.Disjunction(boolVectors);
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
        public void Test_negation()
        {
            BoolVector expectedResult = new BoolVector(new List<int>() { 0, 0, 0, 1 });
            BoolVector actualResult = BoolVectorAction.VectorNegation(boolVectors[4]);
            Assert.IsTrue(expectedResult.Components.SequenceEqual(actualResult.Components));
        }

        [Test]
        public void Test_getNumberOfZeros()
        {
            int result = boolVectors[0].GetNumberOfZeros();
            Assert.AreEqual(2, result);
        }

        [Test]
        public void Test_getNumberOfOne()
        {
            int result = boolVectors[0].GetNumberOfOne();
            Assert.AreEqual(2, result);
        }
    }
}