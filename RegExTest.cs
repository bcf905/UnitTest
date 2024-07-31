using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotionPlanning;
using MotionPlanning.Auxiliary;
using NUnit.Framework.Constraints;

namespace UnitTest
{
    public class RegExTest
    {
        [Test]
        // Test for matching a single letter
        public void MatchSingleLetter()
        {
            string str = "A";
            string pattern = "A";
            Assert.That(MotionPlanning.Auxiliary.RegEx.isMatch(pattern, str), Is.True);
        }
        // Test for not matching a single letter
        [Test]
        public void NotMatchSingleLetter()
        {
            string str = "A";
            string pattern = "B";
            Assert.That(MotionPlanning.Auxiliary.RegEx.isMatch(pattern, str), Is.False);
        }

        // Test for matching an integer
        [Test]
        public void MatchInteger()
        {
            string str = "X123";
            string pattern = @"\d+";
            Assert.That(MotionPlanning.Auxiliary.RegEx.isMatch(pattern, str), Is.True);
        }
        // Test for matching a float
        [Test]
        public void MatchFloatWithDecimals()
        {
            string str = "X123.45";
            string pattern = @"\d+(\.\d+)*";
            Assert.That(MotionPlanning.Auxiliary.RegEx.isMatch(pattern, str), Is.True);
        }
        // Test for matching a float without decimals.
        [Test]
        public void MatchFloatWithNoDecimals()
        {
            string str = "X123";
            string pattern = @"\d+(\.\d+)*";
            Assert.That(MotionPlanning.Auxiliary.RegEx.isMatch(pattern, str), Is.True);
        }
        // Test for returning an integer from integer.
        [Test]
        public void ReturnIntegerFromInteger()
        {
            char name = 'X';
            string str = "X123";
            Assert.That(MotionPlanning.Auxiliary.RegEx.returnInteger(name, str), Is.EqualTo(123));
        }
        // Test for returning an integer from float.
        [Test]
        public void ReturnIntegerFromFloat()
        {
            char name = 'X';
            string str = "X123.45";
            Assert.That(MotionPlanning.Auxiliary.RegEx.returnInteger(name, str), Is.EqualTo(123));
        }
        // Test for returning min value from integer.
        [Test]
        public void ReturnZeroFromInteger()
        {
            char name = 'X';
            string str = "X";
            Assert.That(MotionPlanning.Auxiliary.RegEx.returnInteger(name, str), Is.EqualTo(int.MinValue));
        }
        // Test for returning a float from a float.
        [Test]
        public void ReturnFloatFromFloat()
        {
            float tolerance = 0.00001f;
            char name = 'X';
            string str = "X123.45";
            Assert.That(MotionPlanning.Auxiliary.RegEx.returnFloat(name, str), Is.AtLeast(123.45 - tolerance));
            Assert.That(MotionPlanning.Auxiliary.RegEx.returnFloat(name, str), Is.AtMost(123.45 + tolerance));
        }
        // Test for returning a float from a integer.
        [Test]
        public void ReturnFloatFromInt()
        {
            float tolerance = 0.00001f;
            char name = 'X';
            string str = "X123";
            Assert.That(MotionPlanning.Auxiliary.RegEx.returnFloat(name, str), Is.AtLeast(123.00 - tolerance));
            Assert.That(MotionPlanning.Auxiliary.RegEx.returnFloat(name, str), Is.AtMost(123.00 + tolerance));
        }
        // Test for returning zero from a float.
        [Test]
        public void ReturnZeroFromFloat()
        {
            char name = 'X';
            string str = "X";
            Assert.That(MotionPlanning.Auxiliary.RegEx.returnFloat(name, str), Is.EqualTo(float.MinValue));
        }
        // Test for returning the value of z.
        [Test]
        public void ReturnZ()
        {
            float tolerance = 0.001f;
            char name = 'Z';
            string str = "G0 X5.00 Y20.00 Z1.25 E324.40933";
            Assert.That(MotionPlanning.Auxiliary.RegEx.returnFloat(name, str), Is.AtLeast(1.25 - tolerance));
            Assert.That(MotionPlanning.Auxiliary.RegEx.returnFloat(name, str), Is.AtMost(1.25 + tolerance));
        }

    }
}
