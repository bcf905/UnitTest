using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotionPlanning.Statements;
using MotionPlanning.State;
using MotionPlanning.Auxiliary;
using MotionPlanning.Job;
using MotionPlanning.Coordinates;
using MotionPlanning.Workspace;

namespace UnitTest.Statements
{
    public class RapidMoveTest
    {
        [Test]
        // Testing identification
        public void Identification()
        {
            Coordinate2D coord1 = new(10f, 10f);
            Coordinate2D coord2 = new(100f, 100f);
            Workspace workspace = new(coord1, coord2, 100, 10);
            Job job = new Job(workspace);
            string gcode = "G0 X141.379 Y84.536 E324.40933";
            IURScript statement = Identifier.Identify(gcode, job);
            Assert.That(statement.GetType(), Is.EqualTo(typeof(RapidMove)));
        }
        [Test]
        // Testing a valid statement
        public void ValidStatement()
        {
            float tolerance = 0.00001f;
            string gcode = "G0 X141.379 Y84.536 E324.40933";
            RapidMove stm = new RapidMove(gcode);
            Coordinate2D coord1 = new(10f, 10f);
            Coordinate2D coord2 = new(100f, 100f);
            Workspace workspace = new(coord1, coord2, 100, 10);
            State st = new State(workspace);
            Assert.That(stm.Valid, Is.True);
            Assert.That(stm.CommandType, Is.EqualTo('G'));
            Assert.That(stm.CommandNumber, Is.EqualTo(0));
            Assert.That(stm.X, Is.AtLeast(141.379 - tolerance));
            Assert.That(stm.X, Is.AtMost(141.379 + tolerance));
            Assert.That(stm.Y, Is.AtLeast(84.536 - tolerance));
            Assert.That(stm.Y, Is.AtMost(84.536 + tolerance));
            Assert.That(stm.Z, Is.AtMost(float.MinValue + tolerance));
            stm.URScript(st);
            Assert.That(st.X, Is.AtLeast(141.379 - tolerance));
            Assert.That(st.X, Is.AtMost(141.379 + tolerance));
            Assert.That(st.Y, Is.AtLeast(84.536 - tolerance));
            Assert.That(st.Y, Is.AtMost(84.536 + tolerance));
            Assert.That(st.Z, Is.AtLeast(0f - tolerance));
            Assert.That(st.Z, Is.AtMost(0f + tolerance));
        }
    }
}
