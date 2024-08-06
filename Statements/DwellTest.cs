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
    public class DwellTest
    {
        [Test]
        // Testing identification
        public void Identification()
        {
            Coordinate2D coord1 = new(10f, 10f);
            Coordinate2D coord2 = new(100f, 100f);
            Workspace workspace = new(coord1, coord2, 100, 10);
            Job job = new Job(workspace);
            string gcode = "G4 X141.379 Y84.536 E324.40933";
            IURScript statement = Identifier.Identify(gcode, job);
            Assert.That(statement.GetType(), Is.EqualTo(typeof(Dwell)));
        }
        [Test]
        // Testing a valid statement with waiting time in seconds
        public void ValidStatementSeconds()
        {
            float tolerance = 0.001f;
            string gcode = "G4 S34.43";
            Dwell stm = new Dwell(gcode);
            Assert.That(stm.Valid, Is.True);
            //Assert.That(stm.WaitInSeconds, Is.True);
            Assert.That(stm.WaitingTime, Is.AtLeast(34.43 - tolerance));
            Assert.That(stm.WaitingTime, Is.AtMost(34.43 + tolerance));
        }
        [Test]
        // Testing a valid statement with waiting time in milliseconds
        public void ValidStatementMilliseconds()
        {
            float tolerance = 0.00001f;
            string gcode = "G4 P343";
            Dwell stm = new Dwell(gcode);
            Assert.That(stm.Valid, Is.True);
            Assert.That(stm.WaitInSeconds, Is.False);
            Assert.That(stm.WaitingTime, Is.AtLeast(343 - tolerance));
            Assert.That(stm.WaitingTime, Is.AtMost(343 + tolerance));
        }
    }
}
