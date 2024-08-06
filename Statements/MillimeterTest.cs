using MotionPlanning.Auxiliary;
using MotionPlanning.State;
using MotionPlanning.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotionPlanning.Job;
using MotionPlanning.Coordinates;
using MotionPlanning.Workspace;

namespace UnitTest.Statements
{
    public class MillimeterTest
    {
        [Test]
        // Testing identification
        public void Identification()
        {
            Coordinate2D coord1 = new(10f, 10f);
            Coordinate2D coord2 = new(100f, 100f);
            Workspace workspace = new(coord1, coord2, 100, 10);
            Job job = new Job(workspace);
            string gcode = "G21 X141.379 Y84.536 E324.40933";
            IURScript statement = Identifier.Identify(gcode, job);
            Assert.That(statement.GetType(), Is.EqualTo(typeof(Millimeter)));
        }
        [Test]
        // Testing millimeter setting
        public void SetMillimeter()
        {
            string gcode = "G21 X141.379 Y84.536 E324.40933";
            Millimeter statement = new Millimeter(gcode);
            Coordinate2D coord1 = new(10f, 10f);
            Coordinate2D coord2 = new(100f, 100f);
            Workspace workspace = new(coord1, coord2, 100, 10);
            State st = new State(workspace);
            string result = statement.URScript(st);
            Assert.That(st.Millimeter, Is.True);
        }
    }
}
