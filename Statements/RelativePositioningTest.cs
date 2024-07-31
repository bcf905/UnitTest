using MotionPlanning.Auxiliary;
using MotionPlanning.State;
using MotionPlanning.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotionPlanning.Job;

namespace UnitTest.Statements
{
    public class RelativePositioningTest
    {
        [Test]
        // Testing identification
        public void Identification()
        {
            Job job = new Job();
            string gcode = "G91 X141.379 Y84.536 E324.40933";
            IURScript statement = Identifier.Identify(gcode, job);
            Assert.That(statement.GetType(), Is.EqualTo(typeof(RelativePositioning)));
        }
        [Test]
        // Testing positioning setting
        public void Positioning()
        {
            string gcode = "G91 X141.379 Y84.536 E324.40933";
            RelativePositioning statement = new RelativePositioning(gcode);
            State st = new State();
            string result = statement.URScript(st);
            Assert.That(st.Relative, Is.True);
        }
    }
}
