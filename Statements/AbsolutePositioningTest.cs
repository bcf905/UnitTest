using MotionPlanning.Auxiliary;
using MotionPlanning.Coordinates;
using MotionPlanning.Job;
using MotionPlanning.State;
using MotionPlanning.Statements;
using MotionPlanning.Workspace;
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
            Coordinate2D coord1 = new(10f, 10f);
            Coordinate2D coord2 = new(100f, 100f);
            Workspace workspace = new(coord1, coord2, 100, 10);
            Job job = new Job(workspace);
            IURScript statement = Identifier.Identify(gcode, job);
            Assert.That(statement.GetType(), Is.EqualTo(typeof(AbsolutePositioning)));
        }
        [Test]
        // Testing positioning setting
        public void Positioning()
        {
            string gcode = "G90 X141.379 Y84.536 E324.40933";
            AbsolutePositioning statement = new AbsolutePositioning(gcode);
            Coordinate2D coord1 = new(10f, 10f);
            Coordinate2D coord2 = new(100f, 100f);
            Workspace workspace = new(coord1, coord2, 100, 10);
            State st = new State(workspace);
            string result = statement.URScript(st);
            Assert.That(st.Relative, Is.False);
        }
    }
}
