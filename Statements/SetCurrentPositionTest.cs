using MotionPlanning.Auxiliary;
using MotionPlanning.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotionPlanning.Job;

namespace UnitTest.Statements
{
    public class SetCurrentPositionTest
    {
        [Test]
        // Testing identification
        public void Identification()
        {
            Job job = new Job();
            string gcode = "G92 X141.379 Y84.536 E324.40933";
            IURScript statement = Identifier.Identify(gcode, job);
            Assert.That(statement.GetType(), Is.EqualTo(typeof(SetCurrentPosition)));
        }

        // Test only x-axis
        // Test only y-axis
        // Test only z-axis

    }
}
