using MotionPlanning.Auxiliary;
using MotionPlanning.Statements;
using MotionPlanning.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Statements
{
    public class InchTest
    {
        [Test]
        // Testing identification
        public void Identification()
        {
            string gcode = "G20 X141.379 Y84.536 E324.40933";
            IURScript statement = Identifier.Identify(gcode);
            Assert.That(statement.GetType(), Is.EqualTo(typeof(Inch)));
        }
        [Test]
        // Testing inch setting
        public void SetInch()
        {
            string gcode = "G20 X141.379 Y84.536 E324.40933";
            Inch statement = new Inch(gcode);
            State st = new State();
            string result = statement.URScript(st);
            Assert.That(st.Millimeter, Is.False);
        }
    }
}
