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
    public class LevelingTest
    {
        [Test]
        // Testing identification
        public void Identification()
        {
            Job job = new Job();
            string gcode = "G29 X141.379 Y84.536 E324.40933";
            IURScript statement = Identifier.Identify(gcode, job);
            Assert.That(statement.GetType(), Is.EqualTo(typeof(Leveling)));
        }
    }
}
