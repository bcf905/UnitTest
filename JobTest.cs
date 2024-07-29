using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MotionPlanning.Job;
using MotionPlanning.State;
using MotionPlanning.Statements;
using MotionPlanning.Auxiliary;
namespace UnitTest
{
    public class JobTest
    {
        [Test]
        // Testing for a job's valid statements
        public void ValidStatements()
        {
            string gcode1 = "G1 X141.379 Y84.536 E324.40933";
            string gcode2 = "G0 X141.379 Y84.536 E324.40933";
            string gcode3 = "G11 X141.379 Y84.536 E324.40933";

            IURScript linear = Identifier.Identify(gcode1);
            IURScript rapid = Identifier.Identify(gcode2);
            IURScript invalid = Identifier.Identify(gcode3);

            Job job = new Job();

            job.AddStatement(linear);
            job.AddStatement(rapid);
            job.AddStatement(invalid);

            List<string> urscript = job.GetURScript();

            Assert.That(urscript.Count, Is.EqualTo(2));
        }
    }
}
