using MotionPlanning.Auxiliary;
using MotionPlanning.Job;
using MotionPlanning.State;
using MotionPlanning.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Statements
{
    public class AbsolutePositioningTest
    {
        [Test]
        // Testing identification
        public void Identification()
        {
            string gcode = "G90 X141.379 Y84.536 E324.40933";
            Job job = new Job();
            IURScript statement = Identifier.Identify(gcode, job);
            Assert.That(statement.GetType(), Is.EqualTo(typeof(AbsolutePositioning)));
        }
        [Test]
        // Testing positioning setting
        public void Positioning()
        {
            string gcode = "G90 X141.379 Y84.536 E324.40933";
            AbsolutePositioning statement = new AbsolutePositioning(gcode);
            State st = new State();
            string result = statement.URScript(st);
            Assert.That(st.Relative, Is.False);
        }
    }
}
