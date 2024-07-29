using MotionPlanning.Auxiliary;
using MotionPlanning.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Statements
{
    public class InvalidStatementTest
    {
        [Test]
        // Testing identification with unknown command type
        public void IdentificationUnknownCommandType()
        {
            string gcode = "F1 X141.379 Y84.536 E324.40933";
            IURScript statement = Identifier.Identify(gcode);
            Assert.That(statement.GetType(), Is.EqualTo(typeof(Invalid)));
        }
        [Test]
        // Testing identification with no command type
        public void IdentificationNoCommandType()
        {
            string gcode = "1 X141.379 Y84.536 E324.40933";
            IURScript statement = Identifier.Identify(gcode);
            Assert.That(statement.GetType(), Is.EqualTo(typeof(Invalid)));
        }
        [Test]
        // Testing identification with unknown command number
        public void IdentificationUnknownCommandNumber()
        {
            string gcode = "G10 X141.379 Y84.536 E324.40933";
            IURScript statement = Identifier.Identify(gcode);
            Assert.That(statement.GetType(), Is.EqualTo(typeof(Invalid)));
        }
        [Test]
        // Testing identification with no command number
        public void IdentificationNoCommandNumber()
        {
            string gcode = "G X141.379 Y84.536 E324.40933";
            IURScript statement = Identifier.Identify(gcode);
            Assert.That(statement.GetType(), Is.EqualTo(typeof(Invalid)));
        }
    }
}
