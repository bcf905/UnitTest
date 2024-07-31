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
    public class DwellTest
    {
        [Test]
        // Testing identification
        public void Identification()
        {
            Job job = new Job();
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
