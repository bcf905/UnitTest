using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotionPlanning;

namespace UnitTest.Statements
{
    public class StatementTest
    {
        [Test]
        // Testing a valid statement
        public void ValidStatement()
        {
            float tolerance = 0.00001f;
            string gcode = "G1 X141.379 Y84.536 E324.40933";
            Statement stm = new Statement(gcode);
            Assert.That(stm.Valid, Is.True);
            Assert.That(stm.Command, Is.EqualTo(CommandType.LinearMove));
            Assert.That(stm.X, Is.AtLeast(141.379 - tolerance));
            Assert.That(stm.X, Is.AtMost(141.379 + tolerance));
            Assert.That(stm.Y, Is.AtLeast(84.536 - tolerance));
            Assert.That(stm.Y, Is.AtMost(84.536 + tolerance));
            Assert.That(stm.Z, Is.AtMost(float.MinValue + tolerance));
        }
        [Test]
        // Testing a valid statement
        public void ValidStatement3DigitCommand()
        {
            float tolerance = 0.00001f;
            string gcode = "G001 X141.379 Y84.536 E324.40933";
            Statement stm = new Statement(gcode);
            Assert.That(stm.Valid, Is.True);
            Assert.That(stm.Command, Is.EqualTo(CommandType.LinearMove));
            Assert.That(stm.X, Is.AtLeast(141.379 - tolerance));
            Assert.That(stm.X, Is.AtMost(141.379 + tolerance));
            Assert.That(stm.Y, Is.AtLeast(84.536 - tolerance));
            Assert.That(stm.Y, Is.AtMost(84.536 + tolerance));
            Assert.That(stm.Z, Is.AtMost(float.MinValue + tolerance));
        }
        [Test]
        // Testing an invalid statement
        public void InvalidStatement()
        {
            float tolerance = 0.00001f;
            string gcode = ";G1 X141.379 Y84.536 E324.40933";
            Statement stm = new Statement(gcode);
            Assert.That(stm.Valid, Is.False);
            Assert.That(stm.Command, Is.EqualTo(CommandType.None));
            Assert.That(stm.X, Is.AtLeast(0.0 - tolerance));
            Assert.That(stm.X, Is.AtMost(0.0 + tolerance));
            Assert.That(stm.Y, Is.AtLeast(0.0 - tolerance));
            Assert.That(stm.Y, Is.AtMost(0.0 + tolerance));
            Assert.That(stm.Z, Is.AtLeast(0.0 - tolerance));
            Assert.That(stm.Z, Is.AtMost(0.0 + tolerance));
        }
        [Test]
        // Test for Rapid Move
        public void RapidMoveStatement()
        {
            string gcode = "G0 X141.379 Y84.536 E324.40933";
            Statement stm = new Statement(gcode);
            Assert.That(stm.Command, Is.EqualTo(CommandType.RapidMove));
        }
        [Test]
        // Test for Rapid Move
        public void LinearMoveStatement()
        {
            string gcode = "G1 X141.379 Y84.536 E324.40933";
            Statement stm = new Statement(gcode);
            Assert.That(stm.Command, Is.EqualTo(CommandType.LinearMove));
        }
        [Test]
        // Test for Dwell
        public void DwellStatement()
        {
            string gcode = "G4 X141.379 Y84.536 E324.40933";
            Statement stm = new Statement(gcode);
            Assert.That(stm.Command, Is.EqualTo(CommandType.Dwell));
        }
        [Test]
        // Test for Inches
        public void InchesStatement()
        {
            string gcode = "G20 X141.379 Y84.536 E324.40933";
            Statement stm = new Statement(gcode);
            Assert.That(stm.Command, Is.EqualTo(CommandType.Inches));
        }
        [Test]
        // Test for Millimeters
        public void MillimetersStatement()
        {
            string gcode = "G21 X141.379 Y84.536 E324.40933";
            Statement stm = new Statement(gcode);
            Assert.That(stm.Command, Is.EqualTo(CommandType.Millimeters));
        }
        [Test]
        // Test for Home
        public void HomeStatement()
        {
            string gcode = "G28 X141.379 Y84.536 E324.40933";
            Statement stm = new Statement(gcode);
            Assert.That(stm.Command, Is.EqualTo(CommandType.Home));
        }
        [Test]
        // Test for Leveling
        public void LevelingStatement()
        {
            string gcode = "G29 X141.379 Y84.536 E324.40933";
            Statement stm = new Statement(gcode);
            Assert.That(stm.Command, Is.EqualTo(CommandType.Leveling));
        }
        [Test]
        // Test for Absolute Positioning
        public void AbsolutePositioningStatement()
        {
            string gcode = "G90 X141.379 Y84.536 E324.40933";
            Statement stm = new Statement(gcode);
            Assert.That(stm.Command, Is.EqualTo(CommandType.AbsolutePositioning));
        }
        [Test]
        // Test for Relative Positioning
        public void RelativePositioningStatement()
        {
            string gcode = "G91 X141.379 Y84.536 E324.40933";
            Statement stm = new Statement(gcode);
            Assert.That(stm.Command, Is.EqualTo(CommandType.RelativePositioning));
        }
        [Test]
        // Test for Set Current Position
        public void SetCurrentPositionStatement()
        {
            string gcode = "G92 X141.379 Y84.536 E324.40933";
            Statement stm = new Statement(gcode);
            Assert.That(stm.Command, Is.EqualTo(CommandType.SetCurrentPosition));
        }
    }
}
